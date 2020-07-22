using System.Collections.Generic;
using Dapper;
using Microsoft.Extensions.Configuration;

namespace WebAPI04PostgreSQL.Models
{

    public class UserDaoImpl : IUserDao
    {
        private readonly NpgSQLUtiL _npgSQLUtiL;

        public UserDaoImpl(NpgSQLUtiL npgSQLUtiL)
        {
            _npgSQLUtiL = npgSQLUtiL;
        }

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int Add(User user)
        {
            string sql = $"INSERT INTO userinfo (username,password,age,gender)values (@a,@b,@c,@d)";

            using (var conn = _npgSQLUtiL.GetConnection())
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
       /// <returns></returns>
        public int Delete(string username)
        {
            string sql = "delete from userinfo where username = @a";

            using (var conn = _npgSQLUtiL.GetConnection())
            {
                return conn.Execute(sql, new { a = username });
            }
        }

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int Put(User user)
        {
            string sql = "update userinfo set username = @a,password = @b,age = @c,gender=@d where username = @e";

            using (var conn = _npgSQLUtiL.GetConnection())
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
        /// <returns></returns>
        public List<User> Find(string username)
        {
            List<User> list = null;
            string sql = "select * from userinfo where username = @a";

            using (var conn = _npgSQLUtiL.GetConnection())
            {
                list = (List<User>)conn.Query<User>(sql, new { a = username });
            }
            return list;
        }

        /// <summary>
        /// 查询所有用户
        /// </summary>
        /// <returns></returns>
        public List<User> Find()
        {
            List<User> list = null;

            string sql = "select * from userinfo";

            using (var conn = _npgSQLUtiL.GetConnection())
            {
                list = (List<User>)conn.Query<User>(sql);
            }
            return list;
        }
    }
}