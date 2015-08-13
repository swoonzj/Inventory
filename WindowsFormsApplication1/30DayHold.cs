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
using System.Diagnostics;

namespace Inventory
{
    public partial class _30DayHold : Form
    {
        Collection hold;

        private string sortBy; // For sorting the ListView by column;
        private bool ascendingorder = true; // Default Ascending order (A->Z)

        public _30DayHold()
        {
            InitializeComponent();
        }

        private void _30DayHold_Load(object sender, EventArgs e)
        {
            hold = DBaccess.SQLTableToCollection(TableNames._30DAYHOLD);
        }

        // tbl30DayHold
        // [0] = Name
        // [1] = System
        // [2] = Quantity
        // [3] = Date



        // Fill in ListView with entire Inventory table
        private void populateList(string tablename)
        {

            //lvResults.Items.Clear(); // clear old results
            //SqlConnection connect = new SqlConnection(Properties.Settings.Default.StoreDatabaseConnectionString1);
            //SqlCommand cmd = new SqlCommand("SELECT * FROM " + tablename, connect);

            //connect.Open();
            //SqlDataReader reader = cmd.ExecuteReader();
            //string records = string.Empty;
            //DateTime date, nextMonth;
            //int compareDates;
            //date = DateTime.Today;

            //while (reader.Read() == true)
            //{
            //    nextMonth = Convert.ToDateTime(reader[3].ToString()).AddMonths(1); // 1 month after item is put in Hold
            //    compareDates = DateTime.Compare(date.Date, nextMonth.Date);

            //    // If Radio Button "Show Ready to be Released" is selected, 
            //    // only show items that have been in the hold for over 1 month
            //    if (rdoShowAll.Checked || (rdoShowReadyToRelease.Checked && compareDates >= 0))
            //    {

            //        ListViewItem item = new ListViewItem(reader[0].ToString()); //Name
            //        item.SubItems.Add(reader[1].ToString()); //System
            //        item.SubItems.Add(reader[2].ToString()); //Quantity
            //        item.SubItems.Add(nextMonth.AddMonths(-1).ToShortDateString()); //Date put in Hold
            //        item.SubItems.Add(nextMonth.ToShortDateString()); //Date able to released from Hold

            //        lvResults.Items.Add(item);
            //    }
            //}
            //connect.Close();
        }

        private void rdoShowReadyToRelease_CheckedChanged(object sender, EventArgs e)
        {
            //populateList("tbl30DayHold");
        }

        // Take items off of the Hold & put them into the store inventory
        private void btnReleaseAllReady_Click(object sender, EventArgs e)
        {
            //rdoShowReadyToRelease.Checked = true; // Change list to show only releasable items - for ease of programming

            //foreach (ListViewItem item in lvResults.Items)
            //{
            //    DBaccess.IncrementInventory(item.SubItems[0].Text, item.SubItems[1].Text, Convert.ToInt32(item.SubItems[2].Text));
            //    DBaccess.RemoveItemFrom30DayHold(item.SubItems[0].Text, item.SubItems[1].Text, item.SubItems[3].Text);
            //    DBaccess.AddTo30DayHoldList(item.SubItems[0].Text, item.SubItems[1].Text, item.SubItems[2].Text, "Inventory");
            //}
            //populateList("tbl30DayHold");
        }

        // tbl30DayHold
        // [0] = Name
        // [1] = System
        // [2] = Quantity
        // [3] = Date

        // Take selected (checked) items off of 30 Day hold
        private void btnReleaseSelected_Click(object sender, EventArgs e)
        {
            //DateTime date, nextMonth;
            //int compareDates;
            //date = DateTime.Today;

            //// Make sure checkboxes are enabled and that items are checked
            //if (lvResults.CheckBoxes == false || lvResults.CheckedItems.Count == 0)
            //{
            //    MessageBox.Show("There are no items checked, or checkboxes are not enabled.");
            //    return;
            //}

            //foreach (ListViewItem item in lvResults.CheckedItems)
            //{
            //    // Double check that Items are past 30 day minimum
            //    nextMonth = Convert.ToDateTime(item.SubItems[4].Text); // 1 month after item is put in Hold
            //    compareDates = DateTime.Compare(date.Date, nextMonth.Date);

            //    // Ask user if date is premature
            //    if (compareDates < 0)
            //    {
            //        string itemname = item.SubItems[0].Text;
            //        DialogResult result = MessageBox.Show("This item has been on hold for less than 30 days:\n" + itemname + "\nProceed anyway?", "Too soon, too soon.", MessageBoxButtons.YesNoCancel);
            //        if (result == DialogResult.No) continue;
            //        if (result == DialogResult.Cancel) return;
            //    }

            //    // If everything is all set, increment inventory & remove item from 30 Day Hold
            //    DBaccess.IncrementInventory(item.SubItems[0].Text, item.SubItems[1].Text, Convert.ToInt32(item.SubItems[2].Text));
            //    DBaccess.RemoveItemFrom30DayHold(item.SubItems[0].Text, item.SubItems[1].Text, item.SubItems[3].Text);
            //    DBaccess.AddTo30DayHoldList(item.SubItems[0].Text, item.SubItems[1].Text, item.SubItems[2].Text, "Inventory");
            //}
            //populateList("tbl30DayHold");
        }

        // Take selected items off of the Hold, but do not inventory
        private void btnDoNotInventory_Click(object sender, EventArgs e)
        {
        //    DateTime date, nextMonth;
        //    int compareDates;
        //    date = DateTime.Today;

        //    // Make sure checkboxes are enabled and that items are checked
        //    if (lvResults.CheckBoxes == false || lvResults.CheckedItems.Count == 0)
        //    {
        //        MessageBox.Show("There are no items checked, or checkboxes are not enabled.");
        //        return;
        //    }

        //    foreach (ListViewItem item in lvResults.CheckedItems)
        //    {
        //        // Double check that Items are past 30 day minimum
        //        nextMonth = Convert.ToDateTime(item.SubItems[4].Text); // 1 month after item is put in Hold
        //        compareDates = DateTime.Compare(date.Date, nextMonth.Date);

        //        // Ask user if date is premature
        //        if (compareDates < 0)
        //        {
        //            string itemname = item.SubItems[0].Text;
        //            DialogResult result = MessageBox.Show("This item has been on hold for less than 30 days:\n" + itemname + "\nProceed anyway?", "Too soon, too soon.", MessageBoxButtons.YesNoCancel);
        //            if (result == DialogResult.No) continue;
        //            if (result == DialogResult.Cancel) return;
        //        }

        //        // If everything is all set, *ONLY* remove item from 30 Day Hold
        //        DBaccess.RemoveItemFrom30DayHold(item.SubItems[0].Text, item.SubItems[1].Text, item.SubItems[3].Text);
        //        DBaccess.AddTo30DayHoldList(item.SubItems[0].Text, item.SubItems[1].Text, item.SubItems[2].Text, "DNI"); // DNI = Do Not Inventory
        //    }
        //    populateList("tbl30DayHold");
        }

        // Enable/disable checkboxes
        private void chkSelect_CheckStateChanged(object sender, EventArgs e)
        {
        //    if (chkSelect.Checked)
        //        lvResults.CheckBoxes = true;
        //    else
        //        lvResults.CheckBoxes = false;
        }

        private void btnCreateListFile_Click(object sender, EventArgs e)
        {
        //    string filepath = DBaccess.Create30DayHoldRemovalList();
        //    string args = string.Format("/Select, {0}", filepath);

        //    if (filepath != "NO")
        //    {
        //        // Opens Windows Explorer to the location of the created file.
        //        ProcessStartInfo pfi = new ProcessStartInfo("Explorer.exe", args);
        //        System.Diagnostics.Process.Start(pfi);
        //    }
        }
    }
}
