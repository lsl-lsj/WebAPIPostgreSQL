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
        /// <param name="Configuration"></param>
        /// <returns></returns>
        List<User> Find(string username, IConfiguration Configuration);
        
        /// <summary>
        /// 查询所有用户
        /// </summary>
        /// <param name="Configuration"></param>
        /// <returns></returns>
        List<User> Find(IConfiguration Configuration);

        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="user"></param>
        /// <param name="Configuration"></param>
        /// <returns></returns>
        int Add(User user, IConfiguration Configuration);

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="username"></param>
        /// <param name="Configuration"></param>
        /// <returns></returns>
        int Delete(string username, IConfiguration Configuration);

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="user"></param>
        /// <param name="Configuration"></param>
        /// <returns></returns>
        int Put(User user, IConfiguration Configuration);
    }
}