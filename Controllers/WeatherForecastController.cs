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
        private IConfiguration _configuration;

        public WeatherForecastController(IConfiguration Configuration)
        {
            _configuration = Configuration;
        }
        UserDaoImpl impl = new UserDaoImpl();

        [HttpPost]
        public string Post(User user)
        {
            int r = impl.Add(user, _configuration);
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
            int r = impl.Delete(Username, _configuration);

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
            int r = impl.Put(user, _configuration);

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
        public List<User> FindOne(string Username)
        {
            if (Username == null)
            {
                return impl.Find(_configuration);
            }
            else
            {
                return impl.Find(Username, _configuration);
            }
        }
    }
}
