using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace inventory
{
    public partial class Categories : Form
    {
        string conStr = ConfigurationManager.ConnectionStrings["inventory.Properties.Settings.inventoryCon"].ConnectionString;
        public Categories()
        {
            InitializeComponent();
        }

        private void GetCategories()
        {
            string query = "SELECT c_name, c_id FROM category ORDER BY c_name ASC";
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, con))
                {
                    DataTable dataTable = new DataTable();
                    try
                    {
                        con.Open();
                        adapter.Fill(dataTable);
                        categories_dataGrid.DataSource = dataTable;
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                    finally { con.Close(); }
                }
            }
        }


        private void Categories_Load(object sender, EventArgs e)
        {
            GetCategories();
        }

        private void Categories_dataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string columnName = categories_dataGrid.Columns[e.ColumnIndex].Name;
            int cat = Convert.ToInt32(categories_dataGrid.Rows[e.RowIndex].Cells["c_id"].Value);
            if (columnName == "update")
            {
                UpdateCategory(cat);
            }
            else if (columnName == "del")
            {
                DialogResult result = MessageBox.Show($"Are you sure you want to delete {categories_dataGrid.Rows[e.RowIndex].Cells["c_name"].Value} from Categories? ", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes) DeleteItem(cat);
            }
        }

        private void DeleteItem(int cid)
        {
            string query = $"DELETE FROM category WHERE c_id = \'{cid}\'";
            string verify = $"SELECT CASE WHEN EXISTS (SELECT * FROM item WHERE category_id = \'{cid}\') THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END AS ValueExists";

            try
            {
                SqlConnection con = new SqlConnection(conStr);
                con.Open();
                SqlCommand sqlCommand = new SqlCommand(verify, con);
                int valueExists = Convert.ToInt32(sqlCommand.ExecuteScalar());
                if (valueExists == 1)
                {
                    MessageBox.Show($"The Category is Currently in Use by Some Item(s)", "Delete Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                }
                else
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show($"The Category has been Deleted from Categories", "Delete Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Delete Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            GetCategories();
        }

        private void UpdateCategory(int id)
        {
            Form uForm = new UpdateCategory(id);
            uForm.StartPosition = FormStartPosition.Manual;
            uForm.Location = this.Location;
            uForm.FormClosing += (sender, e) =>
            {
                new Categories().Show();
            };
            uForm.Show();
            this.Hide();
        }
    }
}
