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
    public partial class EditTradeCart : Form
    {
        ListView listView;
        TextBox discountTextBox;
        TextBox quantityTextBox;
        TradeCart cart;

        public EditTradeCart(ListView listView, TradeCart cart)
        {
            this.listView = listView;
            this.cart = cart;

            InitializeComponent();

            this.discountTextBox = this.txtChangePrices;
            this.quantityTextBox = this.txtQuantity;
        }

        private void btnChangeQuantity_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem checkedItem in listView.CheckedItems)
            {
                // If quantity is 0, remove item from cart
                if (Convert.ToDecimal(quantityTextBox.Text) == 0)
                {
                    cart.RemoveItem((Item)checkedItem.Tag);
                }

                // Update item with new quantity
                ((Item)checkedItem.Tag).SetQuantity(quantityTextBox.Text);
            }

            // Update the ListView with new changes
            cart.UpdateListView();
            UpdateLabels();
        }
        
        private void btnChangeCash_Click(object sender, EventArgs e)
        {
            decimal amount;
            try
            {
                amount = Convert.ToDecimal(discountTextBox.Text);
            }
            catch
            {
                MessageBox.Show("The value in the textbox is probably invalid.", "Something Went Wrong", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            foreach (ListViewItem checkedItem in listView.CheckedItems)
            {
                ((Item)checkedItem.Tag).SetTradeCash(amount);
            }

            cart.UpdateListView();
            UpdateLabels();
        }

        private void btnChangeCredit_Click(object sender, EventArgs e)
        {
            decimal amount;
            try
            {
                amount = Convert.ToDecimal(discountTextBox.Text);
            }
            catch
            {
                MessageBox.Show("The value in the textbox is probably invalid.", "Something Went Wrong", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            foreach (ListViewItem checkedItem in listView.CheckedItems)
            {
                ((Item)checkedItem.Tag).SetTradeCredit(amount);
            }

            cart.UpdateListView();
            UpdateLabels();
        }

        private void btnChangeTotal_Click(object sender, EventArgs e)
        {
            // Create a new "Discount" item with a negative price value...?
            bool percent = false;
            decimal amount;
            string temp = discountTextBox.Text;

            percent = IsPercent(ref temp);

            try
            {
                amount = Convert.ToDecimal(temp);
            }
            catch
            {
                MessageBox.Show("The value in the textbox is probably invalid.", "Something Went Wrong", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (percent)
            {
                amount = Convert.ToDecimal(.01M * amount * cart.cartTotal);
                cart.UpdateTotals();
                cart.AddItem(new Item("Extra", "Extra", 0, 1, amount, amount, Constants.DISCOUNTUPC));
            }

            else
            {
                cart.AddItem(new Item("Extra", "Extra", 0, 1, amount, amount, Constants.DISCOUNTUPC));
            }

            cart.UpdateListView();
            UpdateLabels();
        }

        private bool IsPercent(ref string input)
        {
            // Check if discount is a percentage
            if (input.Contains('%'))
            {
                input = input.Replace("%", "");
                return true;
            }

            return false;
        }

        private void UpdateLabels()
        {
            POSinventory parent = (POSinventory)listView.Parent.Parent;
            parent.UpdateTotalsLabels();
        }
    }
}
