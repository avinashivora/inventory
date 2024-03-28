using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Deployment.Application;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inventory
{
    public partial class Home : Form
    {
        string conStr = ConfigurationManager.ConnectionStrings["inventory.Properties.Settings.inventoryCon"].ConnectionString;

        public Home()
        {
            InitializeComponent();
        }

        private void GetInventory()
        {
            string query = "SELECT DISTINCT i.item_id, i.item_name, i.desc_item, i.company_name, c.c_name AS category, i.price, b.quantity FROM item i LEFT JOIN category c ON c.c_id = i.category_id LEFT JOIN barcode b ON b.item_id = i.item_id ORDER BY i.item_name ASC;";
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, con))
                {
                    DataTable dataTable = new DataTable();
                    try
                    {
                        con.Open();
                        adapter.Fill(dataTable);
                        itemsDataGrid.DataSource = dataTable;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "GetInventory error");
                    }
                    finally { con.Close(); }
                }
            }
        }

        private void Home_Load(object sender, EventArgs e)
        {
            GetInventory();
        }

        private void ItemsDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string columnName = itemsDataGrid.Columns[e.ColumnIndex].Name;
            string itemName = itemsDataGrid.Rows[e.RowIndex].Cells["item_name"].Value.ToString();
            int id = Convert.ToInt32(itemsDataGrid.Rows[e.RowIndex].Cells["id"].Value);
            if (columnName == "update")
            {
                UpdateItem(id);
            }
            else if (columnName == "del")
            {
                DialogResult result = MessageBox.Show($"Are you sure you want to delete {itemName} from Inventory? ", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes) DeleteItem(itemName);
            }
            else if (columnName == "barcode")
            {
                try
                {
                    object quantityValue = itemsDataGrid.Rows[e.RowIndex].Cells["quantity"].Value;
                    if (quantityValue == null || quantityValue == DBNull.Value)
                    {
                        AddItemWindow barcodeGenerate = new AddItemWindow();
                        barcodeGenerate.BarcodeToDatabaseStorableValue(id, itemName);
                    }
                }
                catch
                {
                    MessageBox.Show("Error generating the barcode before download");
                }
                
                DownloadBarcode(id);
                GetInventory();
            }
        }
        private void UpdateItem(int id)
        {
            Form uForm = new Update_Item(id);
            uForm.StartPosition = FormStartPosition.Manual;
            uForm.Location = this.Location;
            uForm.FormClosing += (sender, e) =>
            {
                new Home().Show();
            };
            uForm.Show();
            this.Hide();
        }

        private void DeleteItem(string itemName)
        {
            string query = $"DELETE FROM item WHERE item_name = \'{itemName}\'";
            SqlConnection con;
            try
            {
                con = new SqlConnection(conStr);
                con.Open(); 
                SqlCommand sqlCommand = new SqlCommand(query, con);
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show($"{itemName} has been Deleted from Inventory", "Delete Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Delete Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            GetInventory();
        }

        private void DownloadBarcode(int id)
        {
            try
            {
                string query = $"SELECT barcode FROM barcode WHERE item_id = '{id}'";
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    con.Open();
                    SqlCommand sqlCommand = new SqlCommand(query, con);
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    if (reader.Read())
                    {
                        byte[] imageData = (byte[])reader["barcode"];
                        string base64String = Convert.ToBase64String(imageData);

                        byte[] imageBytes = Convert.FromBase64String(base64String);

                        // Prompt user to choose location to save the file
                        SaveFileDialog saveFileDialog = new SaveFileDialog();
                        saveFileDialog.Filter = "PNG Image|*.png";
                        saveFileDialog.Title = "Save Barcode Image";
                        saveFileDialog.ShowDialog();

                        // If user chose a location, save the file
                        if (saveFileDialog.FileName != "")
                        {
                            File.WriteAllBytes(saveFileDialog.FileName, imageBytes);
                            MessageBox.Show("Barcode image downloaded successfully.", "Download Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("Barcode image not found for the specified item ID.", "Download Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Download Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}


