using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Inventory
{
    public partial class Import : Form
    {
        int r, g, b; // For DragonForce easter eggs
        bool ascending;
        string sortBy;
        Collection newItems;

        public Import()
        {
            InitializeComponent();
        } 
        
        private void Import_Load(object sender, EventArgs e)
        {
            r = g = b = 0;
            sortBy = "System";
            OpenCSV();
            populateList();

        }

        private void OpenCSV()
        {
            //OpenFileDialog CSVbrowse = new OpenFileDialog();
            //CSVbrowse.Title = "Open .csv File";
            //CSVbrowse.Filter = "Comma Separated Values, brah|*.csv";
            //CSVbrowse.InitialDirectory = @".";

            //if (CSVbrowse.ShowDialog() == DialogResult.OK)
            //{
            //    // Display 1st line of file to verify,
            //    // then choose whether to import all columns, or only first (name) column

            //    System.IO.StreamReader file = new System.IO.StreamReader(CSVbrowse.FileName.ToString());
            //    var result = MessageBox.Show("First Line of File: \n\t" + file.ReadLine() +
            //                                    "\n\nClick 'Yes' to import only the 1st column (name)\n" +
            //                                    "Click 'No' to import all columns\n" +
            //                                    "Or click 'Cancel' to abort", "Oh God!", MessageBoxButtons.YesNoCancel);

            //    if (result == DialogResult.Yes) // Click Yes, import only 1st column
            //    {
            //        //DBaccess.LoadCSV(CSVbrowse.FileName.ToString(), "tblTemp", 1);
            //    }
            //    if (result == DialogResult.No) // Click No, import all 6 columns
            //    {
            //        //DBaccess.LoadCSV(CSVbrowse.FileName.ToString(), "tblTemp", 6);
            //    }

            //    if (result == DialogResult.Cancel) // Cancel
            //    {
            //        return;
            //    }

            //    //display & edit imported data
            //    Import importform = new Import();
            //    importform.Show();
            //    this.Hide();
            //    importform.FormClosing += Unhide;

            //}
        }

        // Fill in ListView with entire Inventory table
        private void populateList()
        {
            // Remove ItemChecked Event handler. (normally called every time an item is added. Super slow.)
            lvResults.ItemChecked -= lvResults_ItemChecked;

            lvResults.Items.Clear(); // clear old results

            // Refresh inventory Collection & populate ListView
            //inventory.PopulateListView(lvResults, false, ListViewType._30DAYHOLD);
            
            // Restore ItemChecked Event handler.
            lvResults.ItemChecked += lvResults_ItemChecked;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e) // If search text is altered, live-update the results list
        {
            
        }

        private void lvResults_ItemChecked(object sender, ItemCheckedEventArgs e)
        {   // When an item is checked, edit what is displayed in the textboxes.
            // If multiple items are checked, do not allow the "Name" textbox to be changed. 

            //if (IgnoreItemCheck == false) // Only run if not ignoring the handler
            {
                
            }
        }
    

        private void lvResults_SelectedIndexChanged(object sender, EventArgs e)
        {   // Only allow 1 item to be selected at a time.
            for (int i = 0; i < lvResults.SelectedItems.Count; i++)
            {
                ListViewItem item = lvResults.SelectedItems[i];
                if (i != 0)
                {
                    item.Checked = !item.Checked;
                    item.Selected = false;
                }
            }
        }

        private void clearTextBoxes()
        {   //sets text value of data text boxes to an empty string
            txtName.Text = "";
            txtSystem.Text = "";
            txtPrice.Text = "";
            txtInventory.Text = "";
            txtCash.Text = "";
            txtCredit.Text = "";
        }



       //private void lvResults_ItemActivate(object sender, EventArgs e)
       // {   // Check or Uncheck selected item if name is clicked
       //     foreach (ListViewItem item in lvResults.SelectedItems)
       //         item.Checked = !item.Checked;
       // }



        

        private void lvResults_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            //if (e.Column == lvwColumnSorter.SortColumn)
            //{
            //    // Reverse the current sort direction for this column.
            //    if (lvwColumnSorter.Order == System.Windows.Forms.SortOrder.Ascending)
            //    {
            //        lvwColumnSorter.Order = System.Windows.Forms.SortOrder.Descending;
            //    }
            //    else
            //    {
            //        lvwColumnSorter.Order = System.Windows.Forms.SortOrder.Ascending;
            //    }
            //}
            //else
            //{
            //    // Set the column number that is to be sorted; default to ascending.
            //    lvwColumnSorter.SortColumn = e.Column;
            //    lvwColumnSorter.Order = System.Windows.Forms.SortOrder.Ascending;
            //}

            //// Perform the sort with these new sort options.
            //this.lvResults.Sort();
        }


        // ==================================================================
        // Buttons ==========================================================
        // ==================================================================

        private void btnSelectAll_Click(object sender, EventArgs e)
        {   // Check all the boxes
            //IgnoreItemCheck = true; // for speed
            //foreach (ListViewItem item in lvResults.Items)
            //{
            //    item.Checked = true;
            //}
            //IgnoreItemCheck = false;
        }

        private void btnUnselectAll_Click(object sender, EventArgs e)
        {   // Uncheck all the boxes
            //IgnoreItemCheck = true; // for speed
            //foreach (ListViewItem item in lvResults.Items)
            //{
            //    item.Checked = false;
            //}
            //IgnoreItemCheck = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {   // Cancel import & close form
            this.Close();
        } 

        private void btnSave_Click(object sender, EventArgs e)
        {   // Save Edit Changes  to the checked items 
            foreach (ListViewItem item in lvResults.CheckedItems)
            {
                string name, system, price, inventory, cash, credit, upc;

                // Set new Name
                if (txtName.Enabled && txtName.Text != null)
                    name = txtName.Text;
                else name = item.SubItems[0].Text;

                //set new System
                if (txtSystem.Text != "")
                    system = txtSystem.Text;
                else system = item.SubItems[1].Text;

                //set new Price
                if (txtPrice.Text != "")
                    price = txtPrice.Text;
                else price = item.SubItems[2].Text;

                //set new Inventory
                if (txtInventory.Text != "")
                    inventory = txtInventory.Text;
                else inventory = item.SubItems[3].Text;

                //set Cash trade value
                if (txtCash.Text != "")
                    cash = txtCash.Text;
                else cash = item.SubItems[4].Text;

                //set Credit trade value
                if (txtCredit.Text != "")
                    credit = txtCredit.Text;
                else credit = item.SubItems[5].Text;

                // change this, obviously
                upc = "1111";

                //DBaccess.EditInventory("tblTemp", item.SubItems[0].Text, item.SubItems[1].Text, name, system, price, inventory, cash, credit, upc);


            }

            clearTextBoxes();
            populateList();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {   // Delete item from table
            foreach (ListViewItem item in lvResults.CheckedItems)
            {
                //DBaccess.DeleteTableItem("tblTemp", item.SubItems[0].Text, item.SubItems[1].Text);
            }
            populateList();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            //foreach (ListViewItem item in lvResults.Items)
            //{
            //    DBaccess.AddToTable("tblInventory", 
            //        item.SubItems[0].Text, // name
            //        item.SubItems[1].Text, // system
            //        Convert.ToSingle(item.SubItems[2].Text), // Price
            //        Convert.ToInt32(item.SubItems[3].Text), // Inventory
            //        Convert.ToSingle(item.SubItems[4].Text), // Trade/Cash
            //        Convert.ToSingle(item.SubItems[5].Text) // Trade/Credit
            //        );
            //}
            //this.Close();
        }



        //Easter Egg -=-=-=-=-=-=-=-
        private void timer1_Tick(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.FromArgb(255, r, g, b);
            r++;
            g += 20;
            b += 30;

            r %= 255;
            g %= 255;
            b %= 255;
        }

        private void Import_HelpButtonClicked(object sender, CancelEventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@".\BlackFire.wav");

            if (timer1.Enabled) player.Play();
            else player.Stop();
        }

        

    }
}
