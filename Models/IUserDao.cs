using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace WebAPI04PostgreSQL.Models
{
    public interface IUserDao
    {
        /// <summary>
        /// 查询单个用户
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        List<User> Find(string username);
        
       /// <summary>
       /// 查询所有用户
       /// </summary>
       /// <returns></returns>
        List<User> Find();

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        int Add(User user);

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        int Delete(string username);

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="user"></param>
        /// <param name="Configuration"></param>
        /// <returns></returns>
        int Put(User user);
    }
}