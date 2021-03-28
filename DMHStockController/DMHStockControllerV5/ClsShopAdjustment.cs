using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DMHStockControllerV5
{
    public class ClsShopAdjustment : ClsUtils
    {
        public int ID { get; set; }


        public void LoadNewForm()
        {
            FShopAdjustment shopAdjustment = new FShopAdjustment
            {
                FormMode = "New",
                UserID = UserID
            };
            shopAdjustment.Show();
        }
        public void LoadSelectedForm()
        {
            FShopAdjustment shopAdjustment = new FShopAdjustment
            {
                FormMode = "Old"
            };
            shopAdjustment.TxtSID.Text = ID.ToString();
            shopAdjustment.Show();
        }
        public int GetLastShopAdjustmentHead()
        {
            Result = 0;
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = GetConnString(1);
                conn.Open();
                using (SqlCommand SelectCmd = new SqlCommand())
                {
                    SelectCmd.Connection = conn;
                    SelectCmd.CommandText = "SELECT COUNT(*) AS MaxRef FROM tblShopAdjustments";
                    Result = (int)SelectCmd.ExecuteScalar();
                }
            }
            return Result;
        }
    }
}
