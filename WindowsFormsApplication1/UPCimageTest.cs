using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace Inventory
{
    public partial class UPCimageTest : Form
    {
        UPC upc;
        Item item;
        public UPCimageTest()
        {
            InitializeComponent();
        }

        private void UPCimageTest_Load(object sender, EventArgs e)
        {
            item = DBaccess.GetItemWithUPC(TableNames.INVENTORY, "733132116508");
            picUPC.Image = upc.upcImage;
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            upc = new UPC(txtUPC.Text);
            picUPC.Image = upc.upcImage;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Printer.PrintUPCLabel(item);
        }
    }
}
