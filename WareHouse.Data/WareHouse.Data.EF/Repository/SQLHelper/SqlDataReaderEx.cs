using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WareHouse.Data.EF.Repository.SQLHelper
{
    public static class SqlDataReaderEx
    {
        public static object GetValueFromReader(this SqlDataReader reader, int i, Type type)
        {
            if (type == typeof(int))
            {
                return reader.GetInt32(i);
            }

            if (type == typeof(string))
            {
                return reader.GetString(i);
            }

            if (type == typeof(long))
            {
                return reader.GetInt64(i);
            }

            if (type == typeof(bool))
            {
                return reader.GetBoolean(i);
            }

            if (type == typeof(DateTime))
            {
                return reader.GetDateTime(i);
            }

            return reader.GetProviderSpecificValue(i);
        }
    }
}
