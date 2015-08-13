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
    public partial class EditCart : Form
    {
        ListView listView;
        TextBox discountTextBox;
        TextBox quantityTextBox;
        Cart cart;

        public EditCart(ListView listView, Cart cart)
        {
            this.listView = listView;
            this.cart = cart;
            
            InitializeComponent();

            this.discountTextBox = this.txtDiscount;
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

        private void btnDiscountItem_Click(object sender, EventArgs e)
        {
            bool percent = false;
            decimal discount, amount;
            string temp = discountTextBox.Text;

            // Check if discount is a percentage
            percent = IsPercent(ref temp);

            // Make sure input is a valid number & convert to decimal
            try
            {
                amount = Convert.ToDecimal(temp);
            }
            catch
            {
                MessageBox.Show("The value in the textbox is probably invalid.", "Something Went Wrong", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            foreach (ListViewItem checkedItem in listView.CheckedItems)
            {
                // Calculate and apply discount to each item
                if (percent)
                    discount = Convert.ToDecimal(((Item)checkedItem.Tag).price) * (amount / 100);
                else
                    discount = amount;

                ((Item)checkedItem.Tag).SetPrice(((Item)checkedItem.Tag).price - discount);
            }

            cart.UpdateListView();
            UpdateLabels();
        }

        private void btnDiscountTotal_Click(object sender, EventArgs e)
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
                amount = Convert.ToDecimal(0 - (.01M * amount * cart.cartTotal));
                cart.UpdateTotals();
                cart.AddItem(new Item("Discount", "Discount", amount, 1, 0, 0, Constants.DISCOUNTUPC));
            }

            else
            {
                cart.AddItem(new Item("Discount", "Discount", (0 - amount), 1, 0, 0, Constants.DISCOUNTUPC));
            }

            cart.UpdateListView();
            UpdateLabels();
        }

        private void btnChangePrice_Click(object sender, EventArgs e)
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
                ((Item)checkedItem.Tag).SetPrice(amount);
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
