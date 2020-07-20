using System;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace WebAPI04PostgreSQL
{
    public  class NpgSQLUtiL
    {
        public static NpgsqlCommand GetConnection(string sql,IConfiguration Configuration)
        {
            // 从文件中读取连接字符串
            string connString = null;
            NpgsqlCommand cmd = null;

            /* using (StreamReader sr = new StreamReader("Configuration.txt"))
            {
                // 从当前流中异步读取一行字符并将数据作为字符串返回
                connString = sr.ReadLine();
            } */

            connString = Configuration.GetConnectionString("conn");

            Console.WriteLine(connString);
        
            try
            {
                NpgsqlConnection conn = new NpgsqlConnection(connString);
                // 打开数据库
                conn.Open();
                cmd = new NpgsqlCommand(sql, conn);
            }
            catch
            {
                return null;
            }

            return cmd;
        }
    }
}