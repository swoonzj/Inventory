namespace Inventory
{
    partial class Management_Interface
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Management_Interface));
            this.btnAddNew = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnImportCSV = new System.Windows.Forms.Button();
            this.btnExportCSV = new System.Windows.Forms.Button();
            this.btnTransactions = new System.Windows.Forms.Button();
            this.btnFormatCSV = new System.Windows.Forms.Button();
            this.btnSelectDatabase = new System.Windows.Forms.Button();
            this.btnCreateTable = new System.Windows.Forms.Button();
            this.btnViewHold = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAddNew
            // 
            this.btnAddNew.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNew.Location = new System.Drawing.Point(33, 35);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(182, 47);
            this.btnAddNew.TabIndex = 0;
            this.btnAddNew.Text = "Add New Item";
            this.btnAddNew.UseVisualStyleBackColor = true;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(33, 104);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(182, 47);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Edit Existing Item";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnImportCSV
            // 
            this.btnImportCSV.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportCSV.Location = new System.Drawing.Point(33, 304);
            this.btnImportCSV.Name = "btnImportCSV";
            this.btnImportCSV.Size = new System.Drawing.Size(130, 47);
            this.btnImportCSV.TabIndex = 3;
            this.btnImportCSV.Text = "Import from .CSV";
            this.btnImportCSV.UseVisualStyleBackColor = true;
            this.btnImportCSV.Click += new System.EventHandler(this.btnImportCSV_Click);
            // 
            // btnExportCSV
            // 
            this.btnExportCSV.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportCSV.Location = new System.Drawing.Point(33, 373);
            this.btnExportCSV.Name = "btnExportCSV";
            this.btnExportCSV.Size = new System.Drawing.Size(182, 47);
            this.btnExportCSV.TabIndex = 4;
            this.btnExportCSV.Text = "Export Database to .CSV";
            this.btnExportCSV.UseVisualStyleBackColor = true;
            this.btnExportCSV.Click += new System.EventHandler(this.btnExportCSV_Click);
            // 
            // btnTransactions
            // 
            this.btnTransactions.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransactions.Location = new System.Drawing.Point(290, 35);
            this.btnTransactions.Name = "btnTransactions";
            this.btnTransactions.Size = new System.Drawing.Size(182, 47);
            this.btnTransactions.TabIndex = 5;
            this.btnTransactions.Text = "View/Edit Transactions";
            this.btnTransactions.UseVisualStyleBackColor = true;
            this.btnTransactions.Click += new System.EventHandler(this.btnTransactions_Click);
            // 
            // btnFormatCSV
            // 
            this.btnFormatCSV.Font = new System.Drawing.Font("Cambria", 10F);
            this.btnFormatCSV.Location = new System.Drawing.Point(169, 312);
            this.btnFormatCSV.Name = "btnFormatCSV";
            this.btnFormatCSV.Size = new System.Drawing.Size(94, 32);
            this.btnFormatCSV.TabIndex = 6;
            this.btnFormatCSV.Text = "Format .CSV";
            this.btnFormatCSV.UseVisualStyleBackColor = true;
            this.btnFormatCSV.Click += new System.EventHandler(this.btnFormatCSV_Click);
            // 
            // btnSelectDatabase
            // 
            this.btnSelectDatabase.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectDatabase.Location = new System.Drawing.Point(290, 373);
            this.btnSelectDatabase.Name = "btnSelectDatabase";
            this.btnSelectDatabase.Size = new System.Drawing.Size(182, 47);
            this.btnSelectDatabase.TabIndex = 7;
            this.btnSelectDatabase.Text = "Select Database Location";
            this.btnSelectDatabase.UseVisualStyleBackColor = true;
            this.btnSelectDatabase.Click += new System.EventHandler(this.btnSelectDatabase_Click);
            // 
            // btnCreateTable
            // 
            this.btnCreateTable.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreateTable.Location = new System.Drawing.Point(290, 304);
            this.btnCreateTable.Name = "btnCreateTable";
            this.btnCreateTable.Size = new System.Drawing.Size(182, 48);
            this.btnCreateTable.TabIndex = 9;
            this.btnCreateTable.Text = "Create Hold Table";
            this.btnCreateTable.UseVisualStyleBackColor = true;
            this.btnCreateTable.Click += new System.EventHandler(this.btnCreateTable_Click);
            // 
            // btnViewHold
            // 
            this.btnViewHold.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewHold.Location = new System.Drawing.Point(290, 104);
            this.btnViewHold.Name = "btnViewHold";
            this.btnViewHold.Size = new System.Drawing.Size(182, 47);
            this.btnViewHold.TabIndex = 10;
            this.btnViewHold.Text = "View 30-Day Hold";
            this.btnViewHold.UseVisualStyleBackColor = true;
            this.btnViewHold.Click += new System.EventHandler(this.btnViewHold_Click);
            // 
            // Management_Interface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 474);
            this.Controls.Add(this.btnViewHold);
            this.Controls.Add(this.btnCreateTable);
            this.Controls.Add(this.btnSelectDatabase);
            this.Controls.Add(this.btnFormatCSV);
            this.Controls.Add(this.btnTransactions);
            this.Controls.Add(this.btnExportCSV);
            this.Controls.Add(this.btnImportCSV);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAddNew);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Management_Interface";
            this.Text = "Management_Interface";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAddNew;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnImportCSV;
        private System.Windows.Forms.Button btnExportCSV;
        private System.Windows.Forms.Button btnTransactions;
        private System.Windows.Forms.Button btnFormatCSV;
        private System.Windows.Forms.Button btnSelectDatabase;
        private System.Windows.Forms.Button btnCreateTable;
        private System.Windows.Forms.Button btnViewHold;
    }
}