using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Inventory
{
    class DynamicListView
    {
        public ListView listView {get; private set;} 
        public Collection inventory {get; private set;}
        private int lvType;
        private string sourceTable;
        
        // Column sorting variables
        private string sortBy;
        private bool ascendingOrder = true; // Default Ascending order (A->Z)
        public string searchText {get; set; }
        public bool hideOutOfStock { get; set; }

        /// <summary>
        /// DynamicListView Constructor
        /// </summary>
        /// <param name="lv">The existing ListView to be altered dynamically</param>
        /// <param name="table">The name of the table to populate the ListView with. Should be a "TableName".</param>
        /// <param name="ListViewType">The ListViewType (as an int) to be represented in the ListView</param>
        /// <param name="CheckBoxes">Toggle appearance of checkboxes in ListView</param>
        public DynamicListView(ListView lv, string table, int ListViewType, bool CheckBoxes)
        {
            listView = lv;
            sourceTable = table;
            lvType = ListViewType;
            listView.CheckBoxes = CheckBoxes;
            listView.ColumnClick += listView_ColumnClick;

            hideOutOfStock = false; // Do not hide out of stock items by default
                        
            ConfigureColumns();
            PopulateList();
        }

        public DynamicListView(ListView lv, Collection collection, int ListViewType, bool CheckBoxes)
        {
            listView = lv;
            inventory = collection;
            lvType = ListViewType;
            listView.CheckBoxes = CheckBoxes;
            listView.ColumnClick += listView_ColumnClick;

            hideOutOfStock = false; // Do not hide out of stock items by default

            ConfigureColumns();
            PopulateListFromCollection();
        }

        /// <summary>
        /// Sets up the columns of the ListView according to the ListViewType
        /// </summary>
        private void ConfigureColumns()
        {
            // Delete any previous columns, if any
            listView.Columns.Clear();

            // For Management screens, show all item information
            if (lvType == ListViewType.MANAGEMENT)
            {
                listView.Columns.Add(ListViewColumnNames.NAME);
                listView.Columns.Add(ListViewColumnNames.SYSTEM);
                listView.Columns.Add(ListViewColumnNames.PRICE);
                listView.Columns.Add(ListViewColumnNames.QUANTITY);
                listView.Columns.Add(ListViewColumnNames.TRADE_CASH);
                listView.Columns.Add(ListViewColumnNames.TRADE_CREDIT);
                listView.Columns.Add(ListViewColumnNames.UPC);
            }

            // For Cart screens, show only Name, System, Price, Quantity, Item Total
            if (lvType == ListViewType.CART)
            {
                listView.Columns.Add(ListViewColumnNames.NAME);
                listView.Columns.Add(ListViewColumnNames.SYSTEM);
                listView.Columns.Add(ListViewColumnNames.PRICE);
                listView.Columns.Add(ListViewColumnNames.QUANTITY);
                listView.Columns.Add(ListViewColumnNames.ITEM_TOTAL);
            }

            // For Trade-Cart screens, show only Name, System, Quantity, Cash, Credit
            if (lvType == ListViewType.TRADECART)
            {
                listView.Columns.Add(ListViewColumnNames.NAME);
                listView.Columns.Add(ListViewColumnNames.SYSTEM);
                listView.Columns.Add(ListViewColumnNames.QUANTITY);
                listView.Columns.Add(ListViewColumnNames.TRADE_CASH);
                listView.Columns.Add(ListViewColumnNames.TRADE_CREDIT);
            }

            // For POS screens, show only Name, System, Price, Quantity, Cash, Credit
            if (lvType == ListViewType.POS)
            {
                listView.Columns.Add(ListViewColumnNames.NAME);
                listView.Columns.Add(ListViewColumnNames.SYSTEM);
                listView.Columns.Add(ListViewColumnNames.PRICE);
                listView.Columns.Add(ListViewColumnNames.QUANTITY);
                listView.Columns.Add(ListViewColumnNames.TRADE_CASH);
                listView.Columns.Add(ListViewColumnNames.TRADE_CREDIT);
            }
        }

        /// <summary>
        /// Automatically sets the column width based on largest item width for Name and System, and by Column Header width for the remainder.
        /// </summary>
        public void AutoSetColumnWidth()
        {
            int tempWidth;
            listView.BeginUpdate();
            listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize); // Resize all columns based on Column title length
            tempWidth = listView.Columns[1].Width; // Save width for comparison
            listView.Columns[0].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent); // Then resize both Name and System columns...
            listView.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent); // ...  according to largest item value

            // If system column width is smaller than the title "system", then auto-fit the column to HeaderSize
            if (listView.Columns[1].Width < tempWidth)
                listView.Columns[1].AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);

            listView.EndUpdate();
        }

        public void PopulateList()
        {
            // If sourceTable is null and the inventory Collection is populated, call PopulateListFromCollection() instead
            if (sourceTable == null && inventory != null)
            {
                PopulateListFromCollection(null);
                return;
            }

            // Update Inventory List
            inventory = DBaccess.SQLTableToCollection(sourceTable, sortBy, ascendingOrder, searchText);
            // Disable Drawing (for speed)
            listView.BeginUpdate();
            // Populate listview
            inventory.PopulateListView(listView, hideOutOfStock, lvType, searchText);            
            // Adjust column widths
            AutoSetColumnWidth();
            //Allow Drawing
            listView.EndUpdate();
        }

        /// <summary>
        /// Populates the listview with items from the current Collection, NOT from a SQL table
        /// </summary>
        /// <param name="newCollection">A new collection to populate the ListView with. If left NULL, ListView will populate with internal collection.</param>
        public void PopulateListFromCollection(Collection newCollection = null)
        {
            // Set new Inventory Collection if a new Collection was passed in
            if (newCollection != null)
            {
                inventory = newCollection;
            }

            // Populate ListView
            inventory.PopulateListView(listView, hideOutOfStock, lvType, searchText);

            // Adjust column widths
            AutoSetColumnWidth();
        }

        /// <summary>
        /// Adjust the sorting 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            string columnName = SQLTableColumnNames.SYSTEM;

            // Acquire clicked column's Title 
            int columnIndex = e.Column;
            string columnText = listView.Columns[columnIndex].Text;
            
            // Assign sqlTable Column name to a temporary variable, columnName
            if (columnText == ListViewColumnNames.NAME)
                columnName = SQLTableColumnNames.NAME;
            if (columnText == ListViewColumnNames.SYSTEM)
                columnName = SQLTableColumnNames.SYSTEM;
            if (columnText == ListViewColumnNames.PRICE)
                columnName = SQLTableColumnNames.PRICE;
            if (columnText == ListViewColumnNames.QUANTITY)
                columnName = SQLTableColumnNames.QUANTITY;
            if (columnText == ListViewColumnNames.TRADE_CASH)
                columnName = SQLTableColumnNames.TRADE_CASH;
            if (columnText == ListViewColumnNames.TRADE_CREDIT)
                columnName = SQLTableColumnNames.TRADE_CREDIT;
            if (columnText == ListViewColumnNames.UPC)
                columnName = SQLTableColumnNames.UPC;
            if (columnText == ListViewColumnNames.DATE)
                columnName = SQLTableColumnNames.DATE;

            // If the same column was clicked, reverse sorting order
            if (sortBy == columnName)
            {
                ascendingOrder = !ascendingOrder;
            }

            else
            {
                ascendingOrder = true;
                sortBy = columnName;
            }

            PopulateList();
        }

        /// <summary>
        /// Set the anchors of the listview
        /// </summary>
        /// <param name="styles">An array of AnchorStyles</param>
        public void anchor(params AnchorStyles[] styles)
        {
            AnchorStyles totalStyle = styles[0];

            foreach (AnchorStyles style in styles)
            {                
                 totalStyle = totalStyle | style;
            }
        }
    }
}
