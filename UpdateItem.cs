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

namespace inventory
{
    public partial class Update_Item : Form
    {
        string query;
        string conStr = ConfigurationManager.ConnectionStrings["inventory.Properties.Settings.inventoryCon"].ConnectionString;
        int id;


        public Update_Item(int id)
        {
            InitializeComponent();
            this.id = id;
            query = $"SELECT item_name, desc_item, company_name, (SELECT c_name FROM category WHERE c_id = category_id) AS category, price FROM item WHERE item_id = {this.id}";
            PopulateComboBox();
        }
        private void PopulateComboBox()
        {
            string query = "SELECT c_name FROM category";
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["inventory.Properties.Settings.inventoryCon"].ConnectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string category = reader["c_name"].ToString().Trim();
                            item_category.Items.Add(category);
                        }
                    }
                }
            }
        }
        private void Update_Click(object sender, EventArgs e)
        {
            
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                SqlCommand c_id = new SqlCommand($"SELECT c_id FROM category WHERE c_name = @c_name", con);
                c_id.Parameters.AddWithValue("@c_name", item_category.SelectedItem.ToString());
                int cid = 0;
                object result = c_id.ExecuteScalar();
                if (result != null)
                {
                    cid = int.Parse(result.ToString());
                }
                else
                {
                    MessageBox.Show("Database Connection Error!");
                }

                string update = "UPDATE item SET item_name = @itemName, desc_item = @itemDesc, company_name = @companyName, category_id = @categoryId, price = @price WHERE item_id = @itemId";
                using (SqlCommand cmd = new SqlCommand(update, con))
                {
                    // Add parameters
                    cmd.Parameters.AddWithValue("@itemName", item_name.Text.Trim());
                    cmd.Parameters.AddWithValue("@itemDesc", item_desc.Text.Trim());
                    cmd.Parameters.AddWithValue("@companyName", item_company.Text.Trim());
                    cmd.Parameters.AddWithValue("@categoryId", cid);
                    cmd.Parameters.AddWithValue("@price", float.Parse(price.Text.Trim()));
                    cmd.Parameters.AddWithValue("@itemId", id);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Item has been Updated", "Update Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Program.Redirect("Home", this, false);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void Update_Item_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    try
                    {
                        con.Open();
                        using (SqlDataReader r = cmd.ExecuteReader())
                        {
                            if (r.Read())
                            {
                                item_name.Text = r["item_name"].ToString();
                                item_desc.Text = r["desc_item"].ToString();
                                item_company.Text = r["company_name"].ToString();
                                string categoryName = r["category"].ToString();
                                item_category.SelectedItem = categoryName;
                                price.Text = r["price"].ToString();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                    finally { con.Close(); }
                }
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Program.Redirect("Home", this, false);
        }
    }
}
