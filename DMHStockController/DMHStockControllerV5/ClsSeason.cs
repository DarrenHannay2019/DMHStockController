using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DMHStockControllerV5
{
    public class ClsSeason : ClsUtils
    {
        // properties for the class
        // started 02/01/2020
        // completed 02/01/2020
        public int SeasonID { get; set; }
        public string SeasonName { get; set; }
        // constructor for the class
        public ClsSeason()
        {
            SaveToDB = false;
            UpdateToDB = false;
            DeleteFromDB = false;
        }
        // deconstructor for the class
        ~ClsSeason()
        {
            SaveToDB = false;
            UpdateToDB = false;
            DeleteFromDB = false;
        }
        public void LoadNewRecord()
        {
            FSeason season = new FSeason
            {
                FormMode = "New",
                Text = "New Season"
            };
            season.ShowDialog();
        }
        public void LoadSelectedSeason()
        {
            FSeason season = new FSeason()
            {
                FormMode = "Old",
                Text = "Update Season",
                SeasonID = SeasonID
            };
            season.ShowDialog();
        }
        public bool SaveSeasonRecordToDB()
        {
            // Save the Season name to the database
            using (SqlConnection conn = new SqlConnection())
            {
                try
                {
                    conn.ConnectionString = GetConnString(1);
                    conn.Open();
                    using (SqlCommand InsertCmd = new SqlCommand())
                    {
                        InsertCmd.Connection = conn;
                        InsertCmd.CommandType = CommandType.Text;
                        InsertCmd.CommandText = "INSERT INTO tblSeasons (SeasonName) VALUES (@SeasonName)";
                        InsertCmd.Parameters.AddWithValue("@SeasonName", SeasonName);
                        Result = (int)InsertCmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Unable to Open connection to Database\nBecause : " + ex.Message.ToString(), Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                }
            }
            if (Result != 1)
            {
                SaveToDB = false;
            }
            else
            {
                SaveToDB = true;
            }
            return SaveToDB;
        }
        public bool UpdateSeasonRecordInDB()
        {
            // Update the season name against the Season ID
            UpdateToDB = true;
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = GetConnString(1);
                    conn.Open();
                    using (SqlCommand UpdateCmd = new SqlCommand())
                    {
                        UpdateCmd.Connection = conn;
                        UpdateCmd.CommandType = CommandType.Text;
                        UpdateCmd.CommandText = "UPDATE tblSeasons SET SeasonName = @SeasonName WHERE SeasonID = @SeasonID";
                        UpdateCmd.Parameters.AddWithValue("@SeasonID", SeasonID);
                        UpdateCmd.Parameters.AddWithValue("@SeasonName", SeasonName);
                        Result = (int)UpdateCmd.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
            if (Result != 1)
                UpdateToDB = false;
            else
                UpdateToDB = true;
            return UpdateToDB;
        }
        public bool DeleteSeasonRecordFromDB()
        {
            // delete the selected record from the database
            DeleteFromDB = false;
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = GetConnString(1);
                    conn.Open();
                    using (SqlCommand DeleteCmd = new SqlCommand())
                    {
                        DeleteCmd.Connection = conn;
                        DeleteCmd.CommandType = CommandType.Text;
                        DeleteCmd.CommandText = "DELETE FROM tblSeasons WHERE SeasonID = @SeasonID";
                        DeleteCmd.Parameters.AddWithValue("@SeasonID", SeasonID);
                        DeleteFromDB = Convert.ToBoolean(DeleteCmd.ExecuteNonQuery());
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                DeleteFromDB = false;
                throw;
            }
            return DeleteFromDB;
        }
    }
}
