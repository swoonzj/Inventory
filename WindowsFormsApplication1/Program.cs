using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Configuration;
using System.Data.SqlClient;


namespace Inventory
{
    static class Program
    {
        

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]


        


        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);


            //System.Media.SoundPlayer player = new System.Media.SoundPlayer(@".\WelcomeBack.wav");
            //player.Play();

            // Verify that tables exist
            DBaccess.CheckTableExistance();

            //Application.Run(new POSinventory());
            //Application.Run(new ManageInventory());
            //Application.Run(new CustomerInfoScreen(DBaccess.GetCustomer(1)));
            CustomerTest();
        }

        static void CustomerTest()
        {
            Customer customer = new Customer("Steve", "123@email.com", "555-5555");
            customer.saveDataToDB();
            MessageBox.Show(customer.name + ": " + customer.id);
        }
    }
}
     