using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inventory
{
    public partial class Checkout : Form
    {
        byte[] imageData = null;
        string conStr = ConfigurationManager.ConnectionStrings["inventory.Properties.Settings.inventoryCon"].ConnectionString;

        public Checkout()
        {
            InitializeComponent();
        }

        private void ProcessCheckout(byte[] imageData)
        {
            if (imageData != null)
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    con.Open();
                    string update = "UPDATE barcode SET quantity = quantity - 1 WHERE barcode = @barcodeData";

                    using (SqlCommand cmd = new SqlCommand(update, con))
                    {
                        cmd.Parameters.AddWithValue("@barcodeData", imageData);

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
            else
            {
                MessageBox.Show("Upload a Barcode Image");
            }
        }

        private void UploadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg;*.jpeg;*.png;*.gif;*.bmp)|*.jpg;*.jpeg;*.png;*.gif;*.bmp|All files (*.*)|*.*";
            openFileDialog.Title = "Select an Image File";


            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = openFileDialog.FileName;
                imageData = File.ReadAllBytes(fileName);
                label1.Text = "Barcode Image Uploaded";
            }
        }

        private void Checkout_btn_Click(object sender, EventArgs e)
        {
            ProcessCheckout(imageData);
        }
    }
}
