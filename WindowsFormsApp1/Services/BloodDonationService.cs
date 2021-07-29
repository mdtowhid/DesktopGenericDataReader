using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Data;
using WindowsFormsApp1.Models;

namespace WindowsFormsApp1.Services
{
    public class BloodDonationService
    {
        public static List<BloodDonator> GetBloodDonators()
        {
            string query = "SELECT * FROM BloodDonators";
            List<BloodDonator> bloodDonators = new List<BloodDonator>();
            SqlConnection conn = Database.GetSqlConnection();
            SqlCommand cmd = Database.GetSqlCommand(query, conn);
            conn.Open();

            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        BloodDonator bdr = Helpers.DataReaderToObjectMapper<BloodDonator>(reader);
                        bloodDonators.Add(bdr);
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return bloodDonators;
        }

        public static List<BloodGroup> GetBloodGroups()
        {
            string query = "SELECT * FROM BloodGroups";
            List<BloodGroup> bloodGroups = new List<BloodGroup>();
            SqlConnection conn = Database.GetSqlConnection();
            SqlCommand cmd = Database.GetSqlCommand(query, conn);
            conn.Open();

            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        bloodGroups.Add(Helpers.DataReaderToObjectMapper<BloodGroup>(reader));
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                conn.Close();
            }

            return bloodGroups;
        }
    }
}
