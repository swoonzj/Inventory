using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Inventory
{
    public static class Constants
    {
        public const string DISCOUNTUPC = "-1";
    }    

    public static class PrinterVariables
    {
        public class UPCimage
        {
            public const int locX = 0;
            public const int locY = 0;
        }
        public class ItemInfo
        {
            public const int locX = 0;
            public const int nameLocY = 60;
            public const int systemLocY = 85;
        }
    }

    public static class TableNames
    {
        public const string INVENTORY = "tblInventory";
        public const string TRANSACTION = "tblTransactions";
        public const string VARIABLES = "tblVariables";
        public const string _30DAYHOLD = "tbl30DayHold";
        public const string OUTBACK = "tblOutBack";
        public const string AUTOPRINT = "tblAutoPrint";
        public const string CUSTOMERS = "tblCustomers";
        public const string WAIT_LIST = "tblWaitList";
    }

    public static class TransactionTypes
    {
        public const string SALE = "Sale";
        public const string TRADE_CASH = "Trade-Cash";
        public const string TRADE_CREDIT = "Trade-Credit";
    }

    public enum POSTableIndex
    {
            NAME = 0,
            SYSTEM = 1,
            PRICE = 2,
            INSTOCK = 3,
            CASHVALUE = 4,
            TRADEVALUE = 5,
            UPC = 6
    };

    public static class SQLtableColumnIndex_Inventory
    {
        public const int ID = 0,
        NAME = 1,
        SYSTEM = 2,
        PRICE = 3,
        QUANTITY = 4,
        TRADE_CASH = 5,
        TRADE_CREDIT = 6,
        UPC = 7;
    }

    public static class SQLtableColumnIndex_Customers
    {
        public const int ID = 0,
        NAME = 1,
        PHONE = 2,
        EMAIL = 3;
    }

    public static class SQLtableColumnIndex_WaitList
    {
        public const int ID = 0,
        CUSTOMER_ID = 1,
        DATE = 2,
        ITEM_ID = 3;
    }
    //public static class POSTableIndex
    //{
    //    public const int NAME = 0,
    //        SYSTEM = 1,
    //        PRICE = 2,
    //        INSTOCK = 3,
    //        CASHVALUE = 4,
    //        TRADEVALUE = 5,
    //        UPC = 6;
    //}

    public enum ListViewType
    {
        POS = 0,
        CART = 1,
        TRADECART = 2,
        MANAGEMENT = 3,
        _30DAYHOLD = 4,
        TRANSACTION = 5,
        WAITLIST = 6,
        CUSTOMERLIST = 7
    };

    //public static class ListViewType
    //{
    //    public const int POS = 0,
    //        CART = 1,
    //        TRADECART = 2,
    //        MANAGEMENT = 3,
    //        _30DAYHOLD = 4,
    //        TRANSACTION = 5;
    //}

    public static class ListViewColumnNames
    {
        public const string NAME = "Name",
            SYSTEM = "System",
            PRICE = "Price",
            QUANTITY = "# In Stock",
            TRADE_CASH = "Trade: Cash",
            TRADE_CREDIT = "Trade: Store Credit",
            UPC = "UPC",
            ITEM_TOTAL = "Item Total",
            DATE = "Date",
            CUSTOMER_NAME = "Customer Name",
            PHONE_NUMBER = "Phone Number",
            EMAIL = "Email";
    }

    public static class SQLTableColumnNames
    {
        public const string
            // Inventory Table
            ITEM_ID = "ID",
            NAME = "Name",
            SYSTEM = "System",
            PRICE = "Price",
            QUANTITY = "Quantity",
            TRADE_CASH = "TradeCash",
            TRADE_CREDIT = "TradeCredit",
            UPC = "UPC",
            DATE = "Date",
            // Customer Table
            CUSTOMER_ID = "customer_id",
            CUSTOMER_NAME = "Name",
            PHONE_NUMBER = "Phone",
            EMAIL = "Email",
            // Wait List Table
            WAIT_LIST_ID = "wait_id",
            WAIT_LIST_ITEM = "item",
            WAIT_LIST_DATE = "date",
            WAIT_LIST_ITEM_ID = "item_id";        
    }


}
