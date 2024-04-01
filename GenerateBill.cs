using Azure;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inventory
{
    public partial class GenerateBill : Form
    {
        string conStr = ConfigurationManager.ConnectionStrings["inventory.Properties.Settings.inventoryCon"].ConnectionString;

        public GenerateBill()
        {
            InitializeComponent();
        }

        private void GenerateBill_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                SqlCommand query = new SqlCommand("SELECT item_id, item_name, quantity, total_price FROM bill", con);
                using (SqlDataAdapter adapter = new SqlDataAdapter(query))
                {
                    DataTable dataTable = new DataTable();
                    try
                    {
                        adapter.Fill(dataTable);
                        dataGridView1.DataSource = dataTable;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                    finally { con.Close(); }
                }
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            Form parentForm = this.FindForm(); 
            if (parentForm != null)
            {
                Form newCategory = new Checkout();
                newCategory.StartPosition = FormStartPosition.CenterScreen;
                newCategory.Location = this.Location;
                newCategory.FormClosing += (senderO, ev) =>
                {
                    GenerateBill_Load(sender, e);
                };
                newCategory.Show();
            }
            else
            {
                MessageBox.Show("Error: Unable to find parent form.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ProcessCheckout()
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                string update = "UPDATE barcode SET quantity = quantity - @checkoutQuantity WHERE item_id = @id; DELETE FROM bill";
                try
                {
                    if (dataGridView1.Rows.Count != 0)
                    {
                        DialogResult yn = MessageBox.Show("Do you want to Download the Bill?", "Bill Download", MessageBoxButtons.YesNoCancel);
                        if (yn == DialogResult.Yes) { GenerateAndDownloadImage(); }
                        if (yn == DialogResult.Cancel) { return; }
                        SqlCommand cmd = new SqlCommand(update, con);
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (row.Cells["quantity"].Value != null && row.Cells["item_id"].Value != null)
                            {
                                int quantity = Convert.ToInt32(row.Cells["quantity"].Value);
                                int itemId = Convert.ToInt32(row.Cells["item_id"].Value);
                                cmd.Parameters.Clear();
                                cmd.Parameters.AddWithValue("@checkoutQuantity", quantity);
                                cmd.Parameters.AddWithValue("@id", itemId);
                                cmd.ExecuteNonQuery();
                            }
                            this.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bill Transaction Session is empty. Add something to bill");
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Checkout_Click(object sender, EventArgs e)
        {
            ProcessCheckout();
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string columnName = dataGridView1.Columns[e.ColumnIndex].Name;
                int id = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["item_id"].Value);
                if (columnName == "remove")
                {
                    RemoveItem(id);
                    GenerateBill_Load(sender, e);
                }
                else { MessageBox.Show("datagrid cell content click else"); }
            }
            catch(Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void RemoveItem(int id)
        {
            try
            {
                string remove = "UPDATE bill SET quantity = quantity - 1 WHERE item_id = @id";
                using(SqlConnection con = new SqlConnection(conStr))
                {
                    con.Open();
                    using(SqlCommand cmd = new SqlCommand(remove, con))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("remove item click");
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void GenerateAndDownloadImage()
        {
            Image generatedImage = RetrieveBillDetailsFromDatabase();

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PNG Image|*.png";
            saveFileDialog.Title = "Save Bill Image";
            saveFileDialog.FileName = "bill_image.png"; // Set default file name
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFilePath = saveFileDialog.FileName;
                generatedImage.Save(selectedFilePath, ImageFormat.Png);
                MessageBox.Show("Bill image downloaded successfully.", "Download Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                DialogResult yn = MessageBox.Show("Are you sure you want to Cancel Download of Bill Image?", "Download Canceled", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (yn == DialogResult.No) { GenerateAndDownloadImage(); }
            }
        }

        private Image RetrieveBillDetailsFromDatabase()
        {
            string billDataQuery = "SELECT item_name AS ItemName, quantity AS Quantity, total_price AS Price FROM bill";
            Bitmap billImage = new Bitmap(600, 300); // Adjust the image size as needed
            using (Graphics g = Graphics.FromImage(billImage))
            {
                g.FillRectangle(Brushes.White, 0, 0, billImage.Width, billImage.Height);
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    using (SqlCommand cmd = new SqlCommand(billDataQuery, con))
                    {
                        con.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        int y = 10;
                        int rowHeight = 20;
                        // Draw column headings
                        g.DrawString("Item Name", new Font("Arial", 11, FontStyle.Bold), Brushes.Black, new PointF(10, y));
                        g.DrawString("Quantity", new Font("Arial", 11, FontStyle.Bold), Brushes.Black, new PointF(225, y));
                        g.DrawString("Price", new Font("Arial", 11, FontStyle.Bold), Brushes.Black, new PointF(400, y));
                        y += rowHeight;
                        while (reader.Read())
                        {
                            string itemName = reader["ItemName"].ToString();
                            int quantity = Convert.ToInt32(reader["Quantity"]);
                            decimal price = Convert.ToDecimal(reader["Price"]);
                            string billDetails = $"{itemName}\t\t\t{quantity}\t\t₹{price}";
                            g.DrawString(billDetails, new Font("Arial", 12), Brushes.Black, new PointF(10, y));
                            y += rowHeight;
                        }
                        reader.Close();
                        // Draw total price
                        decimal totalPrice = GetTotalPriceFromDatabase();
                        string totalPriceText = $"\n\t\tTotal Price: \t\t\t\t₹{totalPrice}";
                        g.DrawString(totalPriceText, new Font("Arial", 12, FontStyle.Bold), Brushes.Black, new PointF(10, y));
                    }
                }
            }
            return billImage;
        }

        private decimal GetTotalPriceFromDatabase()
        {
            string totalPriceQuery = "SELECT SUM(total_price) AS TotalPrice FROM bill";
            decimal totalPrice = 0;
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand(totalPriceQuery, con))
                {
                    con.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        totalPrice = Convert.ToDecimal(result);
                    }
                }
            }
            return totalPrice;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                string update = "DELETE FROM bill";
                try
                {
                    DialogResult yn = MessageBox.Show("Are you sure you want to cancel this transaction?", "Cancel Billing Session", MessageBoxButtons.YesNo);
                    if (yn == DialogResult.Yes)
                    {
                        SqlCommand cmd = new SqlCommand(update, con);
                        cmd.ExecuteNonQuery();
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Cancelling Transaction");
                }
            }
        }
    }
}
