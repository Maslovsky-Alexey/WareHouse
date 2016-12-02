using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace WareHouse.Data.SQL.SQLHelper
{
    delegate object GetMethod(SqlDataReader reader, int i);

    public static class SqlDataReaderEx
    {
        private static Dictionary<Type, GetMethod> TypesMap;

        public static object GetValueFromReader(this SqlDataReader reader, int i, Type type)
        {
            GetMethod getAnswerMathod;

            if (TypesMap.TryGetValue(type, out getAnswerMathod))
            {
                return getAnswerMathod.Invoke(reader, i);
            }

            return null;
        }

        static SqlDataReaderEx()
        {
            TypesMap = new Dictionary<Type, GetMethod>();

            TypesMap.Add(typeof(int), (reader, i) => reader.GetInt32(i));
            TypesMap.Add(typeof(string), (reader, i) => reader.GetString(i));
            TypesMap.Add(typeof(long), (reader, i) => reader.GetInt64(i));
            TypesMap.Add(typeof(bool), (reader, i) => reader.GetBoolean(i));
            TypesMap.Add(typeof(DateTime), (reader, i) => reader.GetDateTime(i));
        }
    }
}
