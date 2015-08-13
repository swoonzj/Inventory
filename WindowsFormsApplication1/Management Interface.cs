using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Configuration;

namespace Inventory
{
    public partial class Management_Interface : Form
    {
        public Management_Interface()
        {
            InitializeComponent();
        }

        private void Unhide(object sender, FormClosingEventArgs e)
        {
            this.Show();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            //Open New Item form
            NewItem newItem = new NewItem();
            newItem.Show(); // Open Management form
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            ManageInventory editItem = new ManageInventory();
            editItem.Show();
        }

        private void btnImportCSV_Click(object sender, EventArgs e)
        {
            OpenFileDialog CSVbrowse = new OpenFileDialog();
            CSVbrowse.Title = "Open .csv File";
            CSVbrowse.Filter = "Stupid Ass Bitch Files|*.csv";
            CSVbrowse.InitialDirectory = @".";

            if (CSVbrowse.ShowDialog() == DialogResult.OK)
            {
                // Display 1st line of file to verify,
                // then choose whether to import all columns, or only first (name) column
                //
                // Items are saved to table 'tblTemp' first, to avoid any accidental conflicts.
                // Intentional conflicts are still okay.   <--- joke. But not really.

                DBaccess.ClearTable("tblTemp"); // Empty the temporary table, in case program was improperly terminated
                                                //        and there is data left in the table
                System.IO.StreamReader file = new System.IO.StreamReader(CSVbrowse.FileName.ToString());
                var result = MessageBox.Show( "First Line of File: \n\t" + file.ReadLine() + 
                                                "\n\nClick 'Yes' to import only the 1st column (name)\n" +
                                                "Click 'No' to import all columns\n" +
                                                "Or click 'Cancel' to abort", "Oh God!", MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Yes) // Click Yes, import only 1st column
                {
                    //DBaccess.LoadCSV(CSVbrowse.FileName.ToString(), "tblTemp", 1);
                }
                if (result == DialogResult.No) // Click No, import all 6 columns
                {
                    //DBaccess.LoadCSV(CSVbrowse.FileName.ToString(), "tblTemp", 6);
                }

                if (result == DialogResult.Cancel) // Cancel
                {
                    return;
                }

                //display & edit imported data
                Import importform = new Import();
                importform.Show();
                this.Hide();
                importform.FormClosing += Unhide;

            }


        }

        private void btnExportCSV_Click(object sender, EventArgs e)
        {   // Save Inventory Table as a .CSV file
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = Convert.ToString(Environment.SpecialFolder.MyDocuments);
            saveFileDialog1.Filter = "Comma Separated Values, Nigga! (*.csv)|*.csv";
            saveFileDialog1.FilterIndex = 1;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                DBaccess.ExportCSV(saveFileDialog1.FileName, "tblInventory");// Export Inventory table
            } 
        }

        private void btnFormatCSV_Click(object sender, EventArgs e)
        {
            FormatCSV formatForm = new FormatCSV();
            formatForm.Show();
        }

        private void btnTransactions_Click(object sender, EventArgs e)
        {
            View_Transactions transactionsForm = new View_Transactions();
            transactionsForm.Show();
        }

        private void btnSelectDatabase_Click(object sender, EventArgs e)
        {
            //DBaccess.Create30DayHoldRemovalList();
            
            //MessageBox.Show("This Doesn't Do Anything. Lols!", "Pointless Messagebox", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Hand);

            //// Create an instance of the open file dialog box.
            //OpenFileDialog openFileDialog1 = new OpenFileDialog();

            //// Set filter options and filter index.
            //openFileDialog1.Filter = "Database Files, idiot (.mdf)|*.mdf";
            //openFileDialog1.FilterIndex = 1;

            //openFileDialog1.Multiselect = false;

            //if (openFileDialog1.ShowDialog() == DialogResult.OK)
            //{
            //    Properties.Settings.Default.StoreDatabaseConnectionString1;
            //} 

        }

        private void btnCreateTable_Click(object sender, EventArgs e)
        {
            //DBaccess.Add30DayHoldTable();
            //DBaccess.Add30DayHoldListTable();
        }

        private void btnViewHold_Click(object sender, EventArgs e)
        {
            _30DayHold hold = new _30DayHold();
            hold.Show();
        }


        
    }
}
