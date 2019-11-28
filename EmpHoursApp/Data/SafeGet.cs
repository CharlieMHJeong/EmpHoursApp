using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

using EmpHoursApp.ViewModel;


namespace EmpHoursApp.Data
{
    public static class SafeGet
    {
        //public static double? SafeGetFloat(this SqlDataReader reader, int colIndex)
        //{
        //    if (!reader.IsDBNull(colIndex))
        //    {
        //        return reader.GetFloat(colIndex);
        //    }
        //    else
        //    {
        //        return 0;
        //    }
        //}

        //public static double? SafeGetFloat(this SqlDataReader reader, string colName)
        //{
        //    int colIndex = reader.GetOrdinal(colName);

        //    if (!reader.IsDBNull(colIndex))
        //    {
        //        return reader.GetFloat(colIndex);
        //    }
        //    else
        //    {
        //        return 0;
        //    }
        //}
        public static double? SafeGetDouble(this SqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
            {
                return reader.GetDouble(colIndex);

            }
            else
            {
                return 0;
            }
        }

        public static double? SafeGetDouble(this SqlDataReader reader, string colName)
        {
            int colIndex = reader.GetOrdinal(colName);

            if (!reader.IsDBNull(colIndex))
            {
                return reader.GetDouble(colIndex);
            }
            else
            {
                return 0;
            }
        }
        public static string SafeGetString(this SqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
            {
                return reader.GetString(colIndex);
            }
            else
            {
                return null;
            }
        }
        public static string SafeGetString(this SqlDataReader reader, string colName)
        {
            int colIndex = reader.GetOrdinal(colName);

            if (!reader.IsDBNull(colIndex))
            {
                return reader.GetString(colIndex);
            }
            else
            {
                return null;
            }
        }

        public static int? SafeGetInt(this SqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
            {
                return reader.GetInt32(colIndex);
            }
            else
            {
                return 0;
            }
        }

        public static int? SafeGetInt(this SqlDataReader reader, string colName)
        {
            int colIndex = reader.GetOrdinal(colName);

            if (!reader.IsDBNull(colIndex))
            {
                return reader.GetInt32(colIndex);
            }
            else
            {
                return 0;
            }
        }
    }
}
