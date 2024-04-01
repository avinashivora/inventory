using System;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using BarcodeStandard;
using System.Drawing;
using System.Runtime.InteropServices;
using SkiaSharp;
using System.Data;

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
        private string EmptyFieldValidator()
        {
            string alert = "";

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
                    float i_price = float.Parse(price.Text.Trim());
                    if (i_price < 0)
                    {
                        alert += "Price needs to be positive";
                    }
                }
                catch
                {
                    alert += "Item Price needs to be Numeric! \n";
                }
            }
            return alert;
        }

        private void New_item_btn_Click(object sender, EventArgs e)
        {
            string alert = EmptyFieldValidator();
            if (!string.IsNullOrEmpty(alert))
            {
                MessageBox.Show(alert, "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    SqlCommand insert = new SqlCommand("INSERT INTO item (item_name, desc_item, company_name, category_id, price) VALUES (@item_name, @desc_item, @company_name, @c_id, @price); SELECT SCOPE_IDENTITY() AS new_item_id;", con);
                    SqlCommand c_id = new SqlCommand($"SELECT c_id FROM category WHERE c_name = @c_name", con);
                    c_id.Parameters.AddWithValue("@c_name", item_category.SelectedItem.ToString());
                    int cid = 0;
                
                    con.Open();
                    object result = c_id.ExecuteScalar();
                    
                    if (result != null)
                    {
                        cid = int.Parse(result.ToString());
                    }
                    else
                    {
                        MessageBox.Show("Database Connection Error!");
                    }

                    float i_price = float.Parse(price.Text.Trim());
                    insert.Parameters.AddWithValue("@item_name", item_name.Text.Trim());
                    insert.Parameters.AddWithValue("@desc_item", item_desc.Text.Trim());
                    insert.Parameters.AddWithValue("@company_name", item_company.Text.Trim());
                    insert.Parameters.AddWithValue("@category_id", cid);
                    insert.Parameters.AddWithValue("@price", i_price);
                    insert.Parameters.AddWithValue("@c_id", cid);

                    try
                    {
                        int newItemId = Convert.ToInt32(insert.ExecuteScalar());
                        MessageBox.Show("Item Added to Catalogue Successfully", "Item Created");
                        BarcodeToDatabaseStorableValue(newItemId, item_name.Text.Trim());
                        item_name.Text = "";
                        item_desc.Text = "";
                        item_company.Text = "";
                        price.Text = "";
                        item_category.SelectedIndex = -1;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Item Creation Status");
                    }
                    finally { con.Close(); }
                }
            }
        }

        public void BarcodeToDatabaseStorableValue(int itemID, string item)
        {
            //Code93 used
            //Barcodelib used: barnhill/barcodelib on github
            //Valid characters for Code93: 0123456789[Space]ABCDEFGHIJKLMNOPQRSTUVWXYZ-.$/+%
            //The barcode data length is 14 characters maximum used
            //String of barcode data = random character[2] + itemName[5 letters] + random special character[2] + item_id[trailing 3 digits] + random character[2]

            byte[] imageBytes = null;

            Func<bool, char> randomGenerator = (bool allValid) =>
            {
                Random random = new Random();

                string code93Chars;
                if (allValid) code93Chars = "0123456789 ABCDEFGHIJKLMNOPQRSTUVWXYZ-.$/+%";
                else code93Chars = "-.$/+%";
                int randomIndex = random.Next(0, code93Chars.Length);
                return code93Chars[randomIndex];
            };

            Func<string, string> itemNameForBarData = (string itemName) =>
            {
                string code93Chars = "0123456789 ABCDEFGHIJKLMNOPQRSTUVWXYZ-.$/+%";
                string itemData = "";
                while(itemData.Length < 5)
                {
                    try
                    {
                        foreach (char c in itemName.ToUpper())
                        {
                            if (code93Chars.Contains(c.ToString())) itemData += c;
                        }
                    }
                    catch
                    {
                        itemData += " ";
                    }
                }
                return itemData;
            };

            Func<int, string> itemIdGenerator = (int id) =>
            {
                string strNumber = id.ToString();
                if (strNumber.Length < 3)
                {
                    // Generate random characters for the missing digits
                    string randomDigits = string.Empty;
                    for (int i = 0; i < 3 - strNumber.Length; i++)
                    {
                        randomDigits += randomGenerator(true);
                    }
                    // Concatenate the random characters with the last digits of the number
                    return randomDigits + strNumber;
                }
                else
                {
                    // Return the last three digits of the number
                    return strNumber.Substring(strNumber.Length - 3);
                }
            };

            try
            {
                Barcode barcode = new Barcode();
                string data = randomGenerator(true) + randomGenerator(true) + itemNameForBarData(item) + randomGenerator(false) + randomGenerator(false) + itemIdGenerator(itemID) + randomGenerator(true) + randomGenerator(true);
                barcode.IncludeLabel = false;
                SKImage img = barcode.Encode(BarcodeStandard.Type.Code93, data, SKColors.Black, SKColors.White, 290, 120);

                using (MemoryStream stream = new MemoryStream())
                {
                    img.Encode(SKEncodedImageFormat.Png, 100).SaveTo(stream);
                    imageBytes = stream.ToArray();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error generating the Barcode", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                SqlCommand barcoded = new SqlCommand($"INSERT INTO barcode (item_id, barcode) VALUES (@item_id, @imageBytes)", con);
                try
                {
                    barcoded.Parameters.AddWithValue("@item_id", itemID);
                    SqlParameter paramBarcodeImage = new SqlParameter("@imageBytes", SqlDbType.VarBinary, -1);
                    paramBarcodeImage.Value = imageBytes;
                    barcoded.Parameters.Add(paramBarcodeImage);

                    barcoded.ExecuteNonQuery();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Database Connection Error to save the Barcode in database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally { con.Close(); }
            }
        }
    }
}