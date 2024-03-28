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
    public partial class Item : UserControl
    {
        public Item()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
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
                }
                catch
                {
                    alert += "Item Price needs to be Numeric! \n";
                }
            }
            return alert;
        }

        private float GetPrice()
        {
            return float.Parse(price.Text.Trim());
        }
    }
}
