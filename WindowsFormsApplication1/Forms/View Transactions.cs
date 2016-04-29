using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Inventory
{
    public partial class View_Transactions : Form
    {
        Collection inventory;
        Collection bestSellers;
        string transactionType = TransactionTypes.SALE;
        string sortBy = "TransactionNumber";
        bool ascending = false;

        public View_Transactions()
        {
            InitializeComponent();
        }

        private void View_Transactions_Load(object sender, EventArgs e)
        {            
            populateList();
            getTotals();
        }

        private void populateList()
        {            
            lvTransactions.Items.Clear(); // clear old results
            UpdateInventoryCollection();
            inventory.PopulateListView(lvTransactions, false, ListViewType.TRANSACTION);
        }

        private void UpdateInventoryCollection()
        {
            inventory = DBaccess.TransactionTableToCollection(sortBy, ascending);
        }

        private void populateBestsellingItemsList()
        {
            // Clear previous results
            lvBestsellers.Items.Clear();

            // Get new results
            bestSellers = DBaccess.GetBestSellingItems(transactionType, ascending);

            foreach (Item item in bestSellers.items)
            {
                ListViewItem lvItem = new ListViewItem(item.name);
                lvItem.SubItems.Add(item.system);
                lvItem.SubItems.Add(item.quantity.ToString());

                lvBestsellers.Items.Add(lvItem);
            }
        }

        private void getTotals()
        {
            decimal dailySales = 0, dailyTrade = 0, dailyTotal = 0;
            decimal monthlySales = 0, monthlyTrade = 0, monthlyTotal = 0;
            decimal yearlySales = 0, yearlyTrade = 0, yearlyTotal = 0;
            //decimal lastMonthTotal = 0, lastMonthSales = 0;
        
            // Yearly 
            yearlySales = DBaccess.GetTransactionMonetaryTotal(TransactionTypes.SALE, GetBeginningOfYear(), GetBeginningOfYear().AddYears(1));
            yearlyTrade = DBaccess.GetTransactionMonetaryTotal(TransactionTypes.TRADE_CASH, GetBeginningOfYear(), GetBeginningOfYear().AddYears(1));
            yearlyTotal = yearlySales - yearlyTrade;
            
            // Monthly
            monthlySales = DBaccess.GetTransactionMonetaryTotal(TransactionTypes.SALE, GetBeginningOfMonth(), GetBeginningOfMonth().AddMonths(1));
            monthlyTrade = DBaccess.GetTransactionMonetaryTotal(TransactionTypes.TRADE_CASH, GetBeginningOfMonth(), GetBeginningOfMonth().AddMonths(1));
            monthlyTotal = monthlySales - monthlyTrade;
            
            // daily sales
            dailySales = DBaccess.GetTransactionMonetaryTotal(TransactionTypes.SALE, GetBeginningOfDay(), GetBeginningOfDay().AddDays(1));
            dailyTrade = DBaccess.GetTransactionMonetaryTotal(TransactionTypes.TRADE_CASH, GetBeginningOfDay(), GetBeginningOfDay().AddDays(1));
            dailyTotal = dailySales - dailyTrade;

            // Update labels
            lblDailySales.Text = dailySales.ToString("C");
            lblDailyTrade.Text = dailyTrade.ToString("C");
            lblDailyTotal.Text = dailyTotal.ToString("C");

            lblMonthlySales.Text = monthlySales.ToString("C");
            lblMonthlyTrade.Text = monthlyTrade.ToString("C");
            lblMonthlyTotal.Text = monthlyTotal.ToString("C");

            lblYearlySales.Text = yearlySales.ToString("C");
            lblYearlyTrade.Text = yearlyTrade.ToString("C");
            lblYearlyTotal.Text = yearlyTotal.ToString("C");

            // Change label colors depending on positive or negative profit
            if (dailyTotal >= 0)
                lblDailyTotal.ForeColor = Color.Black;
            else
                lblDailyTotal.ForeColor = Color.Red;

            if (monthlyTotal >= 0)
                lblMonthlyTotal.ForeColor = Color.Black;
            else
                lblMonthlyTotal.ForeColor = Color.Red;

            if (yearlyTotal >= 0)
                lblYearlyTotal.ForeColor = Color.Black;
            else
                lblYearlyTotal.ForeColor = Color.Red;

            return;
        }

        private DateTime GetBeginningOfYear()
        {
            DateTime date = GetBeginningOfMonth().AddMonths(1 - (DateTime.Today.Month));
            return date.Date;
        }

        private DateTime GetBeginningOfMonth()
        {
            DateTime date = DateTime.Today.AddDays(1 - (DateTime.Today.Day));
            return date.Date;
        }

        private DateTime GetBeginningOfDay()
        {
            DateTime date = DateTime.Today.Date;
            return date.Date;
        }

        private void btnInventoryValue_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Total Value of Store Inventory:\n" + DBaccess.GetInventoryValue().ToString("C"), "Inventory value");
        }

        private void btnTransactions_Click(object sender, EventArgs e)
        {
            ascending = false;
            lvTransactions.Visible = true;
            lvBestsellers.Visible = false;
            populateList();
        }

        private void btnBestselling_Click(object sender, EventArgs e)
        {
            ascending = false;
            transactionType = TransactionTypes.SALE;
            lvBestsellers.Visible = true;
            lvTransactions.Visible = false;
            populateBestsellingItemsList();
        }

        private void mostTradedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ascending = false;
            transactionType = TransactionTypes.TRADE_CASH + "' OR Type='" + TransactionTypes.TRADE_CREDIT;
            lvBestsellers.Visible = true;
            lvTransactions.Visible = false;
            populateBestsellingItemsList();
        }

        private void mostTradedCashToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ascending = false;
            transactionType = TransactionTypes.TRADE_CASH;
            lvBestsellers.Visible = true;
            lvTransactions.Visible = false;
            populateBestsellingItemsList();
        }

        private void mostTradedCreditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ascending = false;
            transactionType = TransactionTypes.TRADE_CREDIT;
            lvBestsellers.Visible = true;
            lvTransactions.Visible = false;
            populateBestsellingItemsList();
        }

        private void lvTransactions_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            string columnName;

            // Name SQL table column based on which column is clicked in the ListView 
            switch (e.Column)
            {
                case 0:
                    columnName = "TransactionNumber";
                    break;
                case 1:
                    columnName = "Name";
                    break;
                case 2:
                    columnName = "System";
                    break;
                case 3:
                    columnName = "Price";
                    break;
                case 4:
                    columnName = "Quantity";
                    break;
                case 5:
                    columnName = "Type";
                    break;
                case 8:
                    columnName = "Date";
                    break;
                default:
                    columnName = "TransactionNumber"; // Should never be able to get here
                    break;
            }

            // If the same column is clicked, reverse sorting order
            if (sortBy == columnName) ascending = !ascending;
            else
            {
                ascending = true; // (A->Z by default)
                sortBy = columnName;
            }

            // Update inventory & ListView
            populateList();
        }

        private void lvBestsellers_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            string columnName;

            // Name SQL table column based on which column is clicked in the ListView 
            switch (e.Column)
            {
                case 0:
                    columnName = "Name";
                    break;
                case 1:
                    columnName = "System";
                    break;
                case 3:
                    columnName = "Total";
                    break;
                default:
                    columnName = "Total"; // Should never be able to get here
                    break;
            }

            // If the same column is clicked, reverse sorting order
            if (sortBy == columnName) ascending = !ascending;
            else
            {
                ascending = true; // (A->Z by default)
                sortBy = columnName;
            }

            // Update inventory & ListView
            populateBestsellingItemsList();
        }

    }
}
