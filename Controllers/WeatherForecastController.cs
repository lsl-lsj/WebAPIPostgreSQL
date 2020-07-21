using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using WebAPI04PostgreSQL.Models;

namespace WebAPI04PostgreSQL.Controllers
{
    [ApiController]
    [Route("")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly IUserDao _userDao;
        public WeatherForecastController(IUserDao userDao)
        {
            _userDao = userDao;
        }

        [HttpPost]
        public string Post(User user)
        {
            int r = 0;
            r = _userDao.Add(user);
            if (r == 0)
            {
                return "未添加成功";
            }
            else
            {
                return $"成功添加{r}行。";
            }
        }

        [HttpDelete]
        public string Delete(string Username)
        {
            int r = 0;
            r = _userDao.Delete(Username);
            if (r == 0)
            {
                return "删除失败";
            }
            else
            {
                return $"成功删除{r}行";
            }
        }

        [HttpPut]
        public string Put(User user)
        {
            int r = 0;
            r = _userDao.Put(user);
            if (r == 0)
            {
                return "修改失败";
            }
            else
            {
                return $"成功修改{r}行";
            }
        }

        [HttpGet]
        public List<User> Find(string Username)
        {
            if (Username == null)
            {
                return _userDao.Find();
            }
            else
            {
                return _userDao.Find(Username);
            }
        }
    }
}
