namespace inventory
{
    partial class QuantityInputDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.num = new System.Windows.Forms.NumericUpDown();
            this.stock_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.num)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(117, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(504, 37);
            this.label1.TabIndex = 22;
            this.label1.Text = "Enter Quantity of Stock Added for ";
            // 
            // num
            // 
            this.num.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.num.Location = new System.Drawing.Point(309, 162);
            this.num.Name = "num";
            this.num.Size = new System.Drawing.Size(147, 39);
            this.num.TabIndex = 23;
            // 
            // stock_btn
            // 
            this.stock_btn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.stock_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stock_btn.Location = new System.Drawing.Point(292, 253);
            this.stock_btn.Name = "stock_btn";
            this.stock_btn.Size = new System.Drawing.Size(186, 51);
            this.stock_btn.TabIndex = 24;
            this.stock_btn.Text = "Add Stock";
            this.stock_btn.UseVisualStyleBackColor = true;
            this.stock_btn.Click += new System.EventHandler(this.Stock_btn_Click);
            // 
            // QuantityInputDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 364);
            this.Controls.Add(this.stock_btn);
            this.Controls.Add(this.num);
            this.Controls.Add(this.label1);
            this.Name = "QuantityInputDialog";
            this.Text = "Add New Stock";
            ((System.ComponentModel.ISupportInitialize)(this.num)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown num;
        private System.Windows.Forms.Button stock_btn;
    }
}