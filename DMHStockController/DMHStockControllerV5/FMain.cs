using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DMHStockControllerV5
{
    public partial class FMain : Form
    {
        public Form RefToLoginForm { get; set; }
        public int UserID;
        public FMain()
        {
            InitializeComponent();
        }

        private void warehousesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // To load Warehouses records from the database
            //Function 1
            FDataGrid objGrid = new FDataGrid
            {
                FunctionID = 1,
                Text = "Warehouses",
                UserID = UserID,
                MdiParent = this,
                Dock = DockStyle.Fill
            }; // setup the form ready for the function
            objGrid.Show(); // Show the form
            splitContainer1.Panel2.Controls.Add(objGrid); // add the form to the area required
            objGrid.BringToFront(); // put the selected form topmost.
        }

        private void suppliersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // To load Supplier records from the database
            //Function 2
            FDataGrid objGrid = new FDataGrid
            {
                FunctionID = 2,
                Text = "Suppliers",
                UserID = UserID,
                MdiParent = this,
                Dock = DockStyle.Fill
            }; // setup the form ready for the function
            objGrid.Show(); // Show the form
            splitContainer1.Panel2.Controls.Add(objGrid); // add the form to the area required
            objGrid.BringToFront(); // put the selected form topmost.
        }

        private void shopsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // To load Shop records from the database
            //Function 3
            FDataGrid objGrid = new FDataGrid
            {
                FunctionID = 3,
                Text = "Shops",
                UserID = UserID,
                MdiParent = this,
                Dock = DockStyle.Fill
            }; // setup the form ready for the function
            objGrid.Show(); // Show the form
            splitContainer1.Panel2.Controls.Add(objGrid); // add the form to the area required
            objGrid.BringToFront(); // put the selected form topmost.
        }

        private void currentStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // To load Current Stock records from the database
            //Function 4
            FDataGrid objGrid = new FDataGrid
            {
                FunctionID = 4,
                Text = "Current Stock",
                UserID = UserID,
                MdiParent = this,
                Dock = DockStyle.Fill
            }; // setup the form ready for the function
            objGrid.Show(); // Show the form
            splitContainer1.Panel2.Controls.Add(objGrid); // add the form to the area required
            objGrid.BringToFront(); // put the selected form topmost.
        }

        private void allStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // To load All Stock records from the database
            //Function 5
            FDataGrid objGrid = new FDataGrid
            {
                FunctionID = 5,
                Text = "All Stock",
                UserID = UserID,
                MdiParent = this,
                Dock = DockStyle.Fill
            }; // setup the form ready for the function
            objGrid.Show(); // Show the form
            splitContainer1.Panel2.Controls.Add(objGrid); // add the form to the area required
            objGrid.BringToFront(); // put the selected form topmost.
        }

        private void seasonsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // To load Season records from the database
            //Function 6
            FDataGrid objGrid = new FDataGrid
            {
                FunctionID = 6,
                Text = "Seasons",
                UserID = UserID,
                MdiParent = this,
                Dock = DockStyle.Fill
            }; // setup the form ready for the function
            objGrid.Show(); // Show the form
            splitContainer1.Panel2.Controls.Add(objGrid); // add the form to the area required
            objGrid.BringToFront(); // put the selected form topmost.
        }

        private void purchaseOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // To load Purchase Order records from the database
            //Function 7
            FDataGrid objGrid = new FDataGrid
            {
                FunctionID = 7,
                Text = "Purchase Orders",
                UserID = UserID,
                MdiParent = this,
                Dock = DockStyle.Fill
            }; // setup the form ready for the function
            objGrid.Show(); // Show the form
            splitContainer1.Panel2.Controls.Add(objGrid); // add the form to the area required
            objGrid.BringToFront(); // put the selected form topmost.
        }

        private void warehouseAdjustmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // To load Warehouse Adjustment records from the database
            //Function 8
            FDataGrid objGrid = new FDataGrid
            {
                FunctionID = 8,
                Text = "Warehouse Adjustments",
                UserID = UserID,
                MdiParent = this,
                Dock = DockStyle.Fill
            }; // setup the form ready for the function
            objGrid.Show(); // Show the form
            splitContainer1.Panel2.Controls.Add(objGrid); // add the form to the area required
            objGrid.BringToFront(); // put the selected form topmost.
        }

        private void warehouseTransfersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // To load Warehouse Transfer records from the database
            //Function 9
            FDataGrid objGrid = new FDataGrid
            {
                FunctionID = 9,
                Text = "Warehouse Transfers",
                UserID = UserID,
                MdiParent = this,
                Dock = DockStyle.Fill
            }; // setup the form ready for the function
            objGrid.Show(); // Show the form
            splitContainer1.Panel2.Controls.Add(objGrid); // add the form to the area required
            objGrid.BringToFront(); // put the selected form topmost.
        }

        private void warehouseReturnsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // To load Warehouse Return records from the database
            //Function 10
            FDataGrid objGrid = new FDataGrid
            {
                FunctionID = 10,
                Text = "Warehouse Returns",
                UserID = UserID,
                MdiParent = this,
                Dock = DockStyle.Fill
            }; // setup the form ready for the function
            objGrid.Show(); // Show the form
            splitContainer1.Panel2.Controls.Add(objGrid); // add the form to the area required
            objGrid.BringToFront(); // put the selected form topmost.
        }

        private void shopDeliveriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // To load Shop Delivery records from the database
            //Function 11
            FDataGrid objGrid = new FDataGrid
            {
                FunctionID = 11,
                Text = "Shop Delivery",
                UserID = UserID,
                MdiParent = this,
                Dock = DockStyle.Fill
            }; // setup the form ready for the function
            objGrid.Show(); // Show the form
            splitContainer1.Panel2.Controls.Add(objGrid); // add the form to the area required
            objGrid.BringToFront(); // put the selected form topmost.
        }

        private void shopAdjustmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // To load Shop Adjustment records from the database
            //Function 12
            FDataGrid objGrid = new FDataGrid
            {
                FunctionID = 12,
                Text = "Shop Adjustments",
                UserID = UserID,
                MdiParent = this,
                Dock = DockStyle.Fill
            }; // setup the form ready for the function
            objGrid.Show(); // Show the form
            splitContainer1.Panel2.Controls.Add(objGrid); // add the form to the area required
            objGrid.BringToFront(); // put the selected form topmost.
        }

        private void shopTransfersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // To load Shop Transfer records from the database
            //Function 13
            FDataGrid objGrid = new FDataGrid
            {
                FunctionID = 13,
                Text = "Shop Transfers",
                UserID = UserID,
                MdiParent = this,
                Dock = DockStyle.Fill
            }; // setup the form ready for the function
            objGrid.Show(); // Show the form
            splitContainer1.Panel2.Controls.Add(objGrid); // add the form to the area required
            objGrid.BringToFront(); // put the selected form topmost.
        }

        private void shopSalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // To load Shop Sales records from the database
            //Function 14
            FDataGrid objGrid = new FDataGrid
            {
                FunctionID = 14,
                Text = "Shop Sales",
                UserID = UserID,
                MdiParent = this,
                Dock = DockStyle.Fill
            }; // setup the form ready for the function
            objGrid.Show(); // Show the form
            splitContainer1.Panel2.Controls.Add(objGrid); // add the form to the area required
            objGrid.BringToFront(); // put the selected form topmost.
        }

        private void shopReturnsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // To load Shop Return records from the database
            //Function 15
            FDataGrid objGrid = new FDataGrid
            {
                FunctionID = 15,
                Text = "Shop Return",
                UserID = UserID,
                MdiParent = this,
                Dock = DockStyle.Fill
            }; // setup the form ready for the function
            objGrid.Show(); // Show the form
            splitContainer1.Panel2.Controls.Add(objGrid); // add the form to the area required
            objGrid.BringToFront(); // put the selected form topmost.
        }

        private void totalValuationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // To load Total Value records from the database
            //Function 16
            FDataGrid objGrid = new FDataGrid
            {
                FunctionID = 16,
                Text = "Company Valuation",
                UserID = UserID,
                MdiParent = this,
                Dock = DockStyle.Fill
            }; // setup the form ready for the function
            objGrid.Show(); // Show the form
            splitContainer1.Panel2.Controls.Add(objGrid); // add the form to the area required
            objGrid.BringToFront(); // put the selected form topmost.
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClsSettings settings = new ClsSettings();
            settings.LoadSettings();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit(); // exit the application
        }

        private void FMain_Load(object sender, EventArgs e)
        {
            // add code to customise the interface based on profile
        }
    }
}
