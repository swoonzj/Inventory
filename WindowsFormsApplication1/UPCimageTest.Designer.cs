namespace Inventory
{
    partial class UPCimageTest
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
            this.picUPC = new System.Windows.Forms.PictureBox();
            this.txtUPC = new System.Windows.Forms.TextBox();
            this.btnChange = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picUPC)).BeginInit();
            this.SuspendLayout();
            // 
            // picUPC
            // 
            this.picUPC.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.picUPC.Location = new System.Drawing.Point(50, 39);
            this.picUPC.Name = "picUPC";
            this.picUPC.Size = new System.Drawing.Size(257, 211);
            this.picUPC.TabIndex = 0;
            this.picUPC.TabStop = false;
            // 
            // txtUPC
            // 
            this.txtUPC.Location = new System.Drawing.Point(404, 63);
            this.txtUPC.Name = "txtUPC";
            this.txtUPC.Size = new System.Drawing.Size(100, 20);
            this.txtUPC.TabIndex = 1;
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(404, 95);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(100, 23);
            this.btnChange.TabIndex = 2;
            this.btnChange.Text = "Change UPC";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(404, 153);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(100, 23);
            this.btnPrint.TabIndex = 3;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // UPCimageTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 262);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.txtUPC);
            this.Controls.Add(this.picUPC);
            this.Name = "UPCimageTest";
            this.Text = "UPCimageTest";
            this.Load += new System.EventHandler(this.UPCimageTest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picUPC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picUPC;
        private System.Windows.Forms.TextBox txtUPC;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Button btnPrint;
    }
}