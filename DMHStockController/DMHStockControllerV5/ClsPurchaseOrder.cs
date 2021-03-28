using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMHStockControllerV5
{
    public class ClsPurchaseOrder : ClsUtils
    {
        public int PurchaseOrderID { get; set; }
        public ClsPurchaseOrder()
        {
            SaveToDB = false;
            UpdateToDB = false;
            DeleteFromDB = false;
        }
        ~ClsPurchaseOrder()
        {
            SaveToDB = false;
            UpdateToDB = false;
            DeleteFromDB = false;
        }
        public void LoadNewPurchaseOrder()
        {
            FPurchaseOrder oPurchaseOrder = new FPurchaseOrder
            {
                FormMode = "New",
                UserID = UserID
            };
            oPurchaseOrder.ShowDialog();
        }
        public void LoadSelectedPurchaseOrder()
        {
            FPurchaseOrder oPurchaseOrder = new FPurchaseOrder
            {
                FormMode = "Old"
            };
            oPurchaseOrder.TxtOrderID.Text = PurchaseOrderID.ToString();
            oPurchaseOrder.ShowDialog();
        }
    }
}
