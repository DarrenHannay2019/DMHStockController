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
    public partial class FShop : Form
    {
        public int UserID { get; set; } // to hold the user's UserID
        public string FormMode { get; set; }    // to set the mode of the form
        public string ShopRef { get; set; } // to hold the first column of the selected grid
        public FShop()
        {
            InitializeComponent();
        }
    }
}
