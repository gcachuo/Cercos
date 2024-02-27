using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Cercos.Tools;

namespace Cercos.Database
{
    public class DatabaseManager
    {
        private readonly string _connectionString;

        public DatabaseManager()
        {
            DotEnv.Load();

            var dataSource = Environment.GetEnvironmentVariable("DB_HOST");
            var userId = Environment.GetEnvironmentVariable("DB_USER");
            var password = Environment.GetEnvironmentVariable("DB_PASSWORD");
            var initialCatalog = Environment.GetEnvironmentVariable("DB_NAME");

            _connectionString = $"Data Source={dataSource};Initial Catalog={initialCatalog};User ID={userId};Password={password}";
        }

        public void Insert(string query, List<SqlParameter> parameters)
        {
            using var connection = new SqlConnection(_connectionString);
            var command = new SqlCommand(query, connection);

            foreach (var parameter in parameters)
                command.Parameters.AddWithValue(parameter.ParameterName, parameter.Value);

            try
            {
                connection.Open();
                var rowsAffected = command.ExecuteNonQuery();
                Console.WriteLine(@"Filas afectadas: " + rowsAffected);
            }
            catch (Exception ex)
            {
                Console.WriteLine(@"Error: " + ex.Message);
            }
        }

        public List<T> Select<T>(string query) where T:class, new()
        {
            using var connection = new SqlConnection(_connectionString);
            var command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                var reader = command.ExecuteReader();

                var list = new List<T>();
                while (reader.Read())
                {
                    var obj = new T();
                    foreach (var prop in typeof(T).GetProperties())
                    {
                        try
                        {
                            if (!reader.IsDBNull(reader.GetOrdinal(prop.Name)))
                            {
                                prop.SetValue(obj, reader[prop.Name]);
                            }
                        }
                        catch (IndexOutOfRangeException e)
                        {
                            continue;
                        }
                    }
                    list.Add(obj);
                }

                reader.Close();

                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return null;
            }
        }
    }
}