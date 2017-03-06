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
    public partial class NewItem : Form
    {
        public NewItem(string name = "", string system = "", string price = "", string quantity = "", string tradeCash = "", string tradeCredit = "", string upc = "")
        {
            InitializeComponent();

            // Pre-load fields with passed info
            txtName.Text = name;
            txtSystem.Text = system;
            txtPrice.Text = price;
            txtQuantity.Text = quantity;
            txtCash.Text = tradeCash;
            txtCredit.Text = tradeCredit;
            txtUPC.Text = upc;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Verify that input is valid
            if (!CheckType(txtName.Text, typeof(string)))
            {
                MessageBox.Show("Error: The Name \'" + txtName.Text + "\' is invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!CheckType(txtSystem.Text, typeof(string)))
            {
                MessageBox.Show("Error: The System \'" + txtSystem.Text + "\' is invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!CheckType(txtPrice.Text, typeof(decimal)))
            {
                if (txtPrice.Text == String.Empty)
                {
                    txtPrice.Text = "0";
                }
                else
                {
                    MessageBox.Show("Error: The Price \'" + txtPrice.Text + "\' is invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                
            }

            if (!CheckType(txtQuantity.Text, typeof(int)))
            {
                if (txtQuantity.Text == String.Empty)
                {
                    txtQuantity.Text = "0";
                }
                else
                {
                    MessageBox.Show("Error: The Quantity \'" + txtQuantity.Text + "\' is invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            if (!CheckType(txtCash.Text, typeof(decimal)))
            {
                if (txtCash.Text == String.Empty)
                {
                    txtCash.Text = "0";
                }
                else
                {
                    MessageBox.Show("Error: The Cash value \'" + txtCash.Text + "\' is invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            if (!CheckType(txtCredit.Text, typeof(decimal)))
            {
                if (txtCredit.Text == String.Empty)
                {
                    txtCredit.Text = "0";
                }
                else
                {
                    MessageBox.Show("Error: The Credit value \'" + txtCredit.Text + "\' is invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            if (!CheckType(txtUPC.Text, typeof(float)))
            {
                if (txtUPC.Text == String.Empty)
                {
                    txtUPC.Text = "0";
                }
                else
                {
                    MessageBox.Show("Error: The UPC number \'" + txtUPC.Text + "\' is invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }

            if (txtUPC.Text != "0" && DBaccess.IsUPCInUse(txtUPC.Text))
            {
                Item tempItem = DBaccess.GetItemWithUPC(TableNames.INVENTORY, txtUPC.Text);
                MessageBox.Show("Error: The UPC number \'" + txtUPC.Text + "\' is already in use by: \n" + tempItem.name + "\nSystem: " + tempItem.system,
                                    "UPC Already Used", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Input is valid, add to Inventory Database
            Item item = new Item(txtName.Text,
                                    txtSystem.Text,
                                    txtPrice.Text,
                                    txtQuantity.Text,
                                    txtCash.Text,
                                    txtCredit.Text,
                                    txtUPC.Text);

            item.AddToInventory();
            MessageBox.Show("Item successfully added!",
                                    "Success!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            this.Close();
        }

        public Boolean CheckType(String value, Type type)
        {
            try
            {
                var obj = Convert.ChangeType(value, type);
                return true;
            }
            catch (InvalidCastException)
            {
                return false;
            }
            catch (FormatException)
            {
                return false;
            }
            catch (OverflowException)
            {
                return false;
            }
            catch (ArgumentNullException)
            {
                return false;
            }
        }

        private void btnGenerateUPC_Click(object sender, EventArgs e)
        {
            txtUPC.Text = DBaccess.GetNextUnusedUPC().ToString();
            DBaccess.IncrementUPC();
        }
    }
}
