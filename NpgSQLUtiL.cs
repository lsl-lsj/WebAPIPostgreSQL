using System;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace WebAPI04PostgreSQL
{
    public class NpgSQLUtiL
    {
        public static NpgsqlConnection GetConnection(IConfiguration Configuration)
        {
            // 从配置中读取连接字符串
            string connString = null;
            NpgsqlConnection conn = null;

            connString = Configuration.GetConnectionString("conn");

            try
            {
                conn = new NpgsqlConnection(connString);
            }
            catch
            {
                return null;
            }

            return conn;
        }
    }
}