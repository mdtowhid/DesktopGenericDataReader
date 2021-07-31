using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    public static class Helpers
    {
        public static T DataReaderToObjectMapper<T>(SqlDataReader reader, [Optional] string query) where T : class, new()
        {
            T t = new T();
            PropertyInfo[] propertyInfos = t.GetType().GetProperties();
            var assertions = AssertionFromQuery(query);
            if (assertions.Count > 0)
            {
                foreach (KeyValuePair<string, string> kvp in assertions)
                {
                    foreach (var pi in propertyInfos)
                    {
                        var name = pi.Name;
                        if(name == kvp.Key)
                        {
                            if (!reader.HasColumnName(kvp.Value))
                                continue;
                            PropInforToObj(pi, ref t, reader, kvp.Value, pi.PropertyType.FullName);
                        }
                    }
                }
            }
            else
            {
                foreach (var pi in propertyInfos)
                {
                    var name = pi.Name;
                    PropInforToObj(pi, ref t, reader, name, pi.PropertyType.FullName);
                }
            }
            return t;
        }
        private static void PropInforToObj<T>(PropertyInfo pi, ref T t, SqlDataReader reader, string readerIndexName, string conversionTypeName)
        {
            switch (conversionTypeName)
            {
                case "System.Int32":
                    pi.SetValue(t, Convert.ToInt32(reader[readerIndexName].ToString()));
                    break;
                case "System.Int64":
                    pi.SetValue(t, Convert.ToInt64(reader[readerIndexName].ToString()));
                    break;
                case "System.String":
                    pi.SetValue(t, reader[readerIndexName].ToString());
                    break;
                case "System.DateTime":
                    pi.SetValue(t, Convert.ToDateTime(reader[readerIndexName].ToString()));
                    break;
                case "System.Boolean":
                    pi.SetValue(t, ConvertToBoolean(reader[readerIndexName].ToString()));
                    break;
                default:
                    break;
            }
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
        public static Dictionary<string,  string> AssertionFromQuery(string query)
        {
            Dictionary<string, string> names = new Dictionary<string, string>();
            var isExistAs = query.Contains("AS");
            if (isExistAs)
            {
                string[] assertions = query.Split(' ');
                for (int i = 0; i < assertions.Length; i++)
                {
                    var assertion = assertions[i].ToLower();

                    if (assertion == "as")
                    {
                        var a = assertions[i - 1].Trim();
                        var b = assertions[i + 1].Trim();
                        b = b.Contains(",") ? b.Replace(",", "") : b;
                        names.Add(a, b);
                    }
                }
            }

            return names;
        }
    }
}
