using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Inventory
{
    public partial class FormatCSV : Form
    {
        private string filelocation;

        public FormatCSV()
        {
            InitializeComponent();
        }

        private void Unhide(object sender, FormClosingEventArgs e)
        {
            this.Show();
        }

        private void FormatCSV_Load(object sender, EventArgs e)
        {
            OpenFileDialog CSVbrowse = new OpenFileDialog();
            CSVbrowse.Title = "Select .csv File";
            CSVbrowse.Filter = "Stupid Ass Bitch Files|*.csv";
            CSVbrowse.InitialDirectory = @".";

            if (CSVbrowse.ShowDialog() == DialogResult.OK)
            {
                // Display 1st line of file to verify,
                // then choose whether to import all columns, or only first (name) column
                //
                // Items are saved to table 'tblTemp' first, to avoid any accidental conflicts.
                // Intentional conflicts are still okay.   <--- joke. But not really.

                filelocation = CSVbrowse.FileName.ToString();

                System.IO.StreamReader file = new System.IO.StreamReader(filelocation);
                lblLine.Text = file.ReadLine();
                                                

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnFormat_Click(object sender, EventArgs e)
        {

        }

        
    }
}
