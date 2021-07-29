using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Data;

namespace WindowsFormsApp1.Services
{
    public abstract class BaseService<T> where T: class, new()
    {
        public static List<T> GetAll(string query)
        {
            return Populator(query);
        }

        public static T Get(string query)
        {
            return Populator(query)[0];
        }

        static List<T> Populator(string query)
        {
            SqlConnection conn = Database.GetSqlConnection();
            SqlCommand cmd = Database.GetSqlCommand(query, conn);
            conn.Open();
            List<T> objs = new List<T>();

            try
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        T t = Helpers.DataReaderToObjectMapper<T>(reader);
                        objs.Add(t);
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

            return objs;
        }
    }
}
