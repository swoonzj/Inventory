namespace Inventory
{
    partial class EditTradeCart
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
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.btnChangeQuantity = new System.Windows.Forms.Button();
            this.txtChangePrices = new System.Windows.Forms.TextBox();
            this.btnChangeCredit = new System.Windows.Forms.Button();
            this.btnChangeCash = new System.Windows.Forms.Button();
            this.btnChangeTotal = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cambria", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 15);
            this.label4.TabIndex = 51;
            this.label4.Text = "Change Quantity:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 15);
            this.label3.TabIndex = 50;
            this.label3.Text = "Change Prices:";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(13, 29);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(110, 20);
            this.txtQuantity.TabIndex = 49;
            // 
            // btnChangeQuantity
            // 
            this.btnChangeQuantity.Location = new System.Drawing.Point(13, 55);
            this.btnChangeQuantity.Name = "btnChangeQuantity";
            this.btnChangeQuantity.Size = new System.Drawing.Size(108, 23);
            this.btnChangeQuantity.TabIndex = 48;
            this.btnChangeQuantity.Text = "Change Quantity";
            this.btnChangeQuantity.UseVisualStyleBackColor = true;
            this.btnChangeQuantity.Click += new System.EventHandler(this.btnChangeQuantity_Click);
            // 
            // txtChangePrices
            // 
            this.txtChangePrices.Location = new System.Drawing.Point(13, 118);
            this.txtChangePrices.Name = "txtChangePrices";
            this.txtChangePrices.Size = new System.Drawing.Size(110, 20);
            this.txtChangePrices.TabIndex = 47;
            // 
            // btnChangeCredit
            // 
            this.btnChangeCredit.Location = new System.Drawing.Point(13, 173);
            this.btnChangeCredit.Name = "btnChangeCredit";
            this.btnChangeCredit.Size = new System.Drawing.Size(108, 23);
            this.btnChangeCredit.TabIndex = 45;
            this.btnChangeCredit.Text = "Change Credit";
            this.btnChangeCredit.UseVisualStyleBackColor = true;
            this.btnChangeCredit.Click += new System.EventHandler(this.btnChangeCredit_Click);
            // 
            // btnChangeCash
            // 
            this.btnChangeCash.Location = new System.Drawing.Point(13, 144);
            this.btnChangeCash.Name = "btnChangeCash";
            this.btnChangeCash.Size = new System.Drawing.Size(108, 23);
            this.btnChangeCash.TabIndex = 44;
            this.btnChangeCash.Text = "Change Cash";
            this.btnChangeCash.UseVisualStyleBackColor = true;
            this.btnChangeCash.Click += new System.EventHandler(this.btnChangeCash_Click);
            // 
            // btnChangeTotal
            // 
            this.btnChangeTotal.Location = new System.Drawing.Point(13, 202);
            this.btnChangeTotal.Name = "btnChangeTotal";
            this.btnChangeTotal.Size = new System.Drawing.Size(108, 23);
            this.btnChangeTotal.TabIndex = 53;
            this.btnChangeTotal.Text = "Change Total";
            this.btnChangeTotal.UseVisualStyleBackColor = true;
            this.btnChangeTotal.Click += new System.EventHandler(this.btnChangeTotal_Click);
            // 
            // EditTradeCart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(133, 237);
            this.Controls.Add(this.btnChangeTotal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.btnChangeQuantity);
            this.Controls.Add(this.txtChangePrices);
            this.Controls.Add(this.btnChangeCredit);
            this.Controls.Add(this.btnChangeCash);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditTradeCart";
            this.Text = "Edit Trade";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Button btnChangeQuantity;
        private System.Windows.Forms.TextBox txtChangePrices;
        private System.Windows.Forms.Button btnChangeCredit;
        private System.Windows.Forms.Button btnChangeCash;
        private System.Windows.Forms.Button btnChangeTotal;
    }
}