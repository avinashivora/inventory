using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace inventory
{
    public partial class QuantityInputDialog : Form
    {
        string name;
        public int Quantity { get; private set; }

        public QuantityInputDialog(string name)
        {
            InitializeComponent();
            this.name = name;
            label1.Text += this.name;
        }

        private void Stock_btn_Click(object sender, EventArgs e)
        {
            Quantity = (int)num.Value;
            DialogResult = DialogResult.OK;
        }
    }
}
