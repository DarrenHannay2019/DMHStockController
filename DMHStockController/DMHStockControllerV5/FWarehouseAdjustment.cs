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
    public partial class FWarehouseAdjustment : Form
    {
        public string FormMode { get; set; }
        public int UserID { get; set; }
        public DateTime OldDate { get; set; }
        public FWarehouseAdjustment()
        {
            InitializeComponent();
        }
    }
}
