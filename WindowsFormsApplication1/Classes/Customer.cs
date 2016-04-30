using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inventory
{
    public class Customer
    {
        public int id { get; private set; } // If not retrieved from DB, given ID of -1
        public string name { get; set; }
        public string email { get; set; }
        public string phoneNumber { get; set; }

        public Collection WaitList;

        public Customer(string name, string email = "", string phoneNumber = "", int id = -1)
        {
            this.name = name;
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.id = id;

            WaitList = new Collection();
        }

        public void AddItemToWaitList(Item item)
        {
            WaitList.AddItem(item);
        }

        public void RemoveItemFromWaitList(Item item)
        {
            WaitList.RemoveItem(item);
        }
        /// <summary>
        /// Returns a collection containing the items in a customer's WaitList which are currently in stock
        /// </summary>
        /// <returns>A Collection of items on the customer's WaitList which are in stock</returns>
        public Collection WaitListItemsInStock()
        {
            
            Collection itemsInStock = new Collection();

            foreach (Item item in WaitList)
            {
                // If a WaitList item is in stock, add to Collection itemsInStock
                if (DBaccess.IsItemInStock(item) == true)
                {
                    itemsInStock.AddItem(item);
                }
            }

            return itemsInStock;
        }

        // FIGURE OUT HOW TO GET THE CUSTOMER'S SQL TABLE ID!!!!!!!



        // Update Customer Info in DB.
        public void saveDataToDB()
        {
            try
            {
                // If the Customer does not have a valid table ID, save info to DB, retrieve ID.
                if (id == -1)
                {
                    this.id = DBaccess.AddToCustomerList(this);
                }
                
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error in Customer.saveDataToDB():\n" + ex.Message);
            }
        }
    }
}
