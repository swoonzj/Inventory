using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace Inventory
{
    public partial class ManageInventory : Form
    {
        DynamicListView dListView;

        public ManageInventory()
        {
            InitializeComponent();            

            // Initialize DynamicListView
            RemoveItemCheckedHandler(); // Temporarily remove ItemChecked Event handler. (normally called every time an item is added. Super slow.)
            dListView = new DynamicListView(lvResults, TableNames.INVENTORY, ListViewType.MANAGEMENT, true);
            RestoreItemCheckedHandler(); // Restore ItemChecked Event handler.

            // Update "Total Items" label
            lblTotalItems.Text = "Total Items: " + DBaccess.GetItemTotal().ToString();
        }
        
        // Fill in ListView with entire Inventory table
        private void populateList()
        {
            // Remove ItemChecked Event handler. (normally called every time an item is added. Super slow.)
            RemoveItemCheckedHandler();

            dListView.PopulateList();
            
            // Restore ItemChecked Event handler.
            RestoreItemCheckedHandler();

            // Update "Total Items" label
            lblTotalItems.Text = "Total Items: " + dListView.inventory.Count();
        }

        /// <summary>
        /// Remove ItemChecked Event handler for the purposes of populating the ListView. (normally called every time an item is added. Super slow.)
        /// </summary>
        private void RemoveItemCheckedHandler()
        {
            lvResults.ItemChecked -= lvResults_ItemChecked;
        }

        /// <summary>
        /// Restores ItemChecked Event handler, which was removed to save time during the population of the ListView.
        /// </summary>
        private void RestoreItemCheckedHandler()
        {
            lvResults.ItemChecked += lvResults_ItemChecked;
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
            // If 1 second has gone by since the last keystroke
            searchTimer.Stop();

            // Update DynamicListView searchText & populate listView
            dListView.searchText = txtSearch.Text;
            populateList();
        }

        private void CompareCheckedItemsAndUpdateTextBoxes()
        {
            Item item = null;
            foreach (ListViewItem lvItem in lvResults.CheckedItems)
            {
                // First Checked item
                if (item == null)
                {
                    item = ((Item)lvItem.Tag).Clone();
                    continue;
                }

                Item newItem = ((Item)lvItem.Tag).Clone();

                // Compare item details & change if there is no match
                // A value of -1 indicates No Match
                if (item.system != newItem.system)
                    item.system = "";
                if (item.price != newItem.price)
                    item.price = -1; // -1 indicates No Match
                if (item.quantity != newItem.quantity)
                    item.quantity = -1;
                if (item.tradeCash != newItem.tradeCash)
                    item.tradeCash = -1;
                if (item.tradeCredit != newItem.tradeCredit)
                    item.tradeCredit = -1;

                // Set Auto-Print checkbox accordingly
                if (!DBaccess.IsItemInAutoPrintTable((Item)lvResults.CheckedItems[0].Tag) || chkAutoPrintLabels.Checked == false)
                    chkAutoPrintLabels.Checked = false;
            }
            
            // If no boxes were checked (and item is therefore null), return
            if (item == null) return;

            // Update labels.
            // If item value is -1, label value is blank ("")
            txtName.Text = "";
            txtSystem.Text = item.system;

            if (item.price == -1)
                txtPrice.Text = "";
            else
                txtPrice.Text = item.price.ToString("0.00");

            if (item.quantity == -1)
                txtInventory.Text = "";
            else
                txtInventory.Text = item.quantity.ToString();

            if (item.tradeCash == -1)
                txtCash.Text = "";
            else
                txtCash.Text = item.tradeCash.ToString("0.00");

            if (item.tradeCredit == -1)
                txtCredit.Text = "";
            else
                txtCredit.Text = item.tradeCredit.ToString("0.00");
            
            txtUPC.Text = "";
        }

        private void lvResults_ItemChecked(object sender, ItemCheckedEventArgs e)
        {   // When an item is checked, edit what is displayed in the textboxes.
            // If multiple items are checked, do not allow the "Name" textbox to be changed. 
            if (lvResults.CheckedItems.Count == 0)
            {
                clearTextBoxes();
                txtName.Enabled = true;
                txtUPC.Enabled = true;
                chkAutoPrintLabels.Checked = false;
            }

            if (lvResults.CheckedItems.Count == 1)
            {   // If only one item is checked, show all info for that item

                // Make sure Name textbox is enabled
                txtName.Enabled = true;
                txtUPC.Enabled = true;

                //set textboxes to display item data
                txtName.Text = ((Item)lvResults.CheckedItems[0].Tag).name;
                txtSystem.Text = ((Item)lvResults.CheckedItems[0].Tag).system;
                txtPrice.Text = ((Item)lvResults.CheckedItems[0].Tag).price.ToString("0.00");
                txtInventory.Text = ((Item)lvResults.CheckedItems[0].Tag).quantity.ToString();
                txtCash.Text = ((Item)lvResults.CheckedItems[0].Tag).tradeCash.ToString("0.00");
                txtCredit.Text = ((Item)lvResults.CheckedItems[0].Tag).tradeCredit.ToString("0.00");
                txtUPC.Text = ((Item)lvResults.CheckedItems[0].Tag).UPC.ToString();

                // Check if item is supposed to be Auto-Printed on Trade checkout
                // Set checkbox accordingly
                if (DBaccess.IsItemInAutoPrintTable((Item)lvResults.CheckedItems[0].Tag))
                {
                    chkAutoPrintLabels.Checked = true;
                }
                else
                    chkAutoPrintLabels.Checked = false;
            }

            if (lvResults.CheckedItems.Count > 1)
            {   // If multiple items are checked, 
                // do not allow changing of Names or UPC (to prevent errors with duplication in SQL).
                // Display only identical data in textboxes.

                //disable Name textbox
                txtName.Enabled = false;
                txtName.Text = null;

                //disable UPC textbox
                txtUPC.Enabled = false;
                txtUPC.Text = null;

                // Only display values for identical values
                CompareCheckedItemsAndUpdateTextBoxes();
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
            txtUPC.Text = "";

            // Un-check Auto-Print labels
            chkAutoPrintLabels.Checked = false;
        }

        private void butSave_Click(object sender, EventArgs e)
        {   // Save changes to item, refresh listview
            float result;
            int intResult;
            //double doubleResult;

            // Save Edit Changes  to the checked items 
            foreach (ListViewItem item in lvResults.CheckedItems)
            {
                string name, system, price, quantity, cash, credit, upc;
                Item newItem;

                // Set new Name
                if (txtName.Enabled && txtName.Text != null)
                    name = txtName.Text;
                else name = ((Item)item.Tag).name;

                //set new System
                if (txtSystem.Text != "")
                    system = txtSystem.Text;
                else system = ((Item)item.Tag).system;

                //set new Price
                if (txtPrice.Text != "")
                {
                    if (!float.TryParse(txtPrice.Text, out result)) // Make sure input is an actual number
                    {
                        MessageBox.Show("The entered value for PRICE is not a valid number:\n" + txtPrice.Text, "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    // Real number, continue
                    price = txtPrice.Text;
                }
                else price = ((Item)item.Tag).price.ToString();

                //set new Inventory
                if (txtInventory.Text != "")
                {
                    if (!int.TryParse(txtInventory.Text, out intResult)) // Make sure input is an actual number
                    {
                        MessageBox.Show("The entered value for INVENTORY is not a valid number:\n" + txtInventory.Text, "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    quantity = txtInventory.Text;
                }
                else quantity = ((Item)item.Tag).quantity.ToString();

                //set Cash trade value
                if (txtCash.Text != "")
                {
                    if (!float.TryParse(txtCash.Text, out result)) // Make sure input is an actual number
                    {
                        MessageBox.Show("The entered value for CASH is not a valid number:\n" + txtCash.Text, "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    // Real number, continue

                    cash = txtCash.Text;
                }
                else cash = ((Item)item.Tag).tradeCash.ToString();

                //set Credit trade value
                if (txtCredit.Text != "")
                {
                    if (!float.TryParse(txtCredit.Text, out result)) // Make sure input is an actual number
                    {
                        MessageBox.Show("The entered value for CREDIT is not a valid number:\n" + txtCredit.Text, "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    // Real number, continue
                    credit = txtCredit.Text;
                }
                else credit = ((Item)item.Tag).tradeCredit.ToString();

                //set UPC
                if (txtUPC.Text != "")
                {
                    upc = txtUPC.Text;                    

                    // Make sure UPC is currently not in use
                    if (DBaccess.IsUPCInUse(upc) && upc != "0")
                    {
                        Item tempItem = DBaccess.GetItemWithUPC(TableNames.INVENTORY, upc);

                        // If used UPC matches current item's name & system, allow UPC to be used
                        if (tempItem.name != name || tempItem.system != system)
                        {
                            // Prompt user otherwise (in case the name or system is changing)
                            DialogResult yesno = MessageBox.Show("Warning: This UPC number is currently in use by this item:\n" + tempItem.name + "\nSystem: " + tempItem.system + "\nProceed?", "UPC Currently In Use", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                            
                            if (yesno == DialogResult.No)
                                return;
                        }
                    }
                }
                else upc = ((Item)item.Tag).UPC;

                newItem = new Item(name, system, price, quantity, cash, credit, upc);
                
                // Save changes
                DBaccess.EditInventory(TableNames.INVENTORY, (Item)item.Tag, newItem);
                
                if (chkAutoPrintLabels.Checked == true)
                    DBaccess.AddToAutoPrintTable((Item)item.Tag);
                else
                    DBaccess.RemoveFromAutoPrintTable((Item)item.Tag);
            }

            clearTextBoxes();
            populateList();
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Verify Delete action
            DialogResult result;
            result = MessageBox.Show("Permanently delete item(s)?", "Are you sure? This could be a big deal.", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != System.Windows.Forms.DialogResult.Yes)
                return;

            // Verified, continue
            // Delete item from table
            foreach (ListViewItem item in lvResults.CheckedItems)
            {
                DBaccess.DeleteTableItem(TableNames.INVENTORY, ((Item)item.Tag));
            }

            clearTextBoxes();
            populateList();
        }

        private void btnUnselectAll_Click(object sender, EventArgs e)
        {   
            // Uncheck all the boxes

            RemoveItemCheckedHandler(); // Faster load
            foreach (ListViewItem item in lvResults.Items)
            {
                item.Checked = false;
            }
            RestoreItemCheckedHandler();
            txtName.Enabled = true;
            txtUPC.Enabled = true;
            clearTextBoxes(); // Clear the text boxes, which would otherwise be filled with info from the last item that was physically "checked".
        }
        
        // Check all the boxes
        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            RemoveItemCheckedHandler(); // Faster load
            foreach (ListViewItem item in lvResults.Items)
            {
                item.Checked = true;
            }
            RestoreItemCheckedHandler();
            txtName.Enabled = false;
            txtUPC.Enabled = false;
            CompareCheckedItemsAndUpdateTextBoxes();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        
        private void addNewItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewItem newItem = new NewItem();
            newItem.Show();
        }
        
        private void btnGenerateUPC_Click(object sender, EventArgs e)
        {
            txtUPC.Text = DBaccess.GetNextUnusedUPC().ToString();
            DBaccess.IncrementUPC();
        }

        private void showTransactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            View_Transactions transaction = new View_Transactions();
            transaction.Show();
        }

        private void btnPrintUPC_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvItem in lvResults.CheckedItems)
            {
                Printer.PrintUPCLabel((Item)lvItem.Tag);
            }
        }

        private void fromCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Open import window

            MessageBox.Show("Import Window Placeholder");          
        }
        
        private void btnClearSearchBox_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
        }

        private void addLeadingZeroesToUPCsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DBaccess.AddLeadingZeroes();
        }

        private void txtInventory_TextChanged(object sender, EventArgs e)
        {

        }

        private void inventoryLargeQuantitiesUsingPriceScannerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Open new InventoryLargeQuantity window
            LargeInventoryMode largeInventoryMode = new LargeInventoryMode();
            largeInventoryMode.Show();
        }

        private void importToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ImportItems importItems = new ImportItems();
            importItems.Show();
        }

        private void exportToCSVToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveCSV = new SaveFileDialog();
            saveCSV.Title = "Export Inventory to .CSV";
            saveCSV.Filter = "Comma Separated Values | *.csv";
            saveCSV.InitialDirectory = @".";

            if (saveCSV.ShowDialog() == DialogResult.OK)
            {
                ExportToCSV(saveCSV.FileName, TableNames.INVENTORY);
            }
        }

        private void ExportToCSV(string filename, string table)
        {

        }
    }
}
