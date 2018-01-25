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
    public partial class MultipleUPCSelector : Form
    {
        public Item selectedItem { get; set; }
        DynamicListView dListView;

        public MultipleUPCSelector(Collection items)
        {            
            InitializeComponent();
            
            // Assign a new DynamicListView to the listview on the form
            dListView = new DynamicListView(lvResults, items, ListViewType.MANAGEMENT, true);

            MessageBox.Show("The UPC has multiple items associated with it.\nPlease select the correct item.");
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

                verifyString = "Select item: " + item.name + "\nfor System: " + item.system + "?";
                
                // Verify changes
                DialogResult dialogResult = MessageBox.Show(verifyString, "Verify changes", MessageBoxButtons.YesNo);

                // If result is "Yes", assign UPC to item
                if (dialogResult == DialogResult.Yes)
                {
                    this.selectedItem = item;
                    this.DialogResult = DialogResult.OK;
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
