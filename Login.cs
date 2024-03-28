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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.Size = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            this.CenterToScreen();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string m = "";
            if (string.IsNullOrEmpty(textBox1.Text.Trim()))
            {
                m += "User Name is a Required Field \n";
            }
            if (string.IsNullOrEmpty(textBox2.Text.Trim()))
            {
                m += "Password is a Required Field";
            }
            if (m != "")
            {
                MessageBox.Show(m, "Empty Fields", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if (textBox1.Text.Trim() == "admin" && textBox2.Text.Trim() == "admin")
            {
                MessageBox.Show("Login Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Program.Redirect("Home", this, false);
            }
            else
            {
                MessageBox.Show("Login Fail: Enter Correct Login Details", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox2.Text = "";
            }
        }
    }
}
