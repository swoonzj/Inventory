using System;
using System.Collections;
using System.IO;
using System.Windows.Forms;

namespace Inventory
{
    public class Collection : IEnumerable
    {
        public ArrayList items { get; set; }

        #region IEnumerator Stuff

        public IEnumerator GetEnumerator()
        {
            return (IEnumerator)new CollectionEnumerator(this);
        }

        // For use with foreach
        private class CollectionEnumerator : IEnumerator
        {
            private Collection _collection;
            private int _index;

            public CollectionEnumerator(Collection collection)
            {
                _collection = collection;
                _index = -1;
            }

            public void Reset()
            {
                _index = -1;
            }

            public object Current
            {
                get
                {
                    return _collection.items[_index];
                }
            }

            public bool MoveNext()
            {
                _index++;
                if (_index >= _collection.items.Count)
                    return false;
                else
                    return true;
            }
        }
        #endregion

        public Collection()
        {
            items = new ArrayList();
        }

        public int Count()
        {
            return items.Count;
        }

        public void AddItem(Item item)
        {
            items.Add(item);
        }

        /// <summary>
        /// Adds item (quantity = 1) containing the provided UPC to the collection 
        /// </summary>
        /// <param name="UPC">A string containing the UPC value</param>
        public void AddItemFromUPC(string tablename, string UPC)
        {
            Item item = DBaccess.GetItemWithUPC(tablename, UPC);

            object obj = ItemInCollection(item);
            if (obj != null)
            {
                ((Item)(obj)).SetQuantity(((Item)obj).quantity + 1);
            }

            else
            {
                Item temp = item.Clone();
                temp.SetQuantity(1);
                AddItem(temp);
            }
        }

        public void RemoveItem(Item item)
        {
            items.Remove(item);
        }

        /// <summary>
        /// Empties current collection, then fills it with items from a given .CSV
        /// </summary>
        /// <param name="filepath"></param>
        /// <param name="numColumns"></param>
        public void LoadCSV(string filepath, int numColumns /*number of columns to import */ ) // Add items from a Comma Separated Value file to the inventory
        {
            // Remove all items from collection before proceeding
            items.Clear();

            Item item;
            string[] allLines = File.ReadAllLines(filepath);  //
            string[] line = new string[6];                                //
            foreach (string s in allLines)                    // Read CSV file.
            {                                             // Each Line of file is 
                //line = s.Split(new Char[] { ',' });       // stored in line[].


                line = ParseCSV(s);

                switch (numColumns)
                {
                    case 1:
                        item = new Item(line[0]);
                        break;
                    case 2:
                        item = new Item(line[0], line[1]);
                        break;
                    case 3:
                        item = new Item(line[0], line[1], line[2]);
                        break;
                    case 4:
                        item = new Item(line[0], line[1], line[2], line[3], "0", "0", "0");
                        break;
                    case 5:
                        item = new Item(line[0], line[1], line[2], line[3], line[4], "0", "0");
                        break;
                    case 6:
                        item = new Item(line[0], line[1], line[2], line[3], line[4], line[5], "0");
                        break;
                    case 7:
                        item = new Item(line[0], line[1], line[2], line[3], line[4], line[5], line[6]);
                        break;
                    default:
                        return;
                }

                // Add item to collection
                items.Add(item);
            }
        }

        // Used by loadCSV() to identify individual lines in the file. Returns each line, separated into strings
        private static string[] ParseCSV(string input)
        {
            string temp = string.Empty;  //each individual word/string
            string[] strarray = new string[20]; // each line, separated by commas
            int j = 0;
            bool quote = false;
            foreach (char c in input)
            {
                if (j > 20) { MessageBox.Show("Too many columns in CSV file. \n(Maximum of 20 allowed)"); break; } // Prevent improper array indexing
                if (c == '\"' && !quote) quote = true;   // Test for first ' " '  (quotation mark)
                else if (c == '\"' && quote) quote = false; // Test for second quotation mark
                else if ((c == ',' && quote == false) || c == '\n') // if comma is encountered & no quotations, add 'temp' to 'strarray'
                {                                                   // Or if a newline is encountered (end of line)
                    if (temp == string.Empty) temp = "0";
                    strarray[j] = temp.Trim();
                    j++;
                    temp = string.Empty;
                }
                else temp += c;
            }
            if (strarray[0] == null) // make sure strarray isn't returned with null
                strarray[0] = temp;  // necessary if CSV file has only 1 item per line with no commas
            return strarray;
        }

        public bool InCollection(Item item)
        {
            foreach (Item collectionItem in items)
                if (String.Compare(collectionItem.name, item.name) == 0 && String.Compare(collectionItem.system, item.system) == 0 && collectionItem.price == item.price)
                    return true;

            return false;
        }

        public bool InCollection(HoldItem item)
        {
            foreach (HoldItem collectionItem in items)
                if (String.Compare(collectionItem.name, item.name) == 0 && String.Compare(collectionItem.system, item.system) == 0 && collectionItem.price == item.price)
                    return true;

            return false;
        }

        /// <summary>
        /// Checks if passed item is currently in the collection by comparing the "name", "system", and "price" fields.
        /// If the item is in the collection, the item is returned. Otherwise, NULL is returned.
        /// </summary>
        /// <param name="item">Item to find in collection</param>
        /// <returns>Item (if in collection) or NULL</returns>
        public Item ItemInCollection(Item item)
        {
            foreach (Item collectionItem in items)
                if (String.Compare(collectionItem.name, item.name) == 0 && String.Compare(collectionItem.system, item.system) == 0 && collectionItem.price == item.price)
                    return collectionItem;

            return null;
        }

        /// <summary>
        /// Populates the provided ListView with the items in the collection
        /// </summary>
        /// <param name="lv">ListView to populate</param>
        /// <param name="hideOutOfStock">True: Do not show items which have no quantity. False: Show all items.</param>
        /// <param name="listViewType">ListViewType indicating the column headers which are used</param>
        public void PopulateListView(ListView lv, bool hideOutOfStock, ListViewType listViewType, string searchText = "")
        {
            // searchText cannot be null
            if (searchText == null) searchText = "";
            SearchTerms searchTerms = new SearchTerms(searchText);
            int searchCount;

            // Clear list
            lv.Items.Clear();

            if (listViewType != ListViewType._30DAYHOLD && listViewType != ListViewType.TRANSACTION)
            {
                foreach (Item item in items)
                {
                    // Hide items that are out of stock, if desired
                    if (hideOutOfStock && item.quantity <= 0)
                        continue;

                    ListViewItem lvItem = new ListViewItem(item.name);

                    if (listViewType == ListViewType.POS)
                    {
                        lvItem.SubItems.Add(item.system);
                        lvItem.SubItems.Add(item.price.ToString("C"));
                        lvItem.SubItems.Add(item.quantity.ToString());
                        lvItem.SubItems.Add(item.tradeCash.ToString("C"));
                        lvItem.SubItems.Add(item.tradeCredit.ToString("C"));
                    }

                    if (listViewType == ListViewType.CART)
                    {
                        lvItem.SubItems.Add(item.system);
                        lvItem.SubItems.Add(item.price.ToString("C"));
                        lvItem.SubItems.Add(item.quantity.ToString());
                        lvItem.SubItems.Add((item.quantity * item.price).ToString("C")); // Item Total
                    }

                    if (listViewType == ListViewType.TRADECART)
                    {
                        lvItem.SubItems.Add(item.system);
                        lvItem.SubItems.Add(item.quantity.ToString());
                        lvItem.SubItems.Add((item.tradeCash * item.quantity).ToString("C"));
                        lvItem.SubItems.Add((item.tradeCredit * item.quantity).ToString("C"));
                    }

                    if (listViewType == ListViewType.MANAGEMENT)
                    {
                        lvItem.SubItems.Add(item.system);
                        lvItem.SubItems.Add(item.price.ToString("C"));
                        lvItem.SubItems.Add(item.quantity.ToString());
                        lvItem.SubItems.Add(item.tradeCash.ToString("C"));
                        lvItem.SubItems.Add(item.tradeCredit.ToString("C"));
                        lvItem.SubItems.Add(item.UPC.ToString());

                    }
                    // Reset searchcount to 0
                    searchCount = 0;
                    // Only add items that match the search text
                    foreach (string term in searchTerms.terms)
                    {
                        // If the item name OR the system name contains a search term,
                        // increment searchCount.
                        //
                        // If searchCount >= to the number of terms, add item to listView
                        if (item.name.ToUpper().Contains(term.ToUpper()) || item.system.ToUpper().Contains(term.ToUpper()))
                        {
                            searchCount++;
                        }
                    }

                    if (searchCount >= searchTerms.terms.Count)
                    {
                        // Tag/associate listview item with inventory item
                        lvItem.Tag = item;
                        lv.Items.Add(lvItem);

                    }
                }
            }

            else if (listViewType == ListViewType._30DAYHOLD)
            {
                foreach (HoldItem item in items)
                {
                    ListViewItem lvItem = new ListViewItem(item.name); //Name
                    lvItem.SubItems.Add(item.system);
                    lvItem.SubItems.Add(item.price.ToString("C"));
                    lvItem.SubItems.Add(item.quantity.ToString());
                    lvItem.SubItems.Add(item.tradeCash.ToString("C"));
                    lvItem.SubItems.Add(item.tradeCredit.ToString("C"));
                    lvItem.SubItems.Add(item.UPC.ToString());
                    lvItem.SubItems.Add(item.dateIn.ToString());
                    lvItem.SubItems.Add(item.dateOut.ToString());

                    // Tag/associate listview item with inventory item
                    lvItem.Tag = item;
                    lv.Items.Add(lvItem);
                }
            }

            else if (listViewType == ListViewType.TRANSACTION)
            {
                foreach (TransactionItem item in items)
                {
                    ListViewItem lvItem = new ListViewItem(item.transactionNumber.ToString());
                    lvItem.SubItems.Add(item.name);
                    lvItem.SubItems.Add(item.system);
                    lvItem.SubItems.Add(item.price.ToString("C"));
                    lvItem.SubItems.Add(item.quantity.ToString());
                    lvItem.SubItems.Add(item.transactionType);
                    lvItem.SubItems.Add(item.date.ToString());

                    // Tag/associate listview item with inventory item
                    lvItem.Tag = item;
                    lv.Items.Add(lvItem);
                }
            }
        }

        /// <summary>
        /// Adds the collection to an inventory table.
        /// </summary>
        /// <param name="tablename">Name of table to add item</param>
        public void AddToTable(string tablename)
        {
            string date = GetDate();

            if (tablename == TableNames._30DAYHOLD)
            {
                foreach (Item item in items)
                {
                    DBaccess.AddTo30DayHold(item, date);
                }
            }
            else
            {
                foreach (Item item in items)
                {
                    DBaccess.AddToTable(tablename, item);
                }
            }
        }

        public void RemoveFromTable(string tablename)
        {
            {
                foreach (Item item in items)
                {
                    DBaccess.DecrementInventory(tablename, item);
                }
            }
        }

        public void RemoveFrom30DayHold()
        {
            foreach (Item item in items)
            {
                DBaccess.RemoveOldestItemFrom30DayHold(item);
            }
        }
        /// <summary>
        /// Returns the current date and time as a string
        /// </summary>
        /// <returns>A string containing the date and time in this format: "yyyy-MM-dd HH:mm:ss"</returns>
        private string GetDate()
        {
            DateTime date = DateTime.Now;
            return date.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
