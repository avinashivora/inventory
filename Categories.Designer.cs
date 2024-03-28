namespace inventory
{
    partial class Categories
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
            this.components = new System.ComponentModel.Container();
            this.categories_dataGrid = new System.Windows.Forms.DataGridView();
            this.inventoryDataSet = new inventory.inventoryDataSet();
            this.inventoryDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.navBar1 = new inventory.NavBar();
            this.c_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.c_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.update = new System.Windows.Forms.DataGridViewLinkColumn();
            this.del = new System.Windows.Forms.DataGridViewLinkColumn();
            ((System.ComponentModel.ISupportInitialize)(this.categories_dataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // categories_dataGrid
            // 
            this.categories_dataGrid.AllowUserToAddRows = false;
            this.categories_dataGrid.AllowUserToDeleteRows = false;
            this.categories_dataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.categories_dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.categories_dataGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.c_name,
            this.c_id,
            this.update,
            this.del});
            this.categories_dataGrid.Location = new System.Drawing.Point(0, 75);
            this.categories_dataGrid.Name = "categories_dataGrid";
            this.categories_dataGrid.ReadOnly = true;
            this.categories_dataGrid.RowHeadersWidth = 62;
            this.categories_dataGrid.RowTemplate.Height = 28;
            this.categories_dataGrid.Size = new System.Drawing.Size(1086, 569);
            this.categories_dataGrid.TabIndex = 0;
            this.categories_dataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Categories_dataGrid_CellContentClick);
            // 
            // inventoryDataSet
            // 
            this.inventoryDataSet.DataSetName = "inventoryDataSet";
            this.inventoryDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // inventoryDataSetBindingSource
            // 
            this.inventoryDataSetBindingSource.DataSource = this.inventoryDataSet;
            this.inventoryDataSetBindingSource.Position = 0;
            // 
            // navBar1
            // 
            this.navBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.navBar1.Location = new System.Drawing.Point(0, 2);
            this.navBar1.Name = "navBar1";
            this.navBar1.Size = new System.Drawing.Size(1086, 67);
            this.navBar1.TabIndex = 1;
            // 
            // c_name
            // 
            this.c_name.DataPropertyName = "c_name";
            this.c_name.HeaderText = "Category";
            this.c_name.MinimumWidth = 8;
            this.c_name.Name = "c_name";
            this.c_name.ReadOnly = true;
            this.c_name.Width = 150;
            // 
            // c_id
            // 
            this.c_id.DataPropertyName = "c_id";
            this.c_id.HeaderText = "c_id";
            this.c_id.MinimumWidth = 8;
            this.c_id.Name = "c_id";
            this.c_id.ReadOnly = true;
            this.c_id.Visible = false;
            this.c_id.Width = 150;
            // 
            // update
            // 
            this.update.HeaderText = "Update";
            this.update.MinimumWidth = 8;
            this.update.Name = "update";
            this.update.ReadOnly = true;
            this.update.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.update.Text = "Update Category";
            this.update.UseColumnTextForLinkValue = true;
            this.update.Width = 150;
            // 
            // del
            // 
            this.del.HeaderText = "Delete";
            this.del.MinimumWidth = 8;
            this.del.Name = "del";
            this.del.ReadOnly = true;
            this.del.Text = "Delete Category";
            this.del.UseColumnTextForLinkValue = true;
            this.del.Width = 150;
            // 
            // Categories
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1086, 644);
            this.Controls.Add(this.navBar1);
            this.Controls.Add(this.categories_dataGrid);
            this.Name = "Categories";
            this.Text = "Categories";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Categories_Load);
            ((System.ComponentModel.ISupportInitialize)(this.categories_dataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView categories_dataGrid;
        private System.Windows.Forms.BindingSource inventoryDataSetBindingSource;
        private inventoryDataSet inventoryDataSet;
        private NavBar navBar1;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn c_id;
        private System.Windows.Forms.DataGridViewLinkColumn update;
        private System.Windows.Forms.DataGridViewLinkColumn del;
    }
}