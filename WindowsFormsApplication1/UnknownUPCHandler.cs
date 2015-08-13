using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Inventory
{
    public partial class UnknownUPCHandler : Form
    {
        string newUPC;
        public bool success { get; private set; } // Used to determine whether or not a UPC was successfully assigned before the form is closed. If true, UPC is assigned. Else, false.
        DynamicListView dListView;

        public UnknownUPCHandler(string upc)
        {            
            InitializeComponent();
            
            // Assign a new DynamicListView to the listview on the form
            dListView = new DynamicListView(lvResults, TableNames.INVENTORY, ListViewType.MANAGEMENT, true);
            newUPC = upc;

            // Success = false by default
            success = false;
        }

        private void btnClearSearchBox_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // Start/Reset the timer each time the search text changes
            // to prevent the system from accessing the DB on each key press.
            // (faster load times)
            if (!searchTimer.Enabled) searchTimer.Start();
            else
            {   //reset the timer
                searchTimer.Stop();
                searchTimer.Start();
            }
        }

        private void searchTimer_Tick(object sender, EventArgs e)
        {
            // If 1 second has gone by since the last keystroke, repopulate the list
            searchTimer.Stop();

            // Change the searchText in the dynamicListview & populate list
            dListView.searchText = txtSearch.Text;
            dListView.PopulateList();
        }

        // Assign new UPC to item ONLY IF one item has been selected.
        private void btnAssign_Click(object sender, EventArgs e)
        {
            if (lvResults.CheckedItems.Count == 0)
                MessageBox.Show("No items have been selected.\nNo changes will be made.");
            if (lvResults.CheckedItems.Count > 1)
                MessageBox.Show("Please select only one item.");
            else if (lvResults.CheckedItems.Count == 1)
            {
                Item item = (Item)lvResults.CheckedItems[0].Tag;
                string verifyString;

                verifyString = "Assign UPC: " + newUPC + "\nto Item: " + item.name + "\nfor System: " + item.system;
                
                // Verify changes
                DialogResult dialogResult = MessageBox.Show(verifyString, "Verify changes", MessageBoxButtons.YesNo);

                // If result is "Yes", assign UPC to item
                if (dialogResult == DialogResult.Yes)
                {
                    Item newItem = item.Clone();
                    newItem.UPC = newUPC;
                    DBaccess.EditInventory(TableNames.INVENTORY, item, newItem);

                    // Change success to "true", indicating a successful UPC assignment
                    success = true;

                    // Assignment successful, close form
                    this.Close();
                }
            }
        }

        /// <summary>
        /// Closes form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
