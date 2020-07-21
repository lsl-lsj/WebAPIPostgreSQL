using System;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace WebAPI04PostgreSQL
{
    public class NpgSQLUtiL
    {
        public readonly string _connectionString;
        public NpgSQLUtiL(IConfiguration configuration)
        {
            _connectionString = configuration.GetSection("ConnectionStrings")["conn"];
        }
        public NpgsqlConnection GetConnection()
        {
            // 从配置中读取连接字符串
            NpgsqlConnection conn = null;


            try
            {
                conn = new NpgsqlConnection(_connectionString);
            }
            catch
            {
                return null;
            }

            return conn;
        }
    }
}