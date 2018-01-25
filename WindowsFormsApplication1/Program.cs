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
            
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(@".\WelcomeBack.wav");
            player.Play();

            Application.Run(new POSinventory());
            //Application.Run(new ManageInventory());

        }
    }
}
     