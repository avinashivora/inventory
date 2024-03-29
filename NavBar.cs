﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static inventory.Program;

namespace inventory
{
    public partial class NavBar : UserControl
    {
        public NavBar()
        {
            InitializeComponent();
        }

        private void ViewInventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form parentForm = this.FindForm(); // Get the parent form of the user control
            if (parentForm != null)
            {
                Redirect("Home", parentForm, false);
            }
            else
            {
                MessageBox.Show("Error: Unable to find parent form.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddNewItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form newCategory = new AddItemWindow();
            newCategory.StartPosition = FormStartPosition.Manual;
            newCategory.Location = this.Location;
            newCategory.FormClosing += (senderO, ev) =>
            {
                new Home().Show();
            };
            newCategory.Show();
            this.Hide();
        }

        private void ViewItemCategoryListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form parentForm = this.FindForm(); // Get the parent form of the user control
            if (parentForm != null)
            {
                Redirect("Categories", parentForm, true);
            }
            else
            {
                MessageBox.Show("Error: Unable to find parent form.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddNewCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form newCategory = new AddCategory();
            newCategory.StartPosition = FormStartPosition.Manual;
            newCategory.Location = this.Location;
            newCategory.FormClosing += (senderO, ev) =>
            {
                new Categories().Show();
            };
            newCategory.Show();
            this.Hide();
        }

        private void LogOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form parentForm = this.FindForm(); // Get the parent form of the user control
            if (parentForm != null)
            {
                Redirect("Login", parentForm, false);
                MessageBox.Show("Log Out Successful", "Logout", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("Error: Unable to find parent form.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CheckoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Form parentForm = this.FindForm(); // Get the parent form of the user control
            //if (parentForm != null)
            //{
            //    Redirect("AddCategory", parentForm, true);
            //}
            //else
            //{
            //    MessageBox.Show("Error: Unable to find parent form.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void AddNewStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form parentForm = this.FindForm(); // Get the parent form of the user control
            if (parentForm != null)
            {
                Redirect("AddStock", parentForm, true);
            }
            else
            {
                MessageBox.Show("Error: Unable to find parent form.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
