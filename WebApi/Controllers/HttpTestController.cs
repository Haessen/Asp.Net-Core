using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApi.Configurations;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class HttpTestController : ControllerBase
    {

        /// <summary>
        /// HttpGet测试
        /// </summary>
        /// <returns>Hello World!</returns>
        [HttpGet]
        //public string Get()
        //{
        //    AppLogger.Info("HttpGet测试");
        //    return "Hello World!";
        //}
        public async Task<string> GetAsync()
        {
            AppLogger.Info("HttpGet测试");
            await Task.Delay(3000);
            return "Hello World!";
        }

        /// <summary>
        /// HttpPost测试
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        [HttpPost]
        public string Post(int id)
        {
            AppLogger.Info($"HttpPost测试");
            return $"输入的id为{id}";
        }
    }
}
