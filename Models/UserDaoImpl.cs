using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

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

            using (var cmd = NpgSQLUtiL.GetConnection(sql, Configuration))
            {
                cmd.Parameters.AddWithValue("a", user.Username);
                cmd.Parameters.AddWithValue("b", user.Password);
                cmd.Parameters.AddWithValue("c", user.Age);
                cmd.Parameters.AddWithValue("d", user.Gender);

                return cmd.ExecuteNonQuery();
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

            using (var cmd = NpgSQLUtiL.GetConnection(sql, Configuration))
            {
                cmd.Parameters.AddWithValue("a", username);

                return cmd.ExecuteNonQuery();
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

            using (var cmd = NpgSQLUtiL.GetConnection(sql, Configuration))
            {
                cmd.Parameters.AddWithValue("a", user.Username);
                cmd.Parameters.AddWithValue("b", user.Password);
                cmd.Parameters.AddWithValue("c", user.Age);
                cmd.Parameters.AddWithValue("d", user.Gender);
                cmd.Parameters.AddWithValue("e", user.Username);
                return cmd.ExecuteNonQuery();
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
            List<User> list = new List<User>();

            string sql = "select * from userinfo where username = @a";

            using (var cmd = NpgSQLUtiL.GetConnection(sql, Configuration))
            {
                cmd.Parameters.AddWithValue("a", username);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        User user = new User();
                        user.Username = reader.GetString(0);
                        user.Password = reader.GetString(1);
                        user.Age = reader.GetInt32(2);
                        user.Gender = reader.GetString(3);
                        list.Add(user);
                    }
                }
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
            List<User> list = new List<User>();

            string sql = "select * from userinfo";

            using (var cmd = NpgSQLUtiL.GetConnection(sql, Configuration))
            {
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        User user = new User();
                        user.Username = reader.GetString(0);
                        user.Password = reader.GetString(1);
                        user.Age = reader.GetInt32(2);
                        user.Gender = reader.GetString(3);
                        list.Add(user);
                    }
                }
            }
            return list;
        }
    }
}