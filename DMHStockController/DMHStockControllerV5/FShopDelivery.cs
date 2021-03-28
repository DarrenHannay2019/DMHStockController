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
    public partial class FShopDelivery : Form
    {
        public int UserID { get; set; } // to hold the user's UserID
        public string FormMode { get; set; }    // to set the mode of the form
        public DateTime OldDate { get; set; }
        public FShopDelivery()
        {
            InitializeComponent();
        }
    }
}
