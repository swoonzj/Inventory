using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using Inventory;

namespace Inventory
{

    public static class DBaccess
    {
        //static SqlConnection connect = new SqlConnection(Properties.Settings.Default.StoreDatabaseConnectionString); // For final version (store version)
        static SqlConnection connect = new SqlConnection(Properties.Settings.Default.StoreDatabaseConnectionString2); // For testing

        // Export table to Comma Separated Values file (.csv)
        public static void ExportCSV(string filepath, string tblname)
        {
            string temp = string.Empty;

            SqlCommand cmd = new SqlCommand("SELECT * FROM " + tblname, connect);
            connect.Open();
            SqlDataReader reader = cmd.ExecuteReader();     // set up SQL connection to table

            System.IO.StreamWriter file = new System.IO.StreamWriter(filepath); // prepare file to be written to.

            while (reader.Read() == true)
            {
                temp += reader[0].ToString() + ","; // Name
                temp += reader[1].ToString() + ","; // System
                temp += reader[2].ToString() + ","; // Price
                temp += reader[3].ToString() + ","; // # In stock
                temp += reader[4].ToString() + ","; // Cash Val.
                temp += reader[5].ToString() + ","; // Trade/Credit Val.

                file.WriteLine(temp);
                temp = string.Empty;
            }

            file.Close();
            connect.Close();

        }

        //// Delete all contents from a table
        //public static void ClearTable(string tablename)
        //{

        //    SqlConnection connect = new SqlConnection(Properties.Settings.Default.StoreDatabaseConnectionString1);
        //    SqlCommand cmd = new SqlCommand("DELETE FROM " + tablename, connect);

        //    connect.Open();
        //    cmd.ExecuteNonQuery();
        //    connect.Close();
        //}

        // Check a string for characters that would throw off SQL formatting
        private static string CheckForSpecialCharacters(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '\'') // check for ' (apostrophe)
                { input = input.Insert(i, "\'"); i++; }

            }
            return input;
        }

        //// Add an item to the passed Tablename, 
        ////   but specifically designed for the Inventory & TemporaryInventory(when importing from CSV) tables
        public static void AddToTable(string tblname, string name, string system, decimal price, int inventory, decimal cash, decimal credit, string upc)
        {

            //  name = checkForSpecialCharacters(name);
            //  system = checkForSpecialCharacters(system);
            // Add data to table
            SqlCommand cmd = new SqlCommand("INSERT INTO " + tblname + " VALUES(@NAME, @SYSTEM, @PRICE, @QUANTITY, @TRADE_CASH, @TRADE_CREDIT, @UPC)", connect);
            cmd.Parameters.Add("@NAME", SqlDbType.VarChar).Value = name;
            cmd.Parameters.Add("@SYSTEM", SqlDbType.VarChar).Value = system;
            cmd.Parameters.Add("@PRICE", SqlDbType.Money).Value = price;
            cmd.Parameters.Add("@QUANTITY", SqlDbType.Int).Value = inventory;
            cmd.Parameters.Add("@TRADE_CASH", SqlDbType.Money).Value = cash;
            cmd.Parameters.Add("@TRADE_CREDIT", SqlDbType.Money).Value = credit;
            cmd.Parameters.Add("@UPC", SqlDbType.VarChar).Value = upc;

            // execute command  & close connection
            try
            {
                connect.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR IN AddToTable:\n" + e.Message);
            }
            finally
            {
                connect.Close();
            }
        }
        
        public static void AddToTable(string tblname, Item item)
        {
            // Make sure no duplicates exist
            if (IsItemInTable(tblname, item))
            {
                IncrementInventory(tblname, item);
            }

            else
            {
                // Add data to table
                SqlCommand cmd = new SqlCommand("INSERT INTO " + tblname + " VALUES(@NAME, @SYSTEM, @PRICE, @QUANTITY, @TRADE_CASH, @TRADE_CREDIT, @UPC)", connect);
                cmd.Parameters.Add("@NAME", SqlDbType.VarChar).Value = item.name;
                cmd.Parameters.Add("@SYSTEM", SqlDbType.VarChar).Value = item.system;
                cmd.Parameters.Add("@PRICE", SqlDbType.Money).Value = item.price;
                cmd.Parameters.Add("@QUANTITY", SqlDbType.Int).Value = item.quantity;
                cmd.Parameters.Add("@TRADE_CASH", SqlDbType.Money).Value = item.tradeCash;
                cmd.Parameters.Add("@TRADE_CREDIT", SqlDbType.Money).Value = item.tradeCredit;
                cmd.Parameters.Add("@UPC", SqlDbType.VarChar).Value = item.UPC;

                // execute command  & close connection

                try
                {
                    connect.Open();
                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    MessageBox.Show("ERROR IN AddToTable:\n" + e.Message);
                }
                finally
                {
                    connect.Close();
                }
            }
        }

        // For recording transactions (Transaction Total)
        public static void AddToTransactionTable(string tblname, Item item, string type, int transactionNumber, string date) // Should only be used for Table of Transactions
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO " + tblname + " VALUES(@NAME, @SYSTEM, @PRICE, @QUANTITY, @UPC, @TYPE, @TRANSACTIONNUMBER, @DATE)", connect);
            cmd.Parameters.Add("@NAME", SqlDbType.VarChar).Value = item.name;
            cmd.Parameters.Add("@SYSTEM", SqlDbType.NVarChar).Value = item.system;
            cmd.Parameters.Add("@PRICE", SqlDbType.Money).Value = item.price;
            cmd.Parameters.Add("@QUANTITY", SqlDbType.Int).Value = item.quantity;
            cmd.Parameters.Add("@UPC", SqlDbType.VarChar).Value = item.UPC;
            cmd.Parameters.Add("@TYPE", SqlDbType.NVarChar).Value = type;
            cmd.Parameters.Add("@TRANSACTIONNUMBER", SqlDbType.Int).Value = transactionNumber;
            cmd.Parameters.Add("@DATE", SqlDbType.DateTime).Value = date;

            // execute command  & close connection
            try
            {
                connect.Open();
                cmd.ExecuteNonQuery();
                connect.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR IN AddToTransactionTable:\n" + e.Message);
            }
            finally
            {
                connect.Close();
            }
        }

        // Decrease an item's inventory by subtracting the passed "Item.quantity" value
        public static void DecrementInventory(string tablename, Item item)
        {
            SqlCommand cmd = new SqlCommand("UPDATE " + tablename +
                                            " SET Quantity = Quantity - " + item.quantity +
                                            " WHERE Name = '" + CheckForSpecialCharacters(item.name) +
                                            "' AND System = '" + CheckForSpecialCharacters(item.system) + "' " +
                                            "AND PRICE = '" + item.price + "' " +
                                            "AND TRADECASH = '" + item.tradeCash + "' " +
                                            "AND TRADECREDIT = '" + item.tradeCredit + "' " +
                                            "AND UPC = '" + item.UPC + "'",
                                            connect); // Find an exact match for the passed string, increase inventory

            try
            {
                connect.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR IN DecrementInventory:\n" + e.Message);
            }
            finally
            {
                connect.Close();
            }

        }

        // Increase an item's inventory by adding the passed "Item.quantity" value
        public static void IncrementInventory(string tablename, Item item)
        {
            SqlCommand cmd = new SqlCommand("UPDATE " + tablename +
                                            " SET Quantity = Quantity + " + item.quantity +
                                            " WHERE Name = '" + CheckForSpecialCharacters(item.name) +
                                            "' AND System = '" + CheckForSpecialCharacters(item.system) + "' " + 
                                            "AND PRICE = '" + item.price + "' " +
                                            "AND TRADECASH = '" + item.tradeCash + "' " +
                                            "AND TRADECREDIT = '" + item.tradeCredit + "' " +
                                            "AND UPC = '" + item.UPC + "'",
                                            connect); // Find an exact match for the passed string, increase inventory

            try
            {
                connect.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR IN IncrementInventory:\n" + e.Message);
            }
            finally
            {
                connect.Close();
            }

        }

        // Change an existing item's information
        public static void EditInventory(string tablename, Item oldItem, Item newItem)
        {
            SqlCommand cmd = new SqlCommand("UPDATE " + tablename +
                                            " SET Name = '" + CheckForSpecialCharacters(newItem.name) + "', " +
                                            "System = '" + CheckForSpecialCharacters(newItem.system) + "', " +
                                            "Price = " + newItem.price + ", " +
                                            "Quantity = " + newItem.quantity + ", " +
                                            "TradeCash = " + newItem.tradeCash + ", " +
                                            "TradeCredit = " + newItem.tradeCredit + ", " +
                                            "UPC = '" + newItem.UPC +
                                            "' WHERE Name = '" + CheckForSpecialCharacters(oldItem.name) +
                                            "' AND System = '" + CheckForSpecialCharacters(oldItem.system) + "' " + 
                                            "AND PRICE = '" + oldItem.price + "' " +
                                            "AND TRADECASH = '" + oldItem.tradeCash + "' " +
                                            "AND TRADECREDIT = '" + oldItem.tradeCredit + "' " +
                                            "AND UPC = '" + oldItem.UPC + "'"
                                            , connect); // Find an exact match for the passed string, increase inventory

            try
            {
                connect.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR IN EditInventory:\n" + e.Message);
            }
            finally
            {
                connect.Close();
            }

        }

        // Remove an item from a SQL table based on item's Name and System
        public static void DeleteTableItem(string tablename, Item item)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM " + tablename +
                                            " WHERE Name = '" + CheckForSpecialCharacters(item.name) +
                                            "' AND System = '" + CheckForSpecialCharacters(item.system) + "' " +
                                            "AND PRICE = '" + item.price + "' " +
                                            "AND TRADECASH = '" + item.tradeCash + "' " +
                                            "AND TRADECREDIT = '" + item.tradeCredit + "' " +
                                            "AND UPC = '" + item.UPC + "'"                                            
                                            , connect); // Find an exact match for the passed string, increase inventory

            try
            {
                connect.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR IN DeleteTableItem:\n" + e.Message);
            }
            finally
            {
                connect.Close();
            }

        }
        
        /// <summary>
        /// Adds an item to the SQL table "tbl30DayHold"
        /// </summary>
        /// <param name="item">Item to add to table</param>
        /// <param name="date">Date of addition</param>
        public static void AddTo30DayHold(Item item, string date)
        {
            // Make sure Item is not null
            if (item == null) return;

            SqlCommand cmd = new SqlCommand("INSERT INTO " + TableNames._30DAYHOLD + " VALUES(@NAME, @SYSTEM, @PRICE, @QUANTITY, @TRADE_CASH, @TRADE_CREDIT, @UPC, @DATE)", connect);
            cmd.Parameters.Add("@NAME", SqlDbType.VarChar).Value = item.name;
            cmd.Parameters.Add("@SYSTEM", SqlDbType.NVarChar).Value = item.system;
            cmd.Parameters.Add("@PRICE", SqlDbType.Money).Value = item.price;
            cmd.Parameters.Add("@QUANTITY", SqlDbType.Int).Value = item.quantity;
            cmd.Parameters.Add("@TRADE_CASH", SqlDbType.Money).Value = item.tradeCash;
            cmd.Parameters.Add("@TRADE_CREDIT", SqlDbType.Money).Value = item.tradeCredit;
            cmd.Parameters.Add("@UPC", SqlDbType.VarChar).Value = item.UPC;
            cmd.Parameters.Add("@DATE", SqlDbType.DateTime).Value = date;

            try
            {
                connect.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR IN AddTo30DayHold:\n" + e.Message);
            }
            finally
            {
                connect.Close();
            }
        }

        public static void DeleteItemFrom30DayHold(HoldItem item)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM tbl30DayHold WHERE Name = '" + CheckForSpecialCharacters(item.name) +
                                            "' AND System = '" + CheckForSpecialCharacters(item.system) + "' AND Date = '" + item.dateIn + "'",
                                            connect); // Find an exact match for the passed string, delete item.
            try
            {
                connect.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR IN DeleteItemFrom30DayHold:\n" + e.Message);
            }
            finally
            {
                connect.Close();
            }
        }

        public static void Edit30DayHold(HoldItem oldItem, HoldItem newItem)
        {
            SqlCommand cmd = new SqlCommand("UPDATE " + TableNames._30DAYHOLD +
                                            " SET Name = '" + CheckForSpecialCharacters(newItem.name) + "', " +
                                            "System = '" + CheckForSpecialCharacters(newItem.system) + "', " +
                                            "Price = " + newItem.price + ", " +
                                            "Quantity = " + newItem.quantity + ", " +
                                            "TradeCash = " + newItem.tradeCash + ", " +
                                            "TradeCredit = " + newItem.tradeCredit + ", " +
                                            "UPC = " + newItem.UPC + ", " +
                                            "DATE = '" + newItem.dateIn + "'" +
                                            " WHERE Name = '" + CheckForSpecialCharacters(oldItem.name) +
                                            "' AND System = '" + CheckForSpecialCharacters(oldItem.system) + "' " +
                                            "AND PRICE = '" + oldItem.price + "' " +
                                            "AND TRADECASH = '" + oldItem.tradeCash + "' " +
                                            "AND TRADECREDIT = '" + oldItem.tradeCredit + "' " +
                                            "AND UPC = '" + oldItem.UPC + "' " +
                                            "AND DATE = '" + oldItem.dateIn + "'"
                                            , connect); // Find an exact match for the passed string, increase inventory

            try
            {
                connect.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR IN Edit30DayHold:\n" + e.Message);
            }
            finally
            {
                connect.Close();
            }

        }

        public static void RemoveOldestItemFrom30DayHold(Item item)
        {
            int quantity = item.quantity;

            // Get a collection of the same items from the 30 Day Hold, sorted by Date
            Collection items = _30DayHoldToCollection("Date", true, item.UPC);

            // Deduct passed "item"'s quantity from as many Items as necessary in the 30 Day Hold Collection, until the passed Item's quantity has been fully deducted from the Hold
            foreach (HoldItem i in items)
            {
                // Quantity remaining is larger than current item's quantity, delete item from Hold, and deduct its quantity from the amount remaining
                if (i.quantity <= quantity)
                {
                    DeleteItemFrom30DayHold(i);
                    quantity -= i.quantity;
                }

                // Quantity remaining is less than the current item's quantity, adjust item's quantity & update 30DayHold
                else
                {
                    HoldItem newItem = i.Clone();
                    newItem.quantity -= quantity;
                    Edit30DayHold(i, newItem);
                    return;
                }
            }
        }

        /// <summary>
        /// Gets an INVENTORY table and returns a Collection of all contained Items
        /// </summary>
        /// <param name="tablename">Table name of an INVENTORY type table</param>
        /// <param name="sortBy">Column to sort by.   (Optional)</param>
        /// <param name="ascending">True: Results are sorted (A->Z), False: (Z->A).  (Optional)</param>
        /// <param name="searchtext">Text to narrow results to items containing this text.  (Optional)</param>
        /// <returns>A Collection of Items</returns>
        public static Collection SQLTableToCollection(string tablename, string sortBy = "System", bool ascending = true, string searchtext = "")
        {
            Collection collection = new Collection();
            Item item;
            SearchTerms searchTerms;

            // Save sorting order to string "order" (descending/ascending)
            string order;
            SqlCommand cmd;
            if (ascending)
                order = "ASC";
            else
                order = "DESC";

            // parameters cannot be null
            if (searchtext == null) searchtext = "";
            if (sortBy == null) sortBy = "System";

            // Check for special characters, then divide searchtext into individual terms
            searchtext = CheckForSpecialCharacters(searchtext);
            searchTerms = new SearchTerms(searchtext);

            if (sortBy != "Name")
            {
                cmd = new SqlCommand("SELECT * FROM " + tablename +
                   " WHERE " + searchTerms.GenerateSQLSearchString() +
                   "ORDER BY " + sortBy + " " + order + ", Name;", connect);
            }
            else
            {
                cmd = new SqlCommand("SELECT * FROM " + tablename +
                   " WHERE " + searchTerms.GenerateSQLSearchString() +
                   "ORDER BY " + sortBy + " " + order + ";", connect);
            }

            try
            {
                connect.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read() == true)
                {
                    item = SQLReaderToItem(reader);
                    if (item != null)
                        collection.AddItem(item);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR IN SQLTableToCollection:\n" + e.Message);
            }
            finally
            {
                connect.Close();
            }

            return collection;
        }

        ///// <summary>
        ///// A one-time-use function for converting the UPC column to a nvarchar(MAX) without turning all the values to scientific notation (which it does by default)
        ///// Also adds leading zeroes to UPCs with less than 12, but more than 7 digits
        ///// </summary>
        //public static void ConvertUPCcolumnToString()
        //{
        //    // Strategy:
        //    // *1. Get entire Inventory table as a collection
        //    // *1. a) If UPC length is > 8, < 12, add leading zeroes to UPC
        //    // *2. Delete contents of Inventory table
        //    // *3. Drop UPC column
        //    // *4. Add new UPC column for strings
        //    // *5. Add all new items


        //    // 1
        //    Collection collection = DBaccess.SQLTableToCollection(TableNames.INVENTORY);

        //    // 1a
        //    foreach (Item item in collection)
        //    {                
        //        string zeroes = "";
        //        int len = item.UPC.Length;

        //        if (len < 12 && len >=8)
        //        {
        //            for (int i = 0; i<(12-len); i++)
        //            {
        //                zeroes += '0';
        //            }
        //            item.UPC = zeroes + item.UPC;
        //        }
        //    }

        //    // 2
        //    SqlCommand cmd = new SqlCommand("DELETE FROM " + TableNames.INVENTORY, connect);
        //    try
        //    {
        //        connect.Open();
        //        cmd.ExecuteNonQuery();
        //    }
        //    finally
        //    {
        //        connect.Close();
        //    }

        //    // 3
        //    cmd = new SqlCommand("ALTER TABLE " + TableNames.INVENTORY + " DROP COLUMN UPC", connect);

        //    try
        //    {
        //        connect.Open();
        //        cmd.ExecuteNonQuery();
        //    }
        //    finally
        //    {
        //        connect.Close();
        //    }

        //    // 4
        //    cmd = new SqlCommand("ALTER TABLE " + TableNames.INVENTORY + " ADD UPC nvarchar(MAX) NULL", connect);
        //    try
        //    {
        //        connect.Open();
        //        cmd.ExecuteNonQuery();
        //    }
        //    finally
        //    {
        //        connect.Close();
        //    }

        //    collection.AddToTable(TableNames.INVENTORY);
            
        //}

        /// <summary>
        /// Adds leading zeroes to UPCs > 7 characters in length, and adds leading zeroes to make a 12 digit number 
        /// </summary>
        public static void AddLeadingZeroes()
        {
            // Strategy:
            // *1. Get entire Inventory table as a collection
            // *2. If UPC length is > 8, < 12, add leading zeroes to UPC
            // *3. Edit


            // 1.
            Collection collection = DBaccess.SQLTableToCollection(TableNames.INVENTORY);

            // 2.
            foreach (Item item in collection)
            {
                Item newItem = null;
                string zeroes = "";
                int len = item.UPC.Length;

                if (len < 12 && len >= 8)
                {
                    newItem = item.Clone();
                    for (int i = 0; i < (12 - len); i++)
                    {
                        zeroes += '0';
                    }
                    newItem.UPC = zeroes + newItem.UPC;

             // 3.
                    DBaccess.EditInventory(TableNames.INVENTORY, item, newItem);
                }
            }
        }

        /// <summary>
        /// Gets the 30-Day-Hold table and returns a Collection of all contained Items
        /// </summary>
        /// <param name="sortBy">Column to sort by.   (Optional)</param>
        /// <param name="ascending">True: Results are sorted (A->Z), False: (Z->A).  (Optional)</param>
        /// <param name="searchtext">Text to narrow results to items containing this text.  (Optional)</param>
        /// <returns>A Collection of Items</returns>
        public static Collection _30DayHoldToCollection(string sortBy = "System", bool ascending = true, string searchtext = "")
        {
            Collection collection = new Collection();
            HoldItem item;
            SqlCommand cmd;

            string tablename = TableNames._30DAYHOLD;
            string order;            

            // Save sorting order to string "order" (descending/ascending)
            if (ascending)
                order = "ASC";
            else
                order = "DESC";

            searchtext = CheckForSpecialCharacters(searchtext);

            if (sortBy != "Name")
            {
                cmd = new SqlCommand("SELECT * FROM " + tablename +
                   " WHERE name LIKE \'%" + searchtext + "%\' OR system LIKE \'%" + searchtext + "%\' OR UPC = '" + searchtext + "'" +
                   " ORDER BY " + sortBy + " " + order + ", NAME;", connect);
            }
            else
            {
                cmd = new SqlCommand("SELECT * FROM " + tablename +
                   " WHERE name LIKE \'%" + searchtext + "%\' OR system LIKE \'%" + searchtext + "%\' " +
                   "ORDER BY " + sortBy + " " + order + ";", connect);
            }

            try
            {
                connect.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read() == true)
                {
                    item = SQLReaderToHoldItem(reader);
                    if (item != null)
                        collection.AddItem(item);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR IN _30DayHoldToCollection:\n" + e.Message);
            }
            finally
            {
                connect.Close();
            }

            return collection;
        }
        
        public static Collection TransactionTableToCollection(string sortBy = "TransactionNumber", bool ascending = true)
        {
            TransactionItem item;
            Collection collection = new Collection();

            // Save sorting order to string "order" (ascending/descending)
            string order;
            if (ascending) order = "ASC";
            else order = "DESC";

            SqlCommand cmd = new SqlCommand("SELECT * FROM " + TableNames.TRANSACTION + " ORDER BY " + sortBy + " " + order, connect);

            try
            {
                connect.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read() == true)
                {
                    item = SQLReaderToTransactionItem(reader);
                    if (item != null)
                        collection.AddItem(item);
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return collection;
        }

        /// <summary>
        /// Checks if an Item is already present in an inventory table
        /// </summary>
        /// <param name="tablename">Name of an Inventory table</param>
        /// <param name="item">Item to check</param>
        /// <returns>True if the item is present, false otherwise</returns>
        public static bool IsItemInTable(string tablename, Item item)
        {
            object result = null;
            string command = "SELECT * FROM " + tablename +
                " WHERE NAME = '" + CheckForSpecialCharacters(item.name) + "' " +
                "AND SYSTEM = '" + CheckForSpecialCharacters(item.system) + "' " +
                "AND PRICE = '" + item.price + "' " +
                "AND TRADECASH = '" + item.tradeCash + "' " +
                "AND TRADECREDIT = '" + item.tradeCredit + "' " +
                "AND UPC = '" + item.UPC + "'";
            SqlCommand cmd = new SqlCommand(command, connect);

            // Execute command
            try
            {
                connect.Open();
                result = cmd.ExecuteScalar();
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR IN IsItemInTable:\n" + e.Message);
            }
            finally
            {
                connect.Close();
            }

            // If the result is still null, then the item does not exist in the table
            if (result == null)
                return false;
            else
                return true;
        }

        /// <summary>
        /// Creates an item based on data contained in an SqlDataReader
        /// </summary>
        /// <param name="reader">SqlDataReader containing data</param>
        /// <returns>A new Item</returns>
        public static Item SQLReaderToItem(SqlDataReader reader)
        {
            Item item = new Item(reader[SQLtableColumnIndex_Inventory.NAME].ToString(),
                    reader[SQLtableColumnIndex_Inventory.SYSTEM].ToString(),
                    reader[SQLtableColumnIndex_Inventory.PRICE].ToString(),
                    reader[SQLtableColumnIndex_Inventory.QUANTITY].ToString(),
                    reader[SQLtableColumnIndex_Inventory.TRADE_CASH].ToString(),
                    reader[SQLtableColumnIndex_Inventory.TRADE_CREDIT].ToString(),
                    reader[SQLtableColumnIndex_Inventory.UPC].ToString());

            return item;
        }

        /// <summary>
        /// Creates a HoldItem based on data contained in an SqlDataReader
        /// </summary>
        /// <param name="reader">SqlDataReader containing data</param>
        /// <returns>A populated HoldItem</returns>
        public static HoldItem SQLReaderToHoldItem(SqlDataReader reader)
        {
            HoldItem item = null;
            item = new HoldItem(reader[0].ToString(),
                    reader[1].ToString(),
                    reader[2].ToString(),
                    reader[3].ToString(),
                    reader[4].ToString(),
                    reader[5].ToString(),
                    reader[6].ToString(),
                    reader[7].ToString());
            return item;
        }

        /// <summary>
        /// Creates a TransactionItem based on data contained in an SqlDataReader
        /// </summary>
        /// <param name="reader">SqlDataReader containing data</param>
        /// <returns>A populated TransactionItem</returns>
        public static TransactionItem SQLReaderToTransactionItem(SqlDataReader reader)
        {
            TransactionItem item = null;
            item = new TransactionItem(reader[0].ToString(),
                    reader[1].ToString(),
                    reader[2].ToString(),
                    reader[3].ToString(),
                    reader[4].ToString(),
                    reader[5].ToString(),
                    reader[6].ToString(),
                    reader[7].ToString());
            return item;
        }

        #region UPC and Transaction Numbers
        
        /// <summary>
        /// Retrieves items from database with matching UPC
        /// </summary>
        /// <param name="tablename">String with the name of the Table to retrieve Item from</param>
        /// <param name="UPC">String containing UPC</param>
        /// <returns>Item containing matching UPC</returns>
        public static Item GetItemWithUPC(string tablename, string UPC)
        {
            Item item = null;

            SqlCommand cmd = new SqlCommand("SELECT * FROM " + tablename + " WHERE (UPC LIKE \'" + UPC + "\')", connect);

            try
            {
                connect.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                    item = SQLReaderToItem(reader);
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR IN GetItemWithUPC:\n" + e.Message);
            }
            finally
            {
                connect.Close();
            }

            return item;
        }        

        /// <summary>
        /// Gets the next unused UPC value
        /// </summary>
        /// <returns>A double contining the next unused UPC</returns>
        public static double GetNextUnusedUPC()
        {
            SqlCommand cmd;
            double value = 0;

            cmd = new SqlCommand("SELECT UPC FROM " + TableNames.VARIABLES, connect);

            try
            {
                connect.Open();
                value = (double)cmd.ExecuteScalar();
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR IN GetNextUnusedUPC:\n" + e.Message);
            }
            finally
            {
                connect.Close();
            }

            return value;
        }

        /// <summary>
        /// Increments the value of the next available, unused UPC
        /// </summary>
        public static void IncrementUPC()
        {
            SqlCommand cmd;
            double value = Convert.ToDouble(GetNextUnusedUPC());

            value += 1;

            // Make sure new UPC value is not in use. 
            // If it is in use, keep incrementing until it is not
            while (IsUPCInUse(value.ToString()))
                value += 1;

            cmd = new SqlCommand("UPDATE " + TableNames.VARIABLES + " SET UPC = " + value.ToString(), connect);

            try
            {
                connect.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR IN IncrementUPC:\n" + e.Message);
            }
            finally
            {
                connect.Close();
            }
        }

        /// <summary>
        /// Determines whether or not the provided UPC code is currently assigned to an item
        /// </summary>
        /// <param name="upc">UPC code (as string) to check</param>
        /// <returns>True if UPC is in use, False if not</returns>
        public static bool IsUPCInUse(string upc)
        {
            SqlCommand cmd;
            int value = 1;

            cmd = new SqlCommand("IF EXISTS (SELECT * FROM " + TableNames.INVENTORY + " WHERE UPC LIKE \'" + upc + "\')SELECT 1 ELSE SELECT 0", connect);

            try
            {
                connect.Open();
                value = (int)cmd.ExecuteScalar();
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR IN IsUPCInUse:\n" + e.Message);
            }
            finally
            {
                connect.Close();
            }

            if (value == 1) return true;
            else return false;
        }

        /// <summary>
        /// Retrieves the next unused Transaction number from the Variable database
        /// </summary>
        /// <returns>Transaction number as int</returns>
        public static int GetNextUnusedTransactionNumber()
        {
            SqlCommand cmd;
            int value;

            cmd = new SqlCommand("SELECT TransactionNumber FROM " + TableNames.VARIABLES, connect);

            connect.Open();
            value = (int)cmd.ExecuteScalar();
            connect.Close();

            return value;
        }

        /// <summary>
        /// Increments the value of the next available, unused Transaction number
        /// </summary>
        public static void IncrementTransactionNumber()
        {
            SqlCommand cmd;

            cmd = new SqlCommand("UPDATE " + TableNames.VARIABLES + " SET TransactionNumber = TransactionNumber + 1", connect);

            connect.Open();
            cmd.ExecuteNonQuery();
            connect.Close();
        }

        #endregion

        /// <summary>
        /// Returns the monetary value of the entire inventory (each item's price * quantity)
        /// </summary>
        /// <returns>Monetary value of all in-stock items in inventory as a Decimal</returns>
        public static decimal GetInventoryValue()
        {
            decimal total;

            string command = "SELECT A + B + C " +
                            "FROM " +
                            "(SELECT SUM(Price * Quantity) AS A FROM " + TableNames.INVENTORY + ") AS X " +
                            "CROSS JOIN " +
                            "(SELECT SUM(Price * Quantity) AS B FROM " + TableNames.OUTBACK + ") AS Y " +
                            "CROSS JOIN " +
                            "(SELECT SUM(Price * Quantity) AS C FROM "+ TableNames._30DAYHOLD +") AS Z";

            try
            {
                SqlCommand cmd = new SqlCommand(command, connect);
                connect.Open();
                total = Convert.ToDecimal(cmd.ExecuteScalar());
                connect.Close();
                return total; //return the total
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connect.Close();
            }

            return -1M; // Something went wrong. (Although, -1 could be a legitimate return value if there are an abundance of negative quantity of items in inventory.)
        }

        public static Collection GetBestSellingItems(string type, bool ascending = false)
        {
            Collection collection = new Collection();
            string order;
            if (ascending) order = "ASC";
            else order = "DESC";

            string command = "SELECT Name, System, SUM(Quantity) AS Total " +
                        "FROM " + TableNames.TRANSACTION +
                        " WHERE        (Type = '" + type + "') " +
                        "GROUP BY Name, System " +
                        "ORDER BY Total " + order;

            SqlCommand cmd = new SqlCommand(command, connect);

            try
            {
                connect.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read() == true)
                {
                    Item item = new Item(reader[0].ToString(), reader[1].ToString(), reader[2].ToString());
                    collection.AddItem(item);
                }
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                connect.Close();
            }

            return collection;
        }

        /// <summary>
        /// Gets the monetary total of the given transaction type starting from (and including) the DateTime "from" up to the DateTime "to"
        /// </summary>
        /// <param name="type">Transaction Type</param>
        /// <param name="from">Starting date. Search includes this date in the results.</param>
        /// <param name="to">Endind date. Search includes everything UP TO, but NOT INCLUDING this date.</param>
        /// <returns>The monetary total as a decimal.</returns>
        public static decimal GetTransactionMonetaryTotal(string type, DateTime from, DateTime to)
        {
            object result = null;
            string command = "SELECT SUM(Price * Quantity) FROM " + TableNames.TRANSACTION + " WHERE Type = '" + type + "' AND Date >= '" + from + "' AND Date < '" + to + "'";
            SqlCommand cmd = new SqlCommand(command, connect);
                
            try
            {
                connect.Open();
                result = cmd.ExecuteScalar();
                connect.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                connect.Close();
            }

            try
            {
                return (Convert.ToDecimal(result));
            }
            catch
            {
                return 0M;
            }
        }


        /// <summary>
        /// Returns the total quantity of items currently in stock
        /// </summary>
        /// <returns>An int representing the total quantity of items currently in stock</returns>
        public static int GetItemTotal()
        {
            object result = null;
            string command = "SELECT SUM(Quantity) FROM " + TableNames.INVENTORY;
            SqlCommand cmd = new SqlCommand(command, connect);

            try
            {
                connect.Open();
                result = cmd.ExecuteScalar();
                connect.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                connect.Close();
            }

            try
            {
                return Convert.ToInt32(result);
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Adds Item's UPC to the AutoPrint table.
        /// </summary>
        /// <param name="item">Item whose label should be printed automatically at Trade-In checkout</param>
        public static void AddToAutoPrintTable(Item item)
        {
            // Make sure item is not already in the table, to avoid duplicates
            if (IsItemInAutoPrintTable(item))
                return;

            // Item is not in table, so add it.
            string command = "INSERT INTO " + TableNames.AUTOPRINT + " VALUES(@UPC)";
            SqlCommand cmd = new SqlCommand(command, connect);
            cmd.Parameters.Add("@UPC", SqlDbType.Float).Value = item.UPC;

            // Execute command
            connect.Open();
            cmd.ExecuteNonQuery();
            connect.Close();
        }

        /// <summary>
        /// Removes an item from the auto-print list
        /// </summary>
        /// <param name="item">Item to be taken off of the AutoPrintLabel list</param>
        public static void RemoveFromAutoPrintTable(Item item)
        {
            if (IsItemInAutoPrintTable(item))
            {
                string command = "DELETE FROM " + TableNames.AUTOPRINT + " WHERE UPC = " + item.UPC.ToString();
                SqlCommand cmd = new SqlCommand(command, connect);

                // Execute command
                connect.Open();
                cmd.ExecuteNonQuery();
                connect.Close();
            }
        }

        /// <summary>
        /// Checks if an item's UPC is in the Autoprint table
        /// </summary>
        /// <param name="item"></param>
        /// <returns>True if item is in table, false otherwise</returns>
        public static bool IsItemInAutoPrintTable(Item item)
        {
            object result = null;
            string command = "SELECT * FROM " + TableNames.AUTOPRINT +
                " WHERE  UPC = '" + item.UPC + "'";
            SqlCommand cmd = new SqlCommand(command, connect);

            // Execute command
            connect.Open();
            result = cmd.ExecuteScalar();
            connect.Close();

            // If the result is still null, then the item does not exist in the table
            if (result == null)
                return false;
            else
                return true;
        }

        /// <summary>
        /// Determines whether or not the passed item is currently in stock, based on UPC and item Name
        /// </summary>
        /// <param name="item">Item to check</param>
        /// <returns>True if item is currently in stock, false otherwise</returns>
        public static bool IsItemInStock(Item item)
        {
            object result = null; // Result of SQL query
            string command;

            // If UPC isn't 0, find a match based on UPC. Otherwise find match based on Name and System.
            if (item.UPC != "0")
            {
                command = "SELECT QUANTITY FROM " + TableNames.INVENTORY + " WHERE UPC = '" + item.UPC + "'";
            }
            else
            {
                command = "SELECT QUANTITY FROM " + TableNames.INVENTORY + " WHERE NAME = '" + item.name + "' AND SYSTEM = '" + item.system + "'";
            }
            SqlCommand cmd = new SqlCommand(command, connect);

            try
            {
                connect.Open();
                result = cmd.ExecuteScalar();
                connect.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in IsItemInStock():\n\n" + ex.Message);
                connect.Close();
            }

            // If item is in stock, return true. Else, return false
            if ((int)result > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Verifies that required tables exist. If not, missing tables are created.
        /// </summary>
        public static void CheckTableExistance()
        {
            // Inventory
            if (!DoesTableExist(TableNames.INVENTORY)) 
            {
                CreateInventoryTable();
            }
            // Customers
            if (!DoesTableExist(TableNames.CUSTOMERS))
            {
                CreateCustomersTable();
            }
            // Wait List
            if (!DoesTableExist(TableNames.WAIT_LIST))
            {
                CreateWaitingListTable();
            }

            // Transactions

            // Variables
            
            // Auto-Print

        }

        /// <summary>
        /// Determines whether a given SQL table exists in the current database
        /// </summary>
        /// <param name="tablename">Name of the SQL table to check</param>
        /// <returns>True if the table exists, false otherwise</returns>
        public static bool DoesTableExist(string tablename)
        {
            bool exists = false;
            string command = "SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_NAME = '" + tablename + "';";

            SqlCommand cmd = new SqlCommand(command, connect);

            try
            {
                connect.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    exists = true;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error in DoesTableExist:\n\n" + ex.Message, "SQL Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                connect.Close();
            }

            return exists;
        }

        public static void CreateCustomersTable()
        {
             //If Customers Table doesn't exist,
             //Create table
            string command = "CREATE TABLE tblCustomers([Customer_ID] INT NOT NULL PRIMARY KEY IDENTITY, [Name] NVARCHAR(50) NOT NULL, [Phone] NVARCHAR(50) NULL, [Email] NVARCHAR(MAX) NULL)";
            
            SqlCommand cmd = new SqlCommand(command);
            CreateSQLTable(cmd);
        }

        public static void CreateWaitingListTable()
        {
                string command = "CREATE TABLE [dbo].[tblWaitList] ([Wait_ID]     INT  IDENTITY (1, 1) NOT NULL,[Customer_ID] INT  NOT NULL,[Date]        DATE NOT NULL,[Item_ID]        INT  NOT NULL,PRIMARY KEY CLUSTERED ([Wait_ID] ASC),FOREIGN KEY ([Customer_ID]) REFERENCES [dbo].[tblCustomers] ([Customer_ID]),FOREIGN KEY ([Item_ID]) REFERENCES [dbo].[tblInventory] ([ID]))";
            
            SqlCommand cmd = new SqlCommand(command);
            CreateSQLTable(cmd);
        }

        public static void CreateInventoryTable()
        {
                string command = "CREATE TABLE [dbo].[tblInventory]([ID]		  INT			 NOT NULL PRIMARY KEY IDENTITY,[Name]        VARCHAR (MAX)  NULL,[System]      NVARCHAR (50)  NULL,[Price]       MONEY          NULL,[Quantity]    INT            NULL,[TradeCash]   MONEY          NULL,[TradeCredit] MONEY          NULL,[UPC]         NVARCHAR (MAX) NULL)";
            
            SqlCommand cmd = new SqlCommand(command);
            CreateSQLTable(cmd);
        }

        private static void CreateSQLTable(SqlCommand cmd)
        {
            // execute command  & close connection
            try
            {
                connect.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR IN CreateSQLTable():\n" + e.Message);
            }
            finally
            {
                connect.Close();
            }
        }

        public static void CreateUPCTable()
        {
            //    CREATE TABLE [dbo].[tblUPC] 
            //(
            //    [ID]		  INT			 NOT NULL PRIMARY KEY IDENTITY,
            //    [UPC]        VARCHAR (MAX)  NULL
            //);
        }

#region WaitList Functions

        /// <summary>
        /// Given a customer, returns a collection of items in the customer's Wish List
        /// </summary>
        /// <param name="customer">Customer whose whish list is to be returned</param>
        /// <returns>A Collection of items in the Customer's WaitList.</returns>
        public static Collection GetCustomerWaitList(Customer customer)
        {
            Item item;
            Collection collection = new Collection();

            //  SELECT tblInventory.* 
            //      FROM tblWaitList JOIN tblInventory
            //      ON tblWaitList.item_id = tblInventory.ID
            //      WHERE tblWaitList.customer_id = [CUSTOMER ID];
            string command = "SELECT " + TableNames.INVENTORY +
                                ".* FROM " + TableNames.WAIT_LIST +
                                " JOIN " + TableNames.INVENTORY +
                                " ON " + TableNames.WAIT_LIST + "." + SQLTableColumnNames.WAIT_LIST_ITEM_ID + " = " + TableNames.INVENTORY + "." + SQLTableColumnNames.ITEM_ID +
                                " WHERE " + TableNames.WAIT_LIST + "." + SQLTableColumnNames.CUSTOMER_ID + " = " + customer.id + ";";
            SqlCommand cmd = new SqlCommand(command, connect);

            try
            {
                connect.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read() == true)
                {
                    item = SQLReaderToItem(reader);
                    if (item != null)
                        collection.AddItem(item);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("ERROR IN GetCustomerWaitList:\n" + e.Message);
            }
            finally
            {
                connect.Close();
            }

            return collection; 
        }

        public static void AddToWaitList(Customer customer, Item item)
        {
            DateTime date = DateTime.Today;
            string command = "INSERT INTO " + TableNames.WAIT_LIST + " VALUES(@CUSTOMER_ID, @DATE, @ITEM_ID)";

            SqlCommand cmd = new SqlCommand(command, connect);
            cmd.Parameters.Add("@CUSTOMER_ID", SqlDbType.Int).Value = customer.id;
            cmd.Parameters.Add("@DATE", SqlDbType.Date).Value = date;
            cmd.Parameters.Add("@ITEM_ID", SqlDbType.Int).Value = item.ID;

            try
            {
                connect.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in AddToWaitList():\n" + ex.Message, "Ruh Roh!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connect.Close();
            }
        }


#endregion

#region Customer List Functions

        /// <summary>
        /// Adds the passed new customer to the Customer table, returns table ID of customer
        /// </summary>
        /// <param name="customer">The new customer to add to table</param>
        /// <returns>Table ID of customer, or 0 if an error occured</returns>
        public static int AddToCustomerList(Customer customer)
        {
            int result = 0;
            string command = "INSERT INTO " + TableNames.CUSTOMERS + " OUTPUT INSERTED.customer_id VALUES(@NAME, @PHONE, @EMAIL) ";

            SqlCommand cmd = new SqlCommand(command, connect);
            cmd.Parameters.Add("@NAME", SqlDbType.VarChar).Value = customer.name; 
            cmd.Parameters.Add("@PHONE", SqlDbType.NVarChar).Value = customer.phoneNumber;
            cmd.Parameters.Add("@EMAIL", SqlDbType.NVarChar).Value = customer.email;

            try
            {
                connect.Open();
                result = (int) cmd.ExecuteScalar();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in AddToCustomerList():\n" + ex.Message, "Ruh Roh!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connect.Close();
            }

            return result;
        }

        public static Customer GetCustomer(int customerID)
        {
            Customer customer = null;

            string command = "SELECT * FROM " + TableNames.CUSTOMERS + " WHERE " + SQLTableColumnNames.CUSTOMER_ID + " = " + customerID;

            SqlCommand cmd = new SqlCommand(command, connect);

            try
            {
                connect.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read() == true)
                {
                    customer = CreateCustomerFromSQLReader(reader);
                } 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in GetCustomer():\n" + ex.Message, "Ruh Roh!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                connect.Close();
            }

            return customer;
        }

        public static Customer CreateCustomerFromSQLReader(SqlDataReader reader)
        {
            Customer customer = new Customer(reader[SQLtableColumnIndex_Customers.NAME].ToString(),
                                                reader[SQLtableColumnIndex_Customers.EMAIL].ToString(),
                                                reader[SQLtableColumnIndex_Customers.PHONE].ToString(),
                                                (int)reader[SQLtableColumnIndex_Customers.ID]);
            
            return customer;
        }

        public static void UpdateCustomer(Customer customer)
        {

        }
#endregion

        
    //    SELECT tblInventory.* 
    //FROM tblWaitList JOIN tblInventory
    //ON tblWaitList.item_id = tblInventory.ID
    //WHERE tblWaitList.customer_id = 1;
    }
}
