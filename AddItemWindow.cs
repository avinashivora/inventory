using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace inventory
{
    public partial class AddItemWindow : Form
    {
        string conStr = ConfigurationManager.ConnectionStrings["inventory.Properties.Settings.inventoryCon"].ConnectionString;
        public AddItemWindow()
        {
            InitializeComponent();
            PopulateComboBox();
        }
        private void PopulateComboBox()
        {
            string query = "SELECT c_name FROM category";
            using(SqlConnection con = new SqlConnection(conStr))
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
        private void new_item_btn_Click(object sender, EventArgs e)
        {
            string alert = "";
            float i_price=0;

            if (string.IsNullOrEmpty(item_name.Text.Trim()))
            {
                alert += "Item Name is Required! \n";
            }
            if (item_category.SelectedIndex == -1)
            {
                alert += "Item Category needs to be selected! \n";
            }
            if (string.IsNullOrEmpty(price.Text.Trim()))
            {
                alert += "Item Price is Required! \n";
            }
            else
            {
                try
                {
                    i_price = float.Parse(price.Text.Trim());
                }
                catch
                {
                    alert += "Item Price needs to be Numeric! \n";
                }
            }
            if (!string.IsNullOrEmpty(alert))
            {
                MessageBox.Show(alert, "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                using(SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand insert = new SqlCommand("INSERT INTO item (item_name, desc_item, company_name, category_id, price) VALUES (@item_name, @desc_item, @company_name, @category_id, @price)", con);
                    con.Open();
                    SqlCommand c_id = new SqlCommand($"SELECT c_id FROM category WHERE c_name = @c_name", con);
                    c_id.Parameters.AddWithValue("@c_name", item_category.SelectedItem.ToString());
                    int cid = 0;
                    object result = c_id.ExecuteScalar();
                    if (result != null)
                    {
                        cid =  int.Parse(result.ToString());
                    }
                    else
                    {
                        MessageBox.Show("Database Connection Error!");
                    }
                    insert.Parameters.AddWithValue("@item_name", item_name.Text.Trim());
                    insert.Parameters.AddWithValue("@desc_item", item_desc.Text.Trim());
                    insert.Parameters.AddWithValue("@company_name", item_company.Text.Trim());
                    insert.Parameters.AddWithValue("@category_id", cid);
                    insert.Parameters.AddWithValue("@price", i_price);
                    try
                    {
                        insert.ExecuteNonQuery();
                        MessageBox.Show("Item Added to Catalogue Successfully", "Item Created");
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Item Created");
                    }
                    item_name.Text = "";
                    item_desc.Text = "";
                    item_company.Text = "";
                    price.Text = "";
                    item_category.SelectedIndex = -1;
                    con.Close();
                }
            }
        }
    }
}
