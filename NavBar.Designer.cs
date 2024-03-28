namespace inventory
{
    partial class NavBar
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.inventoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewInventoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categoriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewItemCategoryListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewCategoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewStockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inventoryToolStripMenuItem,
            this.categoriesToolStripMenuItem,
            this.logOutToolStripMenuItem,
            this.checkoutToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(971, 33);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip2";
            // 
            // inventoryToolStripMenuItem
            // 
            this.inventoryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewInventoryToolStripMenuItem,
            this.addNewItemToolStripMenuItem,
            this.addNewStockToolStripMenuItem});
            this.inventoryToolStripMenuItem.Name = "inventoryToolStripMenuItem";
            this.inventoryToolStripMenuItem.Size = new System.Drawing.Size(103, 29);
            this.inventoryToolStripMenuItem.Text = "Inventory";
            // 
            // viewInventoryToolStripMenuItem
            // 
            this.viewInventoryToolStripMenuItem.Name = "viewInventoryToolStripMenuItem";
            this.viewInventoryToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.viewInventoryToolStripMenuItem.Text = "View Inventory";
            this.viewInventoryToolStripMenuItem.Click += new System.EventHandler(this.ViewInventoryToolStripMenuItem_Click);
            // 
            // addNewItemToolStripMenuItem
            // 
            this.addNewItemToolStripMenuItem.Name = "addNewItemToolStripMenuItem";
            this.addNewItemToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.addNewItemToolStripMenuItem.Text = "Add New Item";
            this.addNewItemToolStripMenuItem.Click += new System.EventHandler(this.AddNewItemToolStripMenuItem_Click);
            // 
            // categoriesToolStripMenuItem
            // 
            this.categoriesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewItemCategoryListToolStripMenuItem,
            this.addNewCategoryToolStripMenuItem});
            this.categoriesToolStripMenuItem.Name = "categoriesToolStripMenuItem";
            this.categoriesToolStripMenuItem.Size = new System.Drawing.Size(112, 29);
            this.categoriesToolStripMenuItem.Text = "Categories";
            // 
            // viewItemCategoryListToolStripMenuItem
            // 
            this.viewItemCategoryListToolStripMenuItem.Name = "viewItemCategoryListToolStripMenuItem";
            this.viewItemCategoryListToolStripMenuItem.Size = new System.Drawing.Size(300, 34);
            this.viewItemCategoryListToolStripMenuItem.Text = "View Item Category List";
            this.viewItemCategoryListToolStripMenuItem.Click += new System.EventHandler(this.ViewItemCategoryListToolStripMenuItem_Click);
            // 
            // addNewCategoryToolStripMenuItem
            // 
            this.addNewCategoryToolStripMenuItem.Name = "addNewCategoryToolStripMenuItem";
            this.addNewCategoryToolStripMenuItem.Size = new System.Drawing.Size(300, 34);
            this.addNewCategoryToolStripMenuItem.Text = "Add New Category";
            this.addNewCategoryToolStripMenuItem.Click += new System.EventHandler(this.AddNewCategoryToolStripMenuItem_Click);
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.logOutToolStripMenuItem.BackColor = System.Drawing.Color.Red;
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(93, 29);
            this.logOutToolStripMenuItem.Text = "Log Out";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.LogOutToolStripMenuItem_Click);
            // 
            // checkoutToolStripMenuItem
            // 
            this.checkoutToolStripMenuItem.Name = "checkoutToolStripMenuItem";
            this.checkoutToolStripMenuItem.Size = new System.Drawing.Size(102, 29);
            this.checkoutToolStripMenuItem.Text = "Checkout";
            this.checkoutToolStripMenuItem.Click += new System.EventHandler(this.CheckoutToolStripMenuItem_Click);
            // 
            // addNewStockToolStripMenuItem
            // 
            this.addNewStockToolStripMenuItem.Name = "addNewStockToolStripMenuItem";
            this.addNewStockToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.addNewStockToolStripMenuItem.Text = "Add New Stock";
            this.addNewStockToolStripMenuItem.Click += new System.EventHandler(this.AddNewStockToolStripMenuItem_Click);
            // 
            // NavBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.menuStrip);
            this.Name = "NavBar";
            this.Size = new System.Drawing.Size(971, 67);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem inventoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewInventoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categoriesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewItemCategoryListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewCategoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewStockToolStripMenuItem;
    }
}
