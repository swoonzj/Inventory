namespace Inventory
{
    partial class _30DayHold
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(_30DayHold));
            this.lvResults = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSystem = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colQuantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDateEntered = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDateFree = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rdoShowAll = new System.Windows.Forms.RadioButton();
            this.rdoShowReadyToRelease = new System.Windows.Forms.RadioButton();
            this.toolTipDNI = new System.Windows.Forms.ToolTip(this.components);
            this.toolTipSelected = new System.Windows.Forms.ToolTip(this.components);
            this.toolAll = new System.Windows.Forms.ToolTip(this.components);
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAddToSalesFloor = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAddToBackRoom = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.moveCheckedItemsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnUnselectAll = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showReadyToReleaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.colQuantity,
            this.colDateEntered,
            this.colDateFree});
            this.lvResults.GridLines = true;
            this.lvResults.Location = new System.Drawing.Point(16, 132);
            this.lvResults.Name = "lvResults";
            this.lvResults.Size = new System.Drawing.Size(964, 770);
            this.lvResults.TabIndex = 1;
            this.lvResults.UseCompatibleStateImageBehavior = false;
            this.lvResults.View = System.Windows.Forms.View.Details;
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 353;
            // 
            // colSystem
            // 
            this.colSystem.Text = "System";
            this.colSystem.Width = 191;
            // 
            // colQuantity
            // 
            this.colQuantity.Text = "Quantity";
            this.colQuantity.Width = 58;
            // 
            // colDateEntered
            // 
            this.colDateEntered.Text = "Date Entered";
            this.colDateEntered.Width = 157;
            // 
            // colDateFree
            // 
            this.colDateFree.Text = "Date to Release";
            this.colDateFree.Width = 189;
            // 
            // rdoShowAll
            // 
            this.rdoShowAll.AutoSize = true;
            this.rdoShowAll.Checked = true;
            this.rdoShowAll.Location = new System.Drawing.Point(19, 69);
            this.rdoShowAll.Name = "rdoShowAll";
            this.rdoShowAll.Size = new System.Drawing.Size(66, 17);
            this.rdoShowAll.TabIndex = 2;
            this.rdoShowAll.TabStop = true;
            this.rdoShowAll.Text = "Show All";
            this.rdoShowAll.UseVisualStyleBackColor = true;
            // 
            // rdoShowReadyToRelease
            // 
            this.rdoShowReadyToRelease.AutoSize = true;
            this.rdoShowReadyToRelease.Location = new System.Drawing.Point(91, 69);
            this.rdoShowReadyToRelease.Name = "rdoShowReadyToRelease";
            this.rdoShowReadyToRelease.Size = new System.Drawing.Size(140, 17);
            this.rdoShowReadyToRelease.TabIndex = 3;
            this.rdoShowReadyToRelease.Text = "Show Ready to Release";
            this.rdoShowReadyToRelease.UseVisualStyleBackColor = true;
            this.rdoShowReadyToRelease.CheckedChanged += new System.EventHandler(this.rdoShowReadyToRelease_CheckedChanged);
            // 
            // printDocument1
            // 
            this.printDocument1.DocumentName = "30DayHold";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(125, 37);
            this.label1.TabIndex = 9;
            this.label1.Text = "Search:";
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(143, 35);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(837, 26);
            this.txtSearch.TabIndex = 8;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(992, 24);
            this.menuStrip1.TabIndex = 55;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.CheckOnClick = true;
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToToolStripMenuItem,
            this.toolStripSeparator1,
            this.moveCheckedItemsToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(81, 20);
            this.optionsToolStripMenuItem.Text = "Move Items";
            // 
            // addToToolStripMenuItem
            // 
            this.addToToolStripMenuItem.CheckOnClick = true;
            this.addToToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuAddToSalesFloor,
            this.menuAddToBackRoom});
            this.addToToolStripMenuItem.Name = "addToToolStripMenuItem";
            this.addToToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.addToToolStripMenuItem.Text = "Move To...";
            // 
            // menuAddToSalesFloor
            // 
            this.menuAddToSalesFloor.CheckOnClick = true;
            this.menuAddToSalesFloor.Name = "menuAddToSalesFloor";
            this.menuAddToSalesFloor.Size = new System.Drawing.Size(152, 22);
            this.menuAddToSalesFloor.Text = "Sales Floor";
            // 
            // menuAddToBackRoom
            // 
            this.menuAddToBackRoom.CheckOnClick = true;
            this.menuAddToBackRoom.Name = "menuAddToBackRoom";
            this.menuAddToBackRoom.Size = new System.Drawing.Size(152, 22);
            this.menuAddToBackRoom.Text = "Back Room";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(182, 6);
            // 
            // moveCheckedItemsToolStripMenuItem
            // 
            this.moveCheckedItemsToolStripMenuItem.Name = "moveCheckedItemsToolStripMenuItem";
            this.moveCheckedItemsToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.moveCheckedItemsToolStripMenuItem.Text = "Move Checked Items";
            // 
            // btnUnselectAll
            // 
            this.btnUnselectAll.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnselectAll.Location = new System.Drawing.Point(122, 92);
            this.btnUnselectAll.Name = "btnUnselectAll";
            this.btnUnselectAll.Size = new System.Drawing.Size(100, 34);
            this.btnUnselectAll.TabIndex = 57;
            this.btnUnselectAll.Text = "Unselect All";
            this.btnUnselectAll.UseVisualStyleBackColor = true;
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectAll.Location = new System.Drawing.Point(16, 92);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(100, 34);
            this.btnSelectAll.TabIndex = 56;
            this.btnSelectAll.Text = "Select All";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showAllToolStripMenuItem,
            this.showReadyToReleaseToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // showAllToolStripMenuItem
            // 
            this.showAllToolStripMenuItem.Name = "showAllToolStripMenuItem";
            this.showAllToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.showAllToolStripMenuItem.Text = "Show All";
            // 
            // showReadyToReleaseToolStripMenuItem
            // 
            this.showReadyToReleaseToolStripMenuItem.Name = "showReadyToReleaseToolStripMenuItem";
            this.showReadyToReleaseToolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            this.showReadyToReleaseToolStripMenuItem.Text = "Show Ready to Release";
            // 
            // _30DayHold
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 914);
            this.Controls.Add(this.btnUnselectAll);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.rdoShowReadyToRelease);
            this.Controls.Add(this.rdoShowAll);
            this.Controls.Add(this.lvResults);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "_30DayHold";
            this.Text = "30 Day Hold";
            this.Load += new System.EventHandler(this._30DayHold_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvResults;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colSystem;
        private System.Windows.Forms.ColumnHeader colDateEntered;
        private System.Windows.Forms.ColumnHeader colDateFree;
        private System.Windows.Forms.RadioButton rdoShowAll;
        private System.Windows.Forms.RadioButton rdoShowReadyToRelease;
        private System.Windows.Forms.ColumnHeader colQuantity;
        private System.Windows.Forms.ToolTip toolTipDNI;
        private System.Windows.Forms.ToolTip toolAll;
        private System.Windows.Forms.ToolTip toolTipSelected;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem menuAddToSalesFloor;
        private System.Windows.Forms.ToolStripMenuItem menuAddToBackRoom;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem moveCheckedItemsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showReadyToReleaseToolStripMenuItem;
        private System.Windows.Forms.Button btnUnselectAll;
        private System.Windows.Forms.Button btnSelectAll;
    }
}