namespace inventory
{
    partial class Home
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.itemsDataGrid = new System.Windows.Forms.DataGridView();
            this.navBar1 = new inventory.NavBar();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.item_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.company = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.catName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.barcode = new System.Windows.Forms.DataGridViewLinkColumn();
            this.update = new System.Windows.Forms.DataGridViewLinkColumn();
            this.del = new System.Windows.Forms.DataGridViewLinkColumn();
            ((System.ComponentModel.ISupportInitialize)(this.itemsDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // itemsDataGrid
            // 
            this.itemsDataGrid.AllowUserToAddRows = false;
            this.itemsDataGrid.AllowUserToDeleteRows = false;
            this.itemsDataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.itemsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.itemsDataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.item_name,
            this.desc,
            this.company,
            this.catName,
            this.quantity,
            this.price,
            this.barcode,
            this.update,
            this.del});
            this.itemsDataGrid.Location = new System.Drawing.Point(5, 53);
            this.itemsDataGrid.Name = "itemsDataGrid";
            this.itemsDataGrid.ReadOnly = true;
            this.itemsDataGrid.RowHeadersWidth = 62;
            this.itemsDataGrid.RowTemplate.Height = 28;
            this.itemsDataGrid.Size = new System.Drawing.Size(1351, 736);
            this.itemsDataGrid.TabIndex = 1;
            this.itemsDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ItemsDataGrid_CellContentClick);
            // 
            // navBar1
            // 
            this.navBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.navBar1.Location = new System.Drawing.Point(12, 2);
            this.navBar1.Name = "navBar1";
            this.navBar1.Size = new System.Drawing.Size(1331, 75);
            this.navBar1.TabIndex = 2;
            // 
            // id
            // 
            this.id.DataPropertyName = "item_id";
            this.id.HeaderText = "id";
            this.id.MinimumWidth = 8;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            this.id.Width = 150;
            // 
            // item_name
            // 
            this.item_name.DataPropertyName = "item_name";
            this.item_name.HeaderText = "Item";
            this.item_name.MinimumWidth = 8;
            this.item_name.Name = "item_name";
            this.item_name.ReadOnly = true;
            this.item_name.Width = 150;
            // 
            // desc
            // 
            this.desc.DataPropertyName = "desc_item";
            this.desc.HeaderText = "Description";
            this.desc.MinimumWidth = 8;
            this.desc.Name = "desc";
            this.desc.ReadOnly = true;
            this.desc.Width = 150;
            // 
            // company
            // 
            this.company.DataPropertyName = "company_name";
            this.company.HeaderText = "Company Name";
            this.company.MinimumWidth = 8;
            this.company.Name = "company";
            this.company.ReadOnly = true;
            this.company.Width = 150;
            // 
            // catName
            // 
            this.catName.DataPropertyName = "category";
            this.catName.HeaderText = "Category";
            this.catName.MinimumWidth = 8;
            this.catName.Name = "catName";
            this.catName.ReadOnly = true;
            this.catName.Width = 150;
            // 
            // quantity
            // 
            this.quantity.DataPropertyName = "quantity";
            this.quantity.HeaderText = "Current Stock";
            this.quantity.MinimumWidth = 8;
            this.quantity.Name = "quantity";
            this.quantity.ReadOnly = true;
            // 
            // price
            // 
            this.price.DataPropertyName = "price";
            this.price.HeaderText = "Price";
            this.price.MinimumWidth = 8;
            this.price.Name = "price";
            this.price.ReadOnly = true;
            this.price.Width = 150;
            // 
            // barcode
            // 
            this.barcode.HeaderText = "Barcode";
            this.barcode.MinimumWidth = 8;
            this.barcode.Name = "barcode";
            this.barcode.ReadOnly = true;
            this.barcode.Text = "Download";
            this.barcode.UseColumnTextForLinkValue = true;
            this.barcode.Width = 150;
            // 
            // update
            // 
            this.update.HeaderText = "Update";
            this.update.MinimumWidth = 8;
            this.update.Name = "update";
            this.update.ReadOnly = true;
            this.update.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.update.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.update.Text = "Update";
            this.update.UseColumnTextForLinkValue = true;
            this.update.Width = 150;
            // 
            // del
            // 
            this.del.HeaderText = "Delete";
            this.del.MinimumWidth = 8;
            this.del.Name = "del";
            this.del.ReadOnly = true;
            this.del.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.del.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.del.Text = "Delete";
            this.del.UseColumnTextForLinkValue = true;
            this.del.Width = 150;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1355, 785);
            this.Controls.Add(this.itemsDataGrid);
            this.Controls.Add(this.navBar1);
            this.Name = "Home";
            this.Text = "Home";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Home_Load);
            ((System.ComponentModel.ISupportInitialize)(this.itemsDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView itemsDataGrid;
        private NavBar navBar1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn item_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn desc;
        private System.Windows.Forms.DataGridViewTextBoxColumn company;
        private System.Windows.Forms.DataGridViewTextBoxColumn catName;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewLinkColumn barcode;
        private System.Windows.Forms.DataGridViewLinkColumn update;
        private System.Windows.Forms.DataGridViewLinkColumn del;
    }
}