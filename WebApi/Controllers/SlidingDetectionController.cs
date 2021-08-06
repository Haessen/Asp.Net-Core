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
    public class SlidingDetectionController : ControllerBase
    {

        /// <summary>
        /// HttpGet测试
        /// </summary>
        /// <returns>Hello World!</returns>
        [HttpGet]
        public string HttpGetTest()
        {
            AppLogger.Info("HttpGet测试");
            return "Hello World!";
        }

        /// <summary>
        /// HttpPost测试
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        [HttpPost]
        public string HttpPostTest(int id)
        {
            AppLogger.Info($"HttpPost测试");
            return $"输入的id为{id}";
        }
    }
}
