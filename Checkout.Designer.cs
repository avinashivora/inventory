namespace inventory
{
    partial class Checkout
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
            this.uploadButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.checkout_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // uploadButton
            // 
            this.uploadButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uploadButton.Location = new System.Drawing.Point(158, 166);
            this.uploadButton.Name = "uploadButton";
            this.uploadButton.Size = new System.Drawing.Size(235, 46);
            this.uploadButton.TabIndex = 0;
            this.uploadButton.Text = "Upload";
            this.uploadButton.UseVisualStyleBackColor = true;
            this.uploadButton.Click += new System.EventHandler(this.UploadButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(71, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(392, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Upload the barcode here";
            // 
            // checkout_btn
            // 
            this.checkout_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkout_btn.Location = new System.Drawing.Point(158, 237);
            this.checkout_btn.Name = "checkout_btn";
            this.checkout_btn.Size = new System.Drawing.Size(235, 46);
            this.checkout_btn.TabIndex = 2;
            this.checkout_btn.Text = "Checkout the Item";
            this.checkout_btn.UseVisualStyleBackColor = true;
            this.checkout_btn.Click += new System.EventHandler(this.Checkout_btn_Click);
            // 
            // Checkout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 320);
            this.Controls.Add(this.checkout_btn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.uploadButton);
            this.Name = "Checkout";
            this.Text = "Checkout";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button uploadButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button checkout_btn;
    }
}