namespace inventory
{
    partial class AddItemWindow
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
            this.new_item_btn = new System.Windows.Forms.Button();
            this.inventoryDataSet = new inventory.inventoryDataSet();
            this.barcodeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.barcodeTableAdapter = new inventory.inventoryDataSetTableAdapters.BarcodeTableAdapter();
            this.item_name = new System.Windows.Forms.TextBox();
            this.item_desc = new System.Windows.Forms.TextBox();
            this.item_category = new System.Windows.Forms.ComboBox();
            this.item_company = new System.Windows.Forms.TextBox();
            this.price = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barcodeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // new_item_btn
            // 
            this.new_item_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.new_item_btn.Location = new System.Drawing.Point(492, 636);
            this.new_item_btn.Name = "new_item_btn";
            this.new_item_btn.Size = new System.Drawing.Size(160, 44);
            this.new_item_btn.TabIndex = 11;
            this.new_item_btn.Text = "Add Item";
            this.new_item_btn.UseVisualStyleBackColor = true;
            this.new_item_btn.Click += new System.EventHandler(this.New_item_btn_Click);
            // 
            // inventoryDataSet
            // 
            this.inventoryDataSet.DataSetName = "inventoryDataSet";
            this.inventoryDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // barcodeBindingSource
            // 
            this.barcodeBindingSource.DataMember = "Barcode";
            this.barcodeBindingSource.DataSource = this.inventoryDataSet;
            // 
            // barcodeTableAdapter
            // 
            this.barcodeTableAdapter.ClearBeforeFill = true;
            // 
            // item_name
            // 
            this.item_name.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.item_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.item_name.Location = new System.Drawing.Point(560, 130);
            this.item_name.Name = "item_name";
            this.item_name.Size = new System.Drawing.Size(550, 39);
            this.item_name.TabIndex = 26;
            // 
            // item_desc
            // 
            this.item_desc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.item_desc.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.item_desc.Location = new System.Drawing.Point(560, 209);
            this.item_desc.Name = "item_desc";
            this.item_desc.Size = new System.Drawing.Size(550, 39);
            this.item_desc.TabIndex = 27;
            // 
            // item_company
            // 
            this.item_company.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.item_company.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.item_company.Location = new System.Drawing.Point(560, 296);
            this.item_company.Name = "item_company";
            this.item_company.Size = new System.Drawing.Size(550, 39);
            this.item_company.TabIndex = 28;
            // 
            // item_category
            // 
            this.item_category.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.item_category.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.item_category.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.item_category.FormattingEnabled = true;
            this.item_category.Location = new System.Drawing.Point(560, 378);
            this.item_category.Name = "item_category";
            this.item_category.Size = new System.Drawing.Size(432, 40);
            this.item_category.TabIndex = 29;
            // 
            // price
            // 
            this.price.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.price.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.price.Location = new System.Drawing.Point(560, 461);
            this.price.Name = "price";
            this.price.Size = new System.Drawing.Size(201, 39);
            this.price.TabIndex = 30;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(164, 463);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(174, 37);
            this.label5.TabIndex = 25;
            this.label5.Text = "Enter Price";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(164, 378);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(231, 37);
            this.label4.TabIndex = 24;
            this.label4.Text = "Enter Category";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(164, 296);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(334, 37);
            this.label3.TabIndex = 23;
            this.label3.Text = "Enter Company Name";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(164, 209);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(332, 37);
            this.label2.TabIndex = 22;
            this.label2.Text = "Enter Item Description";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(164, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(258, 37);
            this.label1.TabIndex = 21;
            this.label1.Text = "Enter Item Name";
            // 
            // AddItemWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 701);
            this.Controls.Add(this.item_name);
            this.Controls.Add(this.item_desc);
            this.Controls.Add(this.item_category);
            this.Controls.Add(this.item_company);
            this.Controls.Add(this.price);
            this.Controls.Add(this.new_item_btn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddItemWindow";
            this.Text = "Add New Item";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.inventoryDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barcodeBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button new_item_btn;
        private inventoryDataSet inventoryDataSet;
        private System.Windows.Forms.BindingSource barcodeBindingSource;
        private inventoryDataSetTableAdapters.BarcodeTableAdapter barcodeTableAdapter;
        private System.Windows.Forms.ComboBox item_category;
        private System.Windows.Forms.TextBox item_desc;
        private System.Windows.Forms.TextBox item_company;
        private System.Windows.Forms.TextBox price;
        private System.Windows.Forms.TextBox item_name;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}

