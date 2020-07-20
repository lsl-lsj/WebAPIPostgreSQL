using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace WebAPI04PostgreSQL.Models
{
    public class UserDaoImpl : IUserDao
    {
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="user"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public int Add(User user, IConfiguration Configuration)
        {
            string sql = $"INSERT INTO userinfo (username,password,age,gender)values (@a,@b,@c,@d)";

            using (var conn = NpgSQLUtiL.GetConnection(Configuration))
            {
                return conn.Execute(sql, new
                {
                    a = user.Username,
                    b = user.Password,
                    c = user.Age,
                    d = user.Gender
                });
            }
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="username"></param>
        /// <param name="Configuration"></param>
        /// <returns></returns>
        public int Delete(string username, IConfiguration Configuration)
        {
            string sql = "delete from userinfo where username = @a";

            using (var conn = NpgSQLUtiL.GetConnection(Configuration))
            {
                return conn.Execute(sql, new { a = username });
            }
        }


        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="user"></param>
        /// <param name="Configuration"></param>
        /// <returns></returns>
        public int Put(User user, IConfiguration Configuration)
        {
            string sql = "update userinfo set username = @a,password = @b,age = @c,gender=@d where username = @e";

            using (var conn = NpgSQLUtiL.GetConnection(Configuration))
            {
                return conn.Execute(sql, new
                {
                    a = user.Username,
                    b = user.Password,
                    c = user.Age,
                    d = user.Gender,
                    e = user.Username
                });
            }
        }

        /// <summary>
        /// 查询单个用户
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public List<User> Find(string username, IConfiguration Configuration)
        {
            List<User> list = null;
            string sql = "select * from userinfo where username = @a";

            using (var conn = NpgSQLUtiL.GetConnection(Configuration))
            {
                list = (List<User>)conn.Query<User>(sql, new { a = username });
            }
            return list;
        }

        /// <summary>
        /// 查询所有用户
        /// </summary>
        /// <param name="Configuration"></param>
        /// <returns></returns>
        public List<User> Find(IConfiguration Configuration)
        {
            List<User> list = null;

            string sql = "select * from userinfo";

            using (var conn = NpgSQLUtiL.GetConnection(Configuration))
            {
                list = (List<User>)conn.Query<User>(sql);
            }
            return list;
        }
    }
}