using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace WareHouse.Data.EF.Repository.SQLHelper
{
    public delegate object SQLGetAnswerMethod(SqlDataReader reader, Type type);

    public class SQLHelper
    {
        public string ConnectionString { get; private set; }

        public SQLHelper(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public async Task<IEnumerable<T>> GetItemsAsync<T>(string query, params SqlParameter[] parameters) where T : new()
        {
            return await ExecSQLAsync<IEnumerable<T>>(query, 
                (reader, type) => GetItemsFromReader<T>(reader, type.GenericTypeArguments.First())
                , parameters);
        }

        public async Task<T> GetFirstItemAsync<T>(string query, params SqlParameter[] parameters) where T : new()
        {
            return await ExecSQLAsync<T>(query, GetFirstItemFromReader, parameters);
        }

        private object GetFirstItemFromReader(SqlDataReader reader, Type type)
        {
            while (reader.Read())
            {
                return ReaderRowToObject(reader, type);
            }

            return null;
        }

        private object GetItemsFromReader<T>(SqlDataReader reader, Type type)
        {
            var items = new List<T>();

            while (reader.Read())
            {
                items.Add((T)ReaderRowToObject(reader, type));
            }

            return items;
        }

      
        private object ReaderRowToObject(SqlDataReader reader, Type type)
        {
            var props = type.GetProperties()
                .Where(x => !x.PropertyType.GetTypeInfo().IsClass || x.PropertyType == typeof(string))
                .ToArray();

            object obj = Activator.CreateInstance(type);

            for (int i = 0; i < reader.FieldCount; i++)
            {
                var prop = props.FirstOrDefault(x => x.Name == reader.GetName(i));

                if (prop == null)
                {
                    continue;
                }

                prop.SetValue(obj, reader.GetValueFromReader(i, prop.PropertyType));
            }

            return obj;
        }

        public async Task<int> Count(string storedProcedureName)
        {
            return await ExecSQLAsync<int>($"exec {storedProcedureName}", GetCountFromReader);
        }

        private object GetCountFromReader(SqlDataReader reader, Type type)
        {
            reader.Read();

            return reader.GetInt32(0);
        }

        public async Task ExecSQLAsync(string query, params SqlParameter[] parameters)
        {
            await ExecSQLAsync<object>(query, null, parameters);
        }

        public async Task<T> ExecSQLAsync<T>(string query, SQLGetAnswerMethod sqlGetAnswer, params SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                var reader = await CreateQuery(connection, query, parameters).ExecuteReaderAsync();

                T result = default(T);

                if (sqlGetAnswer != null && reader.HasRows)
                {
                    result = (T)sqlGetAnswer(reader, typeof(T));
                }

                reader.Dispose();
                return result;
            }
        }

        private SqlCommand CreateQuery(SqlConnection connection, string query, IEnumerable<SqlParameter> args)
        {
            var sql = new SqlCommand(query, connection);

            foreach (var param in args)
            {
                sql.Parameters.Add(param);
            }

            return sql;
        }
    }
}
