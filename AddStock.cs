using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inventory
{
    public partial class AddStock : Form
    {
        string conStr = ConfigurationManager.ConnectionStrings["inventory.Properties.Settings.inventoryCon"].ConnectionString;
        private event EventHandler<FormClosedEventArgs> FormClosedEvent;

        public AddStock()
        {
            InitializeComponent();
        }

        private void GetInventory()
        {
            string query = "SELECT i.item_id, i.item_name, i.desc_item, i.company_name, (SELECT c_name FROM category WHERE c_id = i.category_id) AS category, i.price, (SELECT quantity FROM barcode WHERE item_id = i.item_id) AS quantity FROM item i ORDER BY item_name ASC";
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
                        MessageBox.Show("Error: " + ex.Message);
                    }
                    finally { con.Close(); }
                }
            }
        }

        private void AddStock_Load(object sender, EventArgs e)
        {
            GetInventory();
        }

        private void ItemsDataGrid_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            string columnName = itemsDataGrid.Columns[e.ColumnIndex].Name;
            string itemName = itemsDataGrid.Rows[e.RowIndex].Cells["item_name"].Value.ToString();
            int id = Convert.ToInt32(itemsDataGrid.Rows[e.RowIndex].Cells["id"].Value);

            MessageBox.Show($"item name = {itemName}\nid = {id}");
            if (columnName == "newStock")
            {
                QuantityInputDialog quantityDialog = new QuantityInputDialog(itemName);
                quantityDialog.StartPosition = FormStartPosition.CenterParent;
                quantityDialog.ShowDialog();

                if (quantityDialog.DialogResult == DialogResult.OK)
                {
                    int quantity = quantityDialog.Quantity;

                    string update = "UPDATE barcode SET quantity = quantity + @newStock WHERE item_id = @itemId";
                    using (SqlConnection con = new SqlConnection(conStr))
                    {
                        con.Open();
                        using (SqlCommand cmd = new SqlCommand(update, con))
                        {
                            // Add parameters
                            cmd.Parameters.AddWithValue("@newStock", quantity);
                            cmd.Parameters.AddWithValue("@itemId", id);

                            try
                            {
                                cmd.ExecuteNonQuery();
                                con.Close();
                                MessageBox.Show("Stock has been Updated", "Update Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Program.Redirect("AddStock", this, false);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error: " + ex.Message);
                            }
                        }
                    }
                }
            }
        }
    }
}