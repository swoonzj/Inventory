using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Net;

namespace Inventory
{   
    public class UPC
    {
        public Image upcImage;
        public string name = "", system = "";
        public string upc;

        public UPC(string upc)
        {
            this.upc = upc;
            GetUPCImage();
        }

        public UPC(Item item)
        {
            this.upc = item.UPC;
            this.name = item.name;
            this.system = item.system;
            GetUPCImage();
        }

        private string CreateURL()
        {
            return "http://www.barcodesinc.com/generator/image.php?code=" + upc + "&style=197&type=C128B&width=200&height=50&xres=1&font=3";
        }

        private void GetUPCImage()
        {
            HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.Create(CreateURL());
            using (HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse())
            {
                using (Stream stream = webResponse.GetResponseStream())
                {
                    upcImage = Image.FromStream(stream);
                }
            }
        }
    }

    public static class Printer
    {
        private static Image upcImage;
        private static UPC upc;

        /// <summary>
        /// Prints a single UPC label for the item provided
        /// </summary>
        /// <param name="item"></param>
        public static void PrintUPCLabel(Item item)
        {
            upc = new UPC(item);
            upcImage = upc.upcImage;
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += PrintPage;
            pd.Print();
        }

        /// <summary>
        /// Prints many UPC labels for the item provided, as indicated by the item's Quantity
        /// </summary>
        /// <param name="item"></param>
        public static void PrintQuantityOfUPCLabels(Item item)
        {
            for (int i = 0; i < item.quantity; i++)
            {
                PrintUPCLabel(item);
            }
        }

        private static void PrintPage(object o, PrintPageEventArgs e)
        {
            Point loc = new Point(0, 0);
            e.Graphics.DrawImage(upcImage, loc);

            e.Graphics.DrawString(upc.name + "\n" + upc.system, System.Drawing.SystemFonts.DefaultFont, Brushes.Black, new PointF(0, PrinterVariables.ItemInfo.nameLocY));
        }
    }

    /// <summary>
    /// Contains search terms
    /// </summary>
    public class SearchTerms
    {
        public List<string> terms = new List<string>();

        /// <summary>
        /// Divides a single search string into individual terms (separated by spaces), and stores them in the array "terms"
        /// </summary>
        /// <param name="searchText">Single string</param>
        public SearchTerms(string searchText)
        {
            // Split up input by spaces
            foreach (string term in searchText.Split(' '))
            {
                // Remove terms composed entirely of spaces
                string temp = term.Replace(" ", "");
                if (temp != "")
                    terms.Add(temp);
            }
        }

        public string GenerateSQLSearchString()
        {
            string output = "";

            // Case: list of terms is empty
            if (terms.Count == 0)
            {
                return "(Name LIKE \'%%\' OR system LIKE \'%%\') ";
            }

            for (int i = 0; i < terms.Count; i++ )
            {
                string term = terms[i];
                output += "(Name LIKE \'%" + term + "%\' OR system LIKE \'%" + term + "%\') ";

                // Add an "AND" in between conditions
                // Do not add one if it is the last search term
                if (i != terms.Count-1)
                {
                    output += "AND ";
                }
            }
            return output;
        }
    }
}
