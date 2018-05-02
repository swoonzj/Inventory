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
using Inventory;
using System.Windows.Input;
using System.Drawing.Printing;

namespace Inventory
{
    public partial class POSinventory : Form
    {
        Cart cart;
        TradeCart tradeCart;

        DynamicListView dInventoryListView;
        //DynamicListView dCartListView;
        //DynamicListView dTradeListView;
        
        private string keyboardInput = ""; // for reading UPCs from price scanner
        
        public POSinventory()
        {
            InitializeComponent();

            // Initialize dynamic listviews
            dInventoryListView = new DynamicListView(lvResults, TableNames.INVENTORY, ListViewType.POS, true);

            dInventoryListView.hideOutOfStock = chkHideZero.Checked; // Hide items that aren't in stock by default

            //dCartListView = new DynamicListview(lvResults, TableNames.INVENTORY, ListViewType.CART, true);
            //dTradeListView = new DynamicListview(lvResults, TableNames.INVENTORY, ListViewType.TRADECART, true); 
        }

        private void POSinventory_Load(object sender, EventArgs e)
        {
            // Instantiate Carts
            cart = new Cart(lvCart, ListViewType.CART);
            tradeCart = new TradeCart (lvTradeCart, ListViewType.TRADECART);
            
            //load inventory into ListView
            PopulateLists();

            // Initialize "total" labels
            lblCartTotal.Text = cart.cartTotal.ToString("C");
            lblCashTotal.Text = tradeCart.cashTotal.ToString("C");
            lblCreditTotal.Text = tradeCart.creditTotal.ToString("C");
        }

        // Fill in ListView with entire Inventory table
        private void PopulateLists()
        {
            UpdateInventory();
            cart.UpdateListView();
            tradeCart.UpdateListView();
            
            // Set ListView tags for use with Price Scanner
            lvCart.Tag = cart;      // Focus on either the cart or the inventory ListViews will 
            lvResults.Tag = cart;   //  add items to the checkout cart upon scanning item.
            lvTradeCart.Tag = tradeCart; // Focus on the tradeCart will add scanned items to the trade cart.
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
            // Update inventory with items that match the search text
            PopulateLists();
        }
        private void butAddCart_Click(object sender, EventArgs e)
        {
            // Send Checked items to Cart
            foreach (ListViewItem item in lvResults.CheckedItems)
                cart.AddItem((Item)item.Tag);

            UpdateTotalsLabels();
        }

        private void btnAddTrade_Click(object sender, EventArgs e)
        {
            // Send Checked items to Cart
            foreach (ListViewItem item in lvResults.CheckedItems)
                tradeCart.AddItem((Item)item.Tag);

            UpdateTotalsLabels();
        }

        public void UpdateTotalsLabels()
        {
            lblCartTotal.Text = cart.cartTotal.ToString("C");
            lblCashTotal.Text = tradeCart.cashTotal.ToString("C");
            lblCreditTotal.Text = tradeCart.creditTotal.ToString("C");
        }

        private void UpdateInventory()
        {
            dInventoryListView.searchText = txtSearch.Text; // Update search text
            dInventoryListView.PopulateList(); // Populate listview
        }
        
        private void chkHideZero_CheckedChanged(object sender, EventArgs e)
        {
            dInventoryListView.hideOutOfStock = chkHideZero.Checked;
            PopulateLists();
        }

        private void addNewInventoryItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Instantiate and open New Item form
            NewItem newItem = new NewItem();
            newItem.Show(); 
        }
        
        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void forSeriousToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditCart editCart = new EditCart(lvCart, cart);
            editCart.Show();
        }

        private void openManagementScreenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageInventory manageInventory = new ManageInventory();
            manageInventory.Show();
        }

        private void butRemove_Click(object sender, EventArgs e)
        {
            // Remove checked items from cart
            foreach (ListViewItem checkedItem in lvCart.CheckedItems)
            {
                cart.RemoveItem((Item)checkedItem.Tag);
            }

            // Update the ListView with new changes
            cart.UpdateListView();
            UpdateTotalsLabels();
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            cart.Sell();
            PopulateLists();
            UpdateTotalsLabels();
        }

        private void btnEditTradeCart_Click(object sender, EventArgs e)
        {
            // Opens the Edit Cart form
            EditTradeCart editTradeCart = new EditTradeCart(lvTradeCart, tradeCart);
            editTradeCart.Show();
        }

        private void btnRemoveTrade_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem checkedItem in lvTradeCart.CheckedItems)
            {
                tradeCart.RemoveItem((Item)checkedItem.Tag);
            }

            // Update the ListView with new changes
            tradeCart.UpdateListView();
            UpdateTotalsLabels();
        }

        private void btnCashCheckout_Click(object sender, EventArgs e)
        {
            // Record transaction as Cash
            AutoPrintLabels(tradeCart);
            tradeCart.Trade(TransactionTypes.TRADE_CASH);
            PopulateLists();
        }

        private void btnCreditCheckout_Click(object sender, EventArgs e)
        {
            // Record transaction as Store Credit
            AutoPrintLabels(tradeCart);
            tradeCart.Trade(TransactionTypes.TRADE_CREDIT);
            PopulateLists();
        } 

        /// <summary>
        /// Prints items
        /// </summary>
        /// <param name="cart"></param>
        private void AutoPrintLabels(TradeCart cart)
        {
            // Only print labels if corresponding menu item is checked.
            if (printUPCLabelsAfterTradeTransactionToolStripMenuItem.Checked != true)
                return;

            foreach (Item item in cart.items)
            {
                if (DBaccess.IsItemInAutoPrintTable(item))
                {
                    // Print as many labels as the item quantity indicates
                    Printer.PrintQuantityOfUPCLabels(item);
                }
            }
        }

        // Handle input from Price Scanner
        new private void KeyPress(object sender, KeyPressEventArgs e)
        {
            // Keep accepting input until "RETURN" is hit
            if (e.KeyChar.ToString() != "\r")
            {
                keyboardInput += e.KeyChar.ToString();
            }
            // When "RETURN" is hit, look up UPC & add item to currently focused cart
            else
            {
                ((Cart)((ListView)sender).Tag).AddItemFromUPC(TableNames.INVENTORY, keyboardInput);
                keyboardInput = "";
                UpdateTotalsLabels();
            }
        }

        private void printUPCLabelsAfterTradeTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrinterSettings settings = new PrinterSettings();
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                MessageBox.Show(printer);
            }
        }

        private void btnClearSearchBox_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
        }
    }    
}


