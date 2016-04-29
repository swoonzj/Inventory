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
    public partial class LargeInventoryMode : Form
    {
        private string keyboardInput;
        private Collection inventory;
        private DynamicListView dListView;

        public LargeInventoryMode()
        {
            InitializeComponent();

            inventory = new Collection();

            // Initialize dynamicListView
            dListView = new DynamicListView(lvResults, inventory, ListViewType.MANAGEMENT, true);
        }

        // Called when an item is scanned. (Or a UPC is typed in VIA keyboard)
        private void lvResults_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Keep accepting input until "RETURN" is hit
            if (e.KeyChar.ToString() != "\r")
            {
                keyboardInput += e.KeyChar.ToString();
            }
            // When "RETURN" is hit, look up UPC & add item to temp inventory
            else
            {
                // Make sure input isn't blank
                if (keyboardInput == "") return;

                // Make sure UPC exists. If not, give option to create or add to an item.
                if (!DBaccess.IsUPCInUse(keyboardInput))
                {
                    UnknownUPC(keyboardInput);
                    keyboardInput = "";
                    dListView.PopulateListFromCollection();
                    return;
                }

                inventory.AddItemFromUPC(TableNames.INVENTORY, keyboardInput);
                keyboardInput = "";
                dListView.PopulateListFromCollection();
            }


            // Check selected items

            if (e.KeyChar.ToString() == "\r")
            {
                foreach (ListViewItem item in lvResults.SelectedItems)
                    item.Checked = true;
            }
        }

        /// <summary>
        /// Prompts user with options when an unknown UPC is scanned/entered
        /// </summary>
        /// <param name="upc">The unknown UPC</param>
        private void UnknownUPC(string upc)
        {
            // MessageBox prompt
            DialogResult result = MessageBox.Show("Unknown UPC.\nAssign UPC to existing inventory item?", "Unknown UPC", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (result == System.Windows.Forms.DialogResult.No) // User selects "No"
                return;
            else // User selects "Yes", open UnknownUPCHandler
            {
                UnknownUPCHandler unknownUPCHandler = new UnknownUPCHandler(upc);
                unknownUPCHandler.ShowDialog();

                // If UPC was successfully assigned, attempt to add item to current inventory
                if (unknownUPCHandler.success == true)
                {
                    inventory.AddItemFromUPC(TableNames.INVENTORY, upc);
                }
                else
                {
                    return;
                }
            }

        }

        private void butSave_Click(object sender, EventArgs e)
        {
            // Return if Quantity textbox is null
            if (txtQuantity.Text == "")
                return;

            // Change the quantity of each item in the textbox
            foreach (ListViewItem lvItem in lvResults.CheckedItems)
            {
                try
                {
                    ((Item)lvItem.Tag).quantity = Convert.ToInt32(txtQuantity.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error with Quantity:\n" + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            dListView.PopulateListFromCollection();
        }
    }
}
