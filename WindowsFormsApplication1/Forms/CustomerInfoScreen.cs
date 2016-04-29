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
    public partial class CustomerInfoScreen : Form
    {
        private Customer customer;
        private DynamicListView dListView;

        public CustomerInfoScreen(Customer customer)
        {
            InitializeComponent();

            this.customer = customer;

            // Update textboxes with Customer info
            UpdateTextboxes();

            // Update ListView with Customer's waiting list\
            UpdateListView();
        }

        /// <summary>
        /// Fill in the blank textboxes with customer info
        /// </summary>
        private void UpdateTextboxes()
        {
            txtEmail.Text = customer.email;
            txtName.Text = customer.name;
            txtPhone.Text = customer.phoneNumber;
        }

        private void UpdateListView()
        {
            // Configure DynamicListView
            dListView = new DynamicListView(lvResults, customer.WaitList, ListViewType.WAITLIST, false);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            customer.email = txtEmail.Text;
            customer.name = txtName.Text;
            customer.phoneNumber = txtPhone.Text;
            customer.saveDataToDB();
        }
    }
}
