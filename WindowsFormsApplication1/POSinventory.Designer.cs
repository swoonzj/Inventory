namespace Inventory
{
    partial class POSinventory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(POSinventory));
            this.lvResults = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSystem = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colInventory = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTradeCash = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTradeCredit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.butAddCart = new System.Windows.Forms.Button();
            this.btnAddTrade = new System.Windows.Forms.Button();
            this.chkHideZero = new System.Windows.Forms.CheckBox();
            this.searchTimer = new System.Windows.Forms.Timer(this.components);
            this.boxCart = new System.Windows.Forms.GroupBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.lblCartTotal = new System.Windows.Forms.Label();
            this.btnCheckout = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lvCart = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colQuantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colItemTotal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.boxTrade = new System.Windows.Forms.GroupBox();
            this.btnEditTradeCart = new System.Windows.Forms.Button();
            this.btnRemoveTrade = new System.Windows.Forms.Button();
            this.btnCreditCheckout = new System.Windows.Forms.Button();
            this.lvTradeCart = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColCash = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCredit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblCreditTotal = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnCashCheckout = new System.Windows.Forms.Button();
            this.lblCashTotal = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.definitelyQuitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forSeriousToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openManagementScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewInventoryItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printUPCLabelsAfterTradeTransactionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClearSearchBox = new System.Windows.Forms.Button();
            this.boxCart.SuspendLayout();
            this.boxTrade.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvResults
            // 
            this.lvResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvResults.CheckBoxes = true;
            this.lvResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colSystem,
            this.colPrice,
            this.colInventory,
            this.colTradeCash,
            this.colTradeCredit});
            this.lvResults.GridLines = true;
            this.lvResults.Location = new System.Drawing.Point(12, 98);
            this.lvResults.Name = "lvResults";
            this.lvResults.Size = new System.Drawing.Size(686, 683);
            this.lvResults.TabIndex = 0;
            this.lvResults.UseCompatibleStateImageBehavior = false;
            this.lvResults.View = System.Windows.Forms.View.Details;
            this.lvResults.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress);
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 256;
            // 
            // colSystem
            // 
            this.colSystem.Text = "System";
            this.colSystem.Width = 101;
            // 
            // colPrice
            // 
            this.colPrice.Text = "Price";
            this.colPrice.Width = 78;
            // 
            // colInventory
            // 
            this.colInventory.Text = "# In Stock";
            this.colInventory.Width = 64;
            // 
            // colTradeCash
            // 
            this.colTradeCash.Text = "Trade: Cash";
            this.colTradeCash.Width = 71;
            // 
            // colTradeCredit
            // 
            this.colTradeCredit.Text = "Trade: Store Credit";
            this.colTradeCredit.Width = 112;
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(160, 35);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(560, 26);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 37);
            this.label1.TabIndex = 2;
            this.label1.Text = "Search:";
            // 
            // butAddCart
            // 
            this.butAddCart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butAddCart.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.butAddCart.Location = new System.Drawing.Point(714, 98);
            this.butAddCart.Name = "butAddCart";
            this.butAddCart.Size = new System.Drawing.Size(131, 76);
            this.butAddCart.TabIndex = 3;
            this.butAddCart.Text = "Add to Cart";
            this.butAddCart.UseVisualStyleBackColor = true;
            this.butAddCart.Click += new System.EventHandler(this.butAddCart_Click);
            // 
            // btnAddTrade
            // 
            this.btnAddTrade.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddTrade.Location = new System.Drawing.Point(714, 189);
            this.btnAddTrade.Name = "btnAddTrade";
            this.btnAddTrade.Size = new System.Drawing.Size(131, 31);
            this.btnAddTrade.TabIndex = 4;
            this.btnAddTrade.Text = "Add to Trade";
            this.btnAddTrade.UseVisualStyleBackColor = true;
            this.btnAddTrade.Click += new System.EventHandler(this.btnAddTrade_Click);
            // 
            // chkHideZero
            // 
            this.chkHideZero.AutoSize = true;
            this.chkHideZero.Checked = true;
            this.chkHideZero.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkHideZero.Location = new System.Drawing.Point(12, 75);
            this.chkHideZero.Name = "chkHideZero";
            this.chkHideZero.Size = new System.Drawing.Size(174, 17);
            this.chkHideZero.TabIndex = 5;
            this.chkHideZero.Text = "Hide Items That Aren\'t In Stock";
            this.chkHideZero.UseVisualStyleBackColor = true;
            this.chkHideZero.CheckedChanged += new System.EventHandler(this.chkHideZero_CheckedChanged);
            // 
            // searchTimer
            // 
            this.searchTimer.Interval = 1000;
            this.searchTimer.Tick += new System.EventHandler(this.searchTimer_Tick);
            // 
            // boxCart
            // 
            this.boxCart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.boxCart.Controls.Add(this.btnEdit);
            this.boxCart.Controls.Add(this.lblCartTotal);
            this.boxCart.Controls.Add(this.btnCheckout);
            this.boxCart.Controls.Add(this.btnRemove);
            this.boxCart.Controls.Add(this.label5);
            this.boxCart.Controls.Add(this.lvCart);
            this.boxCart.Location = new System.Drawing.Point(853, 27);
            this.boxCart.Name = "boxCart";
            this.boxCart.Size = new System.Drawing.Size(716, 333);
            this.boxCart.TabIndex = 7;
            this.boxCart.TabStop = false;
            this.boxCart.Text = "Cart";
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Location = new System.Drawing.Point(580, 20);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(108, 24);
            this.btnEdit.TabIndex = 24;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // lblCartTotal
            // 
            this.lblCartTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCartTotal.AutoSize = true;
            this.lblCartTotal.Font = new System.Drawing.Font("Cambria", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCartTotal.Location = new System.Drawing.Point(130, 281);
            this.lblCartTotal.Name = "lblCartTotal";
            this.lblCartTotal.Size = new System.Drawing.Size(81, 37);
            this.lblCartTotal.TabIndex = 23;
            this.lblCartTotal.Text = "0.00";
            // 
            // btnCheckout
            // 
            this.btnCheckout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheckout.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCheckout.Location = new System.Drawing.Point(573, 275);
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Size = new System.Drawing.Size(128, 43);
            this.btnCheckout.TabIndex = 21;
            this.btnCheckout.Text = "Checkout";
            this.btnCheckout.UseVisualStyleBackColor = true;
            this.btnCheckout.Click += new System.EventHandler(this.btnCheckout_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemove.Location = new System.Drawing.Point(580, 50);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(108, 24);
            this.btnRemove.TabIndex = 20;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.butRemove_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Cambria", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 281);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 37);
            this.label5.TabIndex = 19;
            this.label5.Text = "Total: ";
            // 
            // lvCart
            // 
            this.lvCart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lvCart.CheckBoxes = true;
            this.lvCart.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.colQuantity,
            this.colItemTotal});
            this.lvCart.FullRowSelect = true;
            this.lvCart.GridLines = true;
            this.lvCart.Location = new System.Drawing.Point(13, 19);
            this.lvCart.Name = "lvCart";
            this.lvCart.Size = new System.Drawing.Size(522, 259);
            this.lvCart.TabIndex = 18;
            this.lvCart.UseCompatibleStateImageBehavior = false;
            this.lvCart.View = System.Windows.Forms.View.Details;
            this.lvCart.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 221;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "System";
            this.columnHeader2.Width = 114;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Price";
            // 
            // colQuantity
            // 
            this.colQuantity.Text = "Quantity";
            // 
            // colItemTotal
            // 
            this.colItemTotal.Text = "Item Total";
            // 
            // boxTrade
            // 
            this.boxTrade.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.boxTrade.Controls.Add(this.btnEditTradeCart);
            this.boxTrade.Controls.Add(this.btnRemoveTrade);
            this.boxTrade.Controls.Add(this.btnCreditCheckout);
            this.boxTrade.Controls.Add(this.lvTradeCart);
            this.boxTrade.Controls.Add(this.lblCreditTotal);
            this.boxTrade.Controls.Add(this.label9);
            this.boxTrade.Controls.Add(this.btnCashCheckout);
            this.boxTrade.Controls.Add(this.lblCashTotal);
            this.boxTrade.Controls.Add(this.label11);
            this.boxTrade.Location = new System.Drawing.Point(853, 375);
            this.boxTrade.Name = "boxTrade";
            this.boxTrade.Size = new System.Drawing.Size(716, 406);
            this.boxTrade.TabIndex = 34;
            this.boxTrade.TabStop = false;
            this.boxTrade.Text = "Trade";
            // 
            // btnEditTradeCart
            // 
            this.btnEditTradeCart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditTradeCart.Location = new System.Drawing.Point(580, 19);
            this.btnEditTradeCart.Name = "btnEditTradeCart";
            this.btnEditTradeCart.Size = new System.Drawing.Size(108, 24);
            this.btnEditTradeCart.TabIndex = 26;
            this.btnEditTradeCart.Text = "Edit";
            this.btnEditTradeCart.UseVisualStyleBackColor = true;
            this.btnEditTradeCart.Click += new System.EventHandler(this.btnEditTradeCart_Click);
            // 
            // btnRemoveTrade
            // 
            this.btnRemoveTrade.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveTrade.Location = new System.Drawing.Point(580, 49);
            this.btnRemoveTrade.Name = "btnRemoveTrade";
            this.btnRemoveTrade.Size = new System.Drawing.Size(108, 24);
            this.btnRemoveTrade.TabIndex = 25;
            this.btnRemoveTrade.Text = "Remove";
            this.btnRemoveTrade.UseVisualStyleBackColor = true;
            this.btnRemoveTrade.Click += new System.EventHandler(this.btnRemoveTrade_Click);
            // 
            // btnCreditCheckout
            // 
            this.btnCreditCheckout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreditCheckout.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreditCheckout.Location = new System.Drawing.Point(562, 353);
            this.btnCreditCheckout.Name = "btnCreditCheckout";
            this.btnCreditCheckout.Size = new System.Drawing.Size(139, 37);
            this.btnCreditCheckout.TabIndex = 35;
            this.btnCreditCheckout.Text = "Credit Checkout";
            this.btnCreditCheckout.UseVisualStyleBackColor = true;
            this.btnCreditCheckout.Click += new System.EventHandler(this.btnCreditCheckout_Click);
            // 
            // lvTradeCart
            // 
            this.lvTradeCart.CheckBoxes = true;
            this.lvTradeCart.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.ColCash,
            this.colCredit});
            this.lvTradeCart.FullRowSelect = true;
            this.lvTradeCart.GridLines = true;
            this.lvTradeCart.Location = new System.Drawing.Point(13, 19);
            this.lvTradeCart.Name = "lvTradeCart";
            this.lvTradeCart.Size = new System.Drawing.Size(522, 288);
            this.lvTradeCart.TabIndex = 26;
            this.lvTradeCart.UseCompatibleStateImageBehavior = false;
            this.lvTradeCart.View = System.Windows.Forms.View.Details;
            this.lvTradeCart.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.KeyPress);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Name";
            this.columnHeader4.Width = 218;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "System";
            this.columnHeader5.Width = 120;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Quantity";
            this.columnHeader6.Width = 64;
            // 
            // ColCash
            // 
            this.ColCash.Text = "Cash";
            this.ColCash.Width = 55;
            // 
            // colCredit
            // 
            this.colCredit.Text = "Credit";
            // 
            // lblCreditTotal
            // 
            this.lblCreditTotal.AutoSize = true;
            this.lblCreditTotal.Font = new System.Drawing.Font("Cambria", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreditTotal.Location = new System.Drawing.Point(340, 353);
            this.lblCreditTotal.Name = "lblCreditTotal";
            this.lblCreditTotal.Size = new System.Drawing.Size(81, 37);
            this.lblCreditTotal.TabIndex = 33;
            this.lblCreditTotal.Text = "0.00";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Cambria", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(23, 353);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(290, 37);
            this.label9.TabIndex = 32;
            this.label9.Text = "Store Credit Total: ";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCashCheckout
            // 
            this.btnCashCheckout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCashCheckout.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCashCheckout.Location = new System.Drawing.Point(562, 310);
            this.btnCashCheckout.Name = "btnCashCheckout";
            this.btnCashCheckout.Size = new System.Drawing.Size(139, 37);
            this.btnCashCheckout.TabIndex = 30;
            this.btnCashCheckout.Text = "Cash Checkout";
            this.btnCashCheckout.UseVisualStyleBackColor = true;
            this.btnCashCheckout.Click += new System.EventHandler(this.btnCashCheckout_Click);
            // 
            // lblCashTotal
            // 
            this.lblCashTotal.AutoSize = true;
            this.lblCashTotal.Font = new System.Drawing.Font("Cambria", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCashTotal.Location = new System.Drawing.Point(340, 310);
            this.lblCashTotal.Name = "lblCashTotal";
            this.lblCashTotal.Size = new System.Drawing.Size(81, 37);
            this.lblCashTotal.TabIndex = 28;
            this.lblCashTotal.Text = "0.00";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Cambria", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(130, 310);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(183, 37);
            this.label11.TabIndex = 27;
            this.label11.Text = "Cash Total: ";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.manageToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1581, 24);
            this.menuStrip1.TabIndex = 35;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.definitelyQuitToolStripMenuItem});
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(97, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // definitelyQuitToolStripMenuItem
            // 
            this.definitelyQuitToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.forSeriousToolStripMenuItem});
            this.definitelyQuitToolStripMenuItem.Name = "definitelyQuitToolStripMenuItem";
            this.definitelyQuitToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.definitelyQuitToolStripMenuItem.Text = "Definitely Quit";
            // 
            // forSeriousToolStripMenuItem
            // 
            this.forSeriousToolStripMenuItem.Name = "forSeriousToolStripMenuItem";
            this.forSeriousToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.forSeriousToolStripMenuItem.Text = "For Serious.";
            this.forSeriousToolStripMenuItem.Click += new System.EventHandler(this.forSeriousToolStripMenuItem_Click);
            // 
            // manageToolStripMenuItem
            // 
            this.manageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openManagementScreenToolStripMenuItem,
            this.addNewInventoryItemToolStripMenuItem});
            this.manageToolStripMenuItem.Name = "manageToolStripMenuItem";
            this.manageToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.manageToolStripMenuItem.Text = "Manage";
            // 
            // openManagementScreenToolStripMenuItem
            // 
            this.openManagementScreenToolStripMenuItem.Name = "openManagementScreenToolStripMenuItem";
            this.openManagementScreenToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.openManagementScreenToolStripMenuItem.Text = "Open Management Screen";
            this.openManagementScreenToolStripMenuItem.Click += new System.EventHandler(this.openManagementScreenToolStripMenuItem_Click);
            // 
            // addNewInventoryItemToolStripMenuItem
            // 
            this.addNewInventoryItemToolStripMenuItem.Name = "addNewInventoryItemToolStripMenuItem";
            this.addNewInventoryItemToolStripMenuItem.Size = new System.Drawing.Size(215, 22);
            this.addNewInventoryItemToolStripMenuItem.Text = "Add New Inventory Item";
            this.addNewInventoryItemToolStripMenuItem.Click += new System.EventHandler(this.addNewInventoryItemToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.printUPCLabelsAfterTradeTransactionToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // printUPCLabelsAfterTradeTransactionToolStripMenuItem
            // 
            this.printUPCLabelsAfterTradeTransactionToolStripMenuItem.CheckOnClick = true;
            this.printUPCLabelsAfterTradeTransactionToolStripMenuItem.Name = "printUPCLabelsAfterTradeTransactionToolStripMenuItem";
            this.printUPCLabelsAfterTradeTransactionToolStripMenuItem.Size = new System.Drawing.Size(288, 22);
            this.printUPCLabelsAfterTradeTransactionToolStripMenuItem.Text = "Print UPC Labels After Trade Transaction";
            this.printUPCLabelsAfterTradeTransactionToolStripMenuItem.Click += new System.EventHandler(this.printUPCLabelsAfterTradeTransactionToolStripMenuItem_Click);
            // 
            // btnClearSearchBox
            // 
            this.btnClearSearchBox.Location = new System.Drawing.Point(136, 35);
            this.btnClearSearchBox.Name = "btnClearSearchBox";
            this.btnClearSearchBox.Size = new System.Drawing.Size(18, 26);
            this.btnClearSearchBox.TabIndex = 36;
            this.btnClearSearchBox.Text = "X";
            this.btnClearSearchBox.UseVisualStyleBackColor = true;
            this.btnClearSearchBox.Click += new System.EventHandler(this.btnClearSearchBox_Click);
            // 
            // POSinventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(1581, 805);
            this.Controls.Add(this.btnClearSearchBox);
            this.Controls.Add(this.boxTrade);
            this.Controls.Add(this.boxCart);
            this.Controls.Add(this.chkHideZero);
            this.Controls.Add(this.btnAddTrade);
            this.Controls.Add(this.butAddCart);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lvResults);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "POSinventory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "POS";
            this.Load += new System.EventHandler(this.POSinventory_Load);
            this.boxCart.ResumeLayout(false);
            this.boxCart.PerformLayout();
            this.boxTrade.ResumeLayout(false);
            this.boxTrade.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvResults;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colSystem;
        private System.Windows.Forms.ColumnHeader colPrice;
        private System.Windows.Forms.ColumnHeader colInventory;
        private System.Windows.Forms.Button butAddCart;
        private System.Windows.Forms.ColumnHeader colTradeCash;
        private System.Windows.Forms.ColumnHeader colTradeCredit;
        private System.Windows.Forms.Button btnAddTrade;
        private System.Windows.Forms.CheckBox chkHideZero;
        private System.Windows.Forms.Timer searchTimer;
        private System.Windows.Forms.GroupBox boxCart;
        private System.Windows.Forms.Label lblCartTotal;
        private System.Windows.Forms.Button btnCheckout;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListView lvCart;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader colQuantity;
        private System.Windows.Forms.ColumnHeader colItemTotal;
        private System.Windows.Forms.GroupBox boxTrade;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openManagementScreenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewInventoryItemToolStripMenuItem;
        private System.Windows.Forms.Button btnCreditCheckout;
        private System.Windows.Forms.ListView lvTradeCart;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader ColCash;
        private System.Windows.Forms.ColumnHeader colCredit;
        private System.Windows.Forms.Label lblCreditTotal;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnCashCheckout;
        private System.Windows.Forms.Label lblCashTotal;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ToolStripMenuItem definitelyQuitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem forSeriousToolStripMenuItem;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnEditTradeCart;
        private System.Windows.Forms.Button btnRemoveTrade;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem printUPCLabelsAfterTradeTransactionToolStripMenuItem;
        private System.Windows.Forms.Button btnClearSearchBox;
    }
}