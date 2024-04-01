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
                int itemId = GetItemIdFromBarcode(imageData);

                if (itemId != -1)
                {
                    bool existsInBill = CheckIfItemExistsInBill(itemId);

                    if (existsInBill)
                    {
                        IncreaseQuantity(itemId);
                    }
                    else
                    {
                        CreateNewBillRecord(itemId);
                    }
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Upload a valid Barcode Image");
                    label1.Text = "Upload the barcode here";
                }
            }
            else
            {
                MessageBox.Show("Upload a Barcode Image");
                label1.Text = "Upload the barcode here";
            }
        }

        private int GetItemIdFromBarcode(byte[] enteredImage)
        {
            int itemId = -1;
            string query = "SELECT item_id FROM barcode WHERE barcode = @imageBytes";

            using (SqlConnection connection = new SqlConnection(conStr))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@imageBytes", enteredImage);
                    connection.Open();
                    var result = command.ExecuteScalar();
                    if (result != null)
                    {
                        itemId = Convert.ToInt32(result);
                    }
                }
            }
            //MessageBox.Show("Item id = " + itemId, "GetItemIdFromBarcode()");
            return itemId;
        }

        private bool CheckIfItemExistsInBill(int itemId)
        {
            string query = "SELECT COUNT(*) FROM bill WHERE item_id = @itemId";
            using (SqlConnection connection = new SqlConnection(conStr))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@itemId", itemId);
                    connection.Open();
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0;
                }
            }
        }

        private void IncreaseQuantity(int itemId)
        {
            string query = "UPDATE bill SET quantity = quantity + 1 WHERE item_id = @itemId";

            using (SqlConnection connection = new SqlConnection(conStr))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@itemId", itemId);
                    connection.Open();
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show(ex.Message, "Stock Unavailable");
                    }
                }
            }
        }

        private void CreateNewBillRecord(int itemId)
        {
            string query = "INSERT INTO bill (item_id, quantity) VALUES (@itemId, 1)";

            using (SqlConnection connection = new SqlConnection(conStr))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@itemId", itemId);
                    connection.Open();
                    try
                    {
                        command.ExecuteNonQuery();
                    }
                    catch(SqlException ex)
                    {
                        MessageBox.Show(ex.Message, "Stock Unavailable");
                    }
                }
            }
        }

        private bool CheckStockAvailability()
        {
            bool available = false;
            return available;
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
