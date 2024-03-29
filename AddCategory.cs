using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inventory
{
    public partial class AddCategory : Form
    {
        string conStr = ConfigurationManager.ConnectionStrings["inventory.Properties.Settings.inventoryCon"].ConnectionString;
        public AddCategory()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string c_name = cname.Text;
                if (string.IsNullOrEmpty(c_name))
                {
                    MessageBox.Show("Category Name can't be Empty", "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    con.Open();
                    string q = $"SELECT CASE WHEN EXISTS (SELECT * FROM category WHERE c_name = \'{c_name}\') THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END AS ValueExists";
                    int valueExists;
                    using (SqlCommand cmd = new SqlCommand(q, con))
                    {
                        valueExists = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                    if (valueExists == 1)
                    {
                        MessageBox.Show("Category Already Exists", "Existing Category", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        SqlCommand insert = new SqlCommand($"INSERT INTO category (c_name) VALUES (\'{c_name}\')", con);
                        try
                        {
                            insert.ExecuteNonQuery();
                            MessageBox.Show("Item Added to Catalogue Successfully", "Item Created");
                            cname.Text = "";
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Item Created");
                        }
                        con.Close();
                    }
                }
            }
        }
    }
}
