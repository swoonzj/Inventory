namespace Inventory
{
    partial class EditCart
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
            this.btnChangePrice = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.btnChangeQuantity = new System.Windows.Forms.Button();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.btn6for20 = new System.Windows.Forms.Button();
            this.btnDiscountTotal = new System.Windows.Forms.Button();
            this.btnDiscountItem = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnChangePrice
            // 
            this.btnChangePrice.Location = new System.Drawing.Point(11, 248);
            this.btnChangePrice.Name = "btnChangePrice";
            this.btnChangePrice.Size = new System.Drawing.Size(108, 23);
            this.btnChangePrice.TabIndex = 43;
            this.btnChangePrice.Text = "Change Price";
            this.btnChangePrice.UseVisualStyleBackColor = true;
            this.btnChangePrice.Click += new System.EventHandler(this.btnChangePrice_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cambria", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(7, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 15);
            this.label4.TabIndex = 42;
            this.label4.Text = "Change Quantity:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 15);
            this.label3.TabIndex = 41;
            this.label3.Text = "Discounts:";
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(11, 29);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(110, 20);
            this.txtQuantity.TabIndex = 40;
            // 
            // btnChangeQuantity
            // 
            this.btnChangeQuantity.Location = new System.Drawing.Point(12, 55);
            this.btnChangeQuantity.Name = "btnChangeQuantity";
            this.btnChangeQuantity.Size = new System.Drawing.Size(108, 23);
            this.btnChangeQuantity.TabIndex = 39;
            this.btnChangeQuantity.Text = "Change Quantity";
            this.btnChangeQuantity.UseVisualStyleBackColor = true;
            this.btnChangeQuantity.Click += new System.EventHandler(this.btnChangeQuantity_Click);
            // 
            // txtDiscount
            // 
            this.txtDiscount.Location = new System.Drawing.Point(11, 166);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(110, 20);
            this.txtDiscount.TabIndex = 37;
            // 
            // btn6for20
            // 
            this.btn6for20.Location = new System.Drawing.Point(12, 119);
            this.btn6for20.Name = "btn6for20";
            this.btn6for20.Size = new System.Drawing.Size(109, 32);
            this.btn6for20.TabIndex = 36;
            this.btn6for20.Text = "6 for $20";
            this.btn6for20.UseVisualStyleBackColor = true;
            // 
            // btnDiscountTotal
            // 
            this.btnDiscountTotal.Location = new System.Drawing.Point(11, 221);
            this.btnDiscountTotal.Name = "btnDiscountTotal";
            this.btnDiscountTotal.Size = new System.Drawing.Size(108, 23);
            this.btnDiscountTotal.TabIndex = 35;
            this.btnDiscountTotal.Text = "Discount Total";
            this.btnDiscountTotal.UseVisualStyleBackColor = true;
            this.btnDiscountTotal.Click += new System.EventHandler(this.btnDiscountTotal_Click);
            // 
            // btnDiscountItem
            // 
            this.btnDiscountItem.Location = new System.Drawing.Point(11, 192);
            this.btnDiscountItem.Name = "btnDiscountItem";
            this.btnDiscountItem.Size = new System.Drawing.Size(108, 23);
            this.btnDiscountItem.TabIndex = 34;
            this.btnDiscountItem.Text = "Discount Item";
            this.btnDiscountItem.UseVisualStyleBackColor = true;
            this.btnDiscountItem.Click += new System.EventHandler(this.btnDiscountItem_Click);
            // 
            // EditCart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(133, 283);
            this.Controls.Add(this.btnChangePrice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.btnChangeQuantity);
            this.Controls.Add(this.txtDiscount);
            this.Controls.Add(this.btn6for20);
            this.Controls.Add(this.btnDiscountTotal);
            this.Controls.Add(this.btnDiscountItem);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditCart";
            this.Text = "Edit Cart";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnChangePrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtQuantity;
        private System.Windows.Forms.Button btnChangeQuantity;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.Button btn6for20;
        private System.Windows.Forms.Button btnDiscountTotal;
        private System.Windows.Forms.Button btnDiscountItem;
    }
}