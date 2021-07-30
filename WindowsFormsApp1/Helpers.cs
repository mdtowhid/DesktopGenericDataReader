using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public static class Helpers
    {
        public static T DataReaderToObjectMapper<T>(SqlDataReader reader) where T : class, new()
        {
            T t = new T();
            PropertyInfo[] propertyInfos = t.GetType().GetProperties();
            foreach (var pi in propertyInfos)
            {
                var name = pi.Name;
                if (!reader.HasColumnName(name))
                    continue;

                try
                {
                    var typeFullName = pi.PropertyType.FullName;

                    switch (typeFullName)
                    {
                        case "System.Int32":
                            pi.SetValue(t, Convert.ToInt32(reader[name].ToString()));
                            break;
                        case "System.Int64":
                            pi.SetValue(t, Convert.ToInt64(reader[name].ToString()));
                            break;
                        case "System.String":
                            pi.SetValue(t, reader[name].ToString());
                            break;
                        case "System.DateTime":
                            pi.SetValue(t, Convert.ToDateTime(reader[name].ToString()));
                            break;
                        case "System.Boolean":
                            pi.SetValue(t, ConvertToBoolean(reader[name].ToString()));
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
            return t;
        }

        private static bool ConvertToBoolean(string input)
        {
            switch (input.ToLower())
            {
                case "0":
                    return false;
                case "1":
                    return true;
                case "no":
                    return false;
                case "yes":
                    return true;
                case "true":
                    return true;
                case "false":
                    return false;
                default:
                    return false;
            }
        }

        private static bool HasColumnName(this SqlDataReader reader, string columnName)
        {
            bool isExistColumnName = false;
            for (int i = 0; i < reader.FieldCount; i++)
            {
                var x = reader.GetName(i);
                isExistColumnName = x == columnName;
                if(isExistColumnName)
                    break;
            }
            return isExistColumnName;
        }
    }
}
