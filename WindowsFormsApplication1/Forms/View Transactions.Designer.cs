namespace Inventory
{
    partial class View_Transactions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(View_Transactions));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblYearlyTotal = new System.Windows.Forms.Label();
            this.lblYearlyTrade = new System.Windows.Forms.Label();
            this.lblYearlySales = new System.Windows.Forms.Label();
            this.lblMonthlyTotal = new System.Windows.Forms.Label();
            this.lblMonthlyTrade = new System.Windows.Forms.Label();
            this.lblMonthlySales = new System.Windows.Forms.Label();
            this.lblDailyTotal = new System.Windows.Forms.Label();
            this.lblDailyTrade = new System.Windows.Forms.Label();
            this.lblDailySales = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape3 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape2 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.lvTransactions = new System.Windows.Forms.ListView();
            this.colTransactionNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSystem = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colQuantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colType2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDate2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvBestsellers = new System.Windows.Forms.ListView();
            this.colName2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSystem2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colQuantity2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transactionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bestSellingItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.showInventoryValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mostTradedCashToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mostTradedCreditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mostTradedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 23);
            this.label1.TabIndex = 28;
            this.label1.Text = "Daily Sales:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.SkyBlue;
            this.groupBox1.Controls.Add(this.lblYearlyTotal);
            this.groupBox1.Controls.Add(this.lblYearlyTrade);
            this.groupBox1.Controls.Add(this.lblYearlySales);
            this.groupBox1.Controls.Add(this.lblMonthlyTotal);
            this.groupBox1.Controls.Add(this.lblMonthlyTrade);
            this.groupBox1.Controls.Add(this.lblMonthlySales);
            this.groupBox1.Controls.Add(this.lblDailyTotal);
            this.groupBox1.Controls.Add(this.lblDailyTrade);
            this.groupBox1.Controls.Add(this.lblDailySales);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.shapeContainer1);
            this.groupBox1.Location = new System.Drawing.Point(864, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(295, 671);
            this.groupBox1.TabIndex = 29;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data";
            // 
            // lblYearlyTotal
            // 
            this.lblYearlyTotal.AutoSize = true;
            this.lblYearlyTotal.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYearlyTotal.Location = new System.Drawing.Point(192, 416);
            this.lblYearlyTotal.Name = "lblYearlyTotal";
            this.lblYearlyTotal.Size = new System.Drawing.Size(75, 22);
            this.lblYearlyTotal.TabIndex = 48;
            this.lblYearlyTotal.Text = "label14";
            // 
            // lblYearlyTrade
            // 
            this.lblYearlyTrade.AutoSize = true;
            this.lblYearlyTrade.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYearlyTrade.ForeColor = System.Drawing.Color.Red;
            this.lblYearlyTrade.Location = new System.Drawing.Point(192, 376);
            this.lblYearlyTrade.Name = "lblYearlyTrade";
            this.lblYearlyTrade.Size = new System.Drawing.Size(75, 22);
            this.lblYearlyTrade.TabIndex = 47;
            this.lblYearlyTrade.Text = "label10";
            // 
            // lblYearlySales
            // 
            this.lblYearlySales.AutoSize = true;
            this.lblYearlySales.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYearlySales.ForeColor = System.Drawing.Color.Green;
            this.lblYearlySales.Location = new System.Drawing.Point(192, 340);
            this.lblYearlySales.Name = "lblYearlySales";
            this.lblYearlySales.Size = new System.Drawing.Size(75, 22);
            this.lblYearlySales.TabIndex = 46;
            this.lblYearlySales.Text = "label10";
            // 
            // lblMonthlyTotal
            // 
            this.lblMonthlyTotal.AutoSize = true;
            this.lblMonthlyTotal.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonthlyTotal.Location = new System.Drawing.Point(197, 255);
            this.lblMonthlyTotal.Name = "lblMonthlyTotal";
            this.lblMonthlyTotal.Size = new System.Drawing.Size(75, 22);
            this.lblMonthlyTotal.TabIndex = 45;
            this.lblMonthlyTotal.Text = "label11";
            // 
            // lblMonthlyTrade
            // 
            this.lblMonthlyTrade.AutoSize = true;
            this.lblMonthlyTrade.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonthlyTrade.ForeColor = System.Drawing.Color.Red;
            this.lblMonthlyTrade.Location = new System.Drawing.Point(197, 214);
            this.lblMonthlyTrade.Name = "lblMonthlyTrade";
            this.lblMonthlyTrade.Size = new System.Drawing.Size(75, 22);
            this.lblMonthlyTrade.TabIndex = 44;
            this.lblMonthlyTrade.Text = "label10";
            // 
            // lblMonthlySales
            // 
            this.lblMonthlySales.AutoSize = true;
            this.lblMonthlySales.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonthlySales.ForeColor = System.Drawing.Color.Green;
            this.lblMonthlySales.Location = new System.Drawing.Point(197, 179);
            this.lblMonthlySales.Name = "lblMonthlySales";
            this.lblMonthlySales.Size = new System.Drawing.Size(75, 22);
            this.lblMonthlySales.TabIndex = 43;
            this.lblMonthlySales.Text = "label10";
            // 
            // lblDailyTotal
            // 
            this.lblDailyTotal.AutoSize = true;
            this.lblDailyTotal.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDailyTotal.Location = new System.Drawing.Point(193, 105);
            this.lblDailyTotal.Name = "lblDailyTotal";
            this.lblDailyTotal.Size = new System.Drawing.Size(75, 22);
            this.lblDailyTotal.TabIndex = 41;
            this.lblDailyTotal.Text = "label10";
            // 
            // lblDailyTrade
            // 
            this.lblDailyTrade.AutoSize = true;
            this.lblDailyTrade.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDailyTrade.ForeColor = System.Drawing.Color.Red;
            this.lblDailyTrade.Location = new System.Drawing.Point(197, 63);
            this.lblDailyTrade.Name = "lblDailyTrade";
            this.lblDailyTrade.Size = new System.Drawing.Size(75, 22);
            this.lblDailyTrade.TabIndex = 40;
            this.lblDailyTrade.Text = "label10";
            // 
            // lblDailySales
            // 
            this.lblDailySales.AutoSize = true;
            this.lblDailySales.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDailySales.ForeColor = System.Drawing.Color.Green;
            this.lblDailySales.Location = new System.Drawing.Point(197, 28);
            this.lblDailySales.Name = "lblDailySales";
            this.lblDailySales.Size = new System.Drawing.Size(75, 22);
            this.lblDailySales.TabIndex = 39;
            this.lblDailySales.Text = "label10";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Cambria", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(5, 415);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(149, 23);
            this.label7.TabIndex = 38;
            this.label7.Text = "Net Yearly Total:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Cambria", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(5, 375);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(166, 23);
            this.label8.TabIndex = 37;
            this.label8.Text = "Yearly Cash Trade:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Cambria", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(5, 339);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(115, 23);
            this.label9.TabIndex = 36;
            this.label9.Text = "Yearly Sales:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Cambria", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(5, 254);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 23);
            this.label3.TabIndex = 35;
            this.label3.Text = "Net Monthly Total:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cambria", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(5, 214);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(185, 23);
            this.label4.TabIndex = 34;
            this.label4.Text = "Monthly Cash Trade:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Cambria", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(5, 178);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(134, 23);
            this.label6.TabIndex = 33;
            this.label6.Text = "Monthly Sales:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cambria", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(5, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 23);
            this.label5.TabIndex = 32;
            this.label5.Text = "Net Daily Total:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Cambria", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(158, 23);
            this.label2.TabIndex = 29;
            this.label2.Text = "Daily Cash Trade:";
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(3, 16);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape3,
            this.lineShape2,
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(289, 652);
            this.shapeContainer1.TabIndex = 42;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape3
            // 
            this.lineShape3.Name = "lineShape3";
            this.lineShape3.X1 = 8;
            this.lineShape3.X2 = 247;
            this.lineShape3.Y1 = 390;
            this.lineShape3.Y2 = 390;
            // 
            // lineShape2
            // 
            this.lineShape2.Name = "lineShape2";
            this.lineShape2.X1 = 6;
            this.lineShape2.X2 = 245;
            this.lineShape2.Y1 = 231;
            this.lineShape2.Y2 = 231;
            // 
            // lineShape1
            // 
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 8;
            this.lineShape1.X2 = 247;
            this.lineShape1.Y1 = 79;
            this.lineShape1.Y2 = 79;
            // 
            // lvTransactions
            // 
            this.lvTransactions.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvTransactions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvTransactions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTransactionNumber,
            this.colName,
            this.colSystem,
            this.colPrice,
            this.colQuantity,
            this.colType2,
            this.colDate2});
            this.lvTransactions.Location = new System.Drawing.Point(11, 30);
            this.lvTransactions.Name = "lvTransactions";
            this.lvTransactions.Size = new System.Drawing.Size(847, 671);
            this.lvTransactions.TabIndex = 36;
            this.lvTransactions.UseCompatibleStateImageBehavior = false;
            this.lvTransactions.View = System.Windows.Forms.View.Details;
            this.lvTransactions.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvTransactions_ColumnClick);
            // 
            // colTransactionNumber
            // 
            this.colTransactionNumber.Text = "#";
            this.colTransactionNumber.Width = 37;
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 237;
            // 
            // colSystem
            // 
            this.colSystem.Text = "System";
            this.colSystem.Width = 130;
            // 
            // colPrice
            // 
            this.colPrice.Text = "Price";
            this.colPrice.Width = 86;
            // 
            // colQuantity
            // 
            this.colQuantity.Text = "Quantity";
            this.colQuantity.Width = 51;
            // 
            // colType2
            // 
            this.colType2.Text = "Purchase/Trade";
            this.colType2.Width = 118;
            // 
            // colDate2
            // 
            this.colDate2.Text = "Date";
            this.colDate2.Width = 154;
            // 
            // lvBestsellers
            // 
            this.lvBestsellers.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.lvBestsellers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvBestsellers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName2,
            this.colSystem2,
            this.colQuantity2});
            this.lvBestsellers.Location = new System.Drawing.Point(12, 30);
            this.lvBestsellers.Name = "lvBestsellers";
            this.lvBestsellers.Size = new System.Drawing.Size(846, 668);
            this.lvBestsellers.TabIndex = 39;
            this.lvBestsellers.UseCompatibleStateImageBehavior = false;
            this.lvBestsellers.View = System.Windows.Forms.View.Details;
            this.lvBestsellers.Visible = false;
            this.lvBestsellers.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvBestsellers_ColumnClick);
            // 
            // colName2
            // 
            this.colName2.Text = "Name";
            this.colName2.Width = 192;
            // 
            // colSystem2
            // 
            this.colSystem2.Text = "System";
            this.colSystem2.Width = 135;
            // 
            // colQuantity2
            // 
            this.colQuantity2.Text = "Amount Sold";
            this.colQuantity2.Width = 77;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1166, 24);
            this.menuStrip1.TabIndex = 40;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.transactionsToolStripMenuItem,
            this.bestSellingItemsToolStripMenuItem,
            this.toolStripSeparator1,
            this.showInventoryValueToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // transactionsToolStripMenuItem
            // 
            this.transactionsToolStripMenuItem.Name = "transactionsToolStripMenuItem";
            this.transactionsToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.transactionsToolStripMenuItem.Text = "Transactions";
            this.transactionsToolStripMenuItem.Click += new System.EventHandler(this.btnTransactions_Click);
            // 
            // bestSellingItemsToolStripMenuItem
            // 
            this.bestSellingItemsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mostTradedToolStripMenuItem,
            this.mostTradedCashToolStripMenuItem,
            this.mostTradedCreditToolStripMenuItem});
            this.bestSellingItemsToolStripMenuItem.Name = "bestSellingItemsToolStripMenuItem";
            this.bestSellingItemsToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.bestSellingItemsToolStripMenuItem.Text = "Best Selling Items";
            this.bestSellingItemsToolStripMenuItem.Click += new System.EventHandler(this.btnBestselling_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(185, 6);
            // 
            // showInventoryValueToolStripMenuItem
            // 
            this.showInventoryValueToolStripMenuItem.Name = "showInventoryValueToolStripMenuItem";
            this.showInventoryValueToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            this.showInventoryValueToolStripMenuItem.Text = "Show Inventory Value";
            this.showInventoryValueToolStripMenuItem.Click += new System.EventHandler(this.btnInventoryValue_Click);
            // 
            // mostTradedCashToolStripMenuItem
            // 
            this.mostTradedCashToolStripMenuItem.Name = "mostTradedCashToolStripMenuItem";
            this.mostTradedCashToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.mostTradedCashToolStripMenuItem.Text = "Most Traded - Cash";
            this.mostTradedCashToolStripMenuItem.Click += new System.EventHandler(this.mostTradedCashToolStripMenuItem_Click);
            // 
            // mostTradedCreditToolStripMenuItem
            // 
            this.mostTradedCreditToolStripMenuItem.Name = "mostTradedCreditToolStripMenuItem";
            this.mostTradedCreditToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.mostTradedCreditToolStripMenuItem.Text = "Most Traded - Credit";
            this.mostTradedCreditToolStripMenuItem.Click += new System.EventHandler(this.mostTradedCreditToolStripMenuItem_Click);
            // 
            // mostTradedToolStripMenuItem
            // 
            this.mostTradedToolStripMenuItem.Name = "mostTradedToolStripMenuItem";
            this.mostTradedToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.mostTradedToolStripMenuItem.Text = "Most Traded";
            this.mostTradedToolStripMenuItem.Click += new System.EventHandler(this.mostTradedToolStripMenuItem_Click);
            // 
            // View_Transactions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1166, 711);
            this.Controls.Add(this.lvTransactions);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lvBestsellers);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "View_Transactions";
            this.Text = "Transactions";
            this.Load += new System.EventHandler(this.View_Transactions_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblYearlyTotal;
        private System.Windows.Forms.Label lblYearlyTrade;
        private System.Windows.Forms.Label lblYearlySales;
        private System.Windows.Forms.Label lblMonthlyTotal;
        private System.Windows.Forms.Label lblMonthlyTrade;
        private System.Windows.Forms.Label lblMonthlySales;
        private System.Windows.Forms.Label lblDailyTotal;
        private System.Windows.Forms.Label lblDailyTrade;
        private System.Windows.Forms.Label lblDailySales;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape3;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape2;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private System.Windows.Forms.ListView lvTransactions;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colSystem;
        private System.Windows.Forms.ColumnHeader colPrice;
        private System.Windows.Forms.ColumnHeader colType2;
        private System.Windows.Forms.ColumnHeader colDate2;
        private System.Windows.Forms.ColumnHeader colQuantity;
        private System.Windows.Forms.ListView lvBestsellers;
        private System.Windows.Forms.ColumnHeader colName2;
        private System.Windows.Forms.ColumnHeader colSystem2;
        private System.Windows.Forms.ColumnHeader colQuantity2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem transactionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bestSellingItemsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem showInventoryValueToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader colTransactionNumber;
        private System.Windows.Forms.ToolStripMenuItem mostTradedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mostTradedCashToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mostTradedCreditToolStripMenuItem;
    }
}