using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

using System.IO;
using System.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dapper;
using Microsoft.Data.SqlClient;


namespace BlogDataLibrary
{
    public class SqlDataAccess
    {
        private static IConfiguration GetConfiguration()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }

        public static List<T> LoadData<T, U>(string sql, U parameters)
        {
            var config = GetConfiguration();

            string connectionString =
                config.GetConnectionString("Default");

            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<T>(sql, parameters).ToList();
            }
        }

        public static int SaveData<T>(string sql, T parameters)
        {
            var config = GetConfiguration();

            string connectionString =
                config.GetConnectionString("Default");

            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Execute(sql, parameters);
            }
        }

    }
}
