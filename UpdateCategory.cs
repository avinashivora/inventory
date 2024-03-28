using System;
using System.Collections;
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
    public partial class UpdateCategory : Form
    {
        string conStr = ConfigurationManager.ConnectionStrings["inventory.Properties.Settings.inventoryCon"].ConnectionString;
        int id;

        public UpdateCategory(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            Program.Redirect("Categories", this, false);
        }

        private void Update_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                string update = "UPDATE category SET c_name = @c_name WHERE c_id = @c_id";
                using (SqlCommand cmd = new SqlCommand(update, con))
                {
                    // Add parameters
                    cmd.Parameters.AddWithValue("@c_name", cname.Text.Trim());
                    cmd.Parameters.AddWithValue("@c_id", id);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Item has been Updated", "Update Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void UpdateCategory_Load(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                string getCategory = "SELECT c_name FROM category WHERE c_id = @id";
                using (SqlCommand cmd = new SqlCommand(getCategory, con))
                {
                    try
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        con.Open();
                        cname.Text = cmd.ExecuteScalar().ToString();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error getting Category Name: " + ex.Message);
                    }
                    finally { con.Close(); }
                }
            }
        }
    }
}
