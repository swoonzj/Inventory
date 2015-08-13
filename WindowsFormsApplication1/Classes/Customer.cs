using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Inventory.Classes
{
    class Customer
    {
        public string name { get; private set; }
        public string email { get; private set; }
        public string phoneNumber { get; private set; }

        Collection wishList;

        Customer(string name, string email = "", string phoneNumber = "")
        {
            this.name = name;
            this.email = email;
            this.phoneNumber = phoneNumber;

            wishList = new Collection();
        }

        public void AddItemToWishList(Item item)
        {
            wishList.AddItem(item);
        }

        public void RemoveItemFromWishList(Item item)
        {
            wishList.RemoveItem(item);
        }
        /// <summary>
        /// Returns a collection containing the items in a customer's WishList which are currently in stock
        /// </summary>
        /// <returns>A Collection of items on the customer's WishList which are in stock</returns>
        public Collection WishListItemsInStock()
        {
            
            Collection itemsInStock = new Collection();

            foreach (Item item in wishList)
            {
                if (DBaccess.IsItemInStock(item) == true)
                {
                    itemsInStock.AddItem(item);
                }
            }

            return itemsInStock;
        }
    }
}
