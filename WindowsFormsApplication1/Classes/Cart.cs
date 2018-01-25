using System;
using System.Windows.Forms;

namespace Inventory
{
    /// <summary>
    /// Shopping Cart class. Used for Sales and Trade.
    /// </summary>
    public class Cart
    {
        public Collection items = new Collection();
        private ListView listView;
        int listViewType;

        public decimal cartTotal { get; private set; }

        public Cart(ListView lv, int listViewType)
        {
            listView = lv;
            this.listViewType = listViewType;
            cartTotal = 0M;
        }

        /// <summary>
        /// Returns the number of items contained in the cart
        /// </summary>
        /// <returns>(int) number of items in cart</returns>
        public int Count()
        {
            return items.Count();
        }

        /// <summary>
        /// Add an existing item to this cart
        /// </summary>
        /// <param name="item">Item to be added</param>
        public void AddItem(Item item)
        {
            object obj = items.ItemInCollection(item);
            if (obj != null)
            {
                ((Item)(obj)).SetQuantity(((Item)obj).quantity + 1);
            }

            else
            {
                Item temp = item.Clone();
                temp.SetQuantity(1);
                items.AddItem(temp);
            }

            UpdateListView();
        }

        /// <summary>
        /// Adds item containing the provided UPC to the cart 
        /// </summary>
        /// <param name="UPC">A string containing the UPC value</param>
        public void AddItemFromUPC(string tablename, string UPC)
        {
            //Item item = DBaccess.GetItemWithUPC(tablename, UPC);
            //if (item != null)
            //    AddItem(item);
            //else
            //    MessageBox.Show("Error: This UPC is unknown", "Item not recognized", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            Collection collection = DBaccess.GetCollectionWithUPC(tablename, UPC);
            if (collection != null)
            {
               if (collection.Count() == 1)
               {
                   AddItem((Item)collection.items[0]);
               }
               else
               {
                   Item item = null;
                   var form = new MultipleUPCSelector(collection);
                   var result = form.ShowDialog();
                   if (result == DialogResult.OK)
                   {
                       item = form.selectedItem;
                       AddItem(item);
                   }
               }

            }
        }

        /// <summary>
        /// Deletes all items from the cart
        /// </summary>
        public void ClearItems()
        {
            items = new Collection();
        }

        protected string GetDate()
        {
            DateTime date = DateTime.Now;
            return date.ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// Removes the passed item from the cart
        /// </summary>
        /// <param name="item">Item to be removed from cart</param>
        public void RemoveItem(Item item)
        {
            items.RemoveItem(item);
        }

        /// <summary>
        /// Records items in cart to the Transaction database, then empties cart
        /// </summary>
        /// <param name="date"></param>
        public void Sell()
        {
            int transactionNumber = DBaccess.GetNextUnusedTransactionNumber();
            string date = GetDate();

            // If cart is empty, do nothing
            if (Count() == 0) return;

            // Adjust inventory and add items to transaction table
            foreach (Item item in items)
            {
                DBaccess.DecrementInventory(TableNames.INVENTORY, item);
                DBaccess.AddToTransactionTable(TableNames.TRANSACTION, item, TransactionTypes.SALE, transactionNumber, date);
            }

            // Clear item Collection
            ClearItems();
            // Increment Transaction number
            DBaccess.IncrementTransactionNumber();
        }

        /// <summary>
        /// Determines if the item with the matching name and system are currently in the cart
        /// </summary>
        /// <param name="name">Item name</param>
        /// <param name="system">System Name</param>
        /// <returns></returns>
        bool InCart(Item item)
        {
            return items.InCollection(item);
        }

        public void UpdateListView(bool hideZero = false)
        {
            listView.Items.Clear();
            items.PopulateListView(listView, hideZero, listViewType);
            UpdateTotals();
        }

        virtual public void UpdateTotals()
        {
            cartTotal = 0;
            foreach (Item item in items)
            {
                cartTotal += (item.quantity * item.price);
            }
        }
    }

    /// <summary>
    /// TradeCart class. Same as Cart, but modified for dealing with trade.
    /// </summary>
    public class TradeCart : Cart
    {
        public decimal cashTotal { get; private set; }
        public decimal creditTotal { get; private set; }

        public TradeCart(ListView lv, int listViewType)
            : base(lv, listViewType) { }

        override public void UpdateTotals()
        {
            cashTotal = 0;
            creditTotal = 0;
            foreach (Item item in items)
            {
                cashTotal += (item.quantity * item.tradeCash);
                creditTotal += (item.quantity * item.tradeCredit);
            }
        }

        public void Trade(string type)
        {
            int transactionNumber = DBaccess.GetNextUnusedTransactionNumber();
            string date = GetDate();

            // If cart is empty, do nothing
            if (Count() == 0) return;

            // Adjust inventory and add items to transaction table
            foreach (Item item in items)
            {
                //DBaccess.IncrementInventory(TableNames.INVENTORY, item);
                DBaccess.AddToTransactionTable(TableNames.TRANSACTION, item, type, transactionNumber, date);
            }

            // Clear item Collection
            ClearItems();
            // Increment Transaction number
            DBaccess.IncrementTransactionNumber();
        }
    }
}