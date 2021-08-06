using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Configurations
{

    public sealed class AppLogger
    {
        static AppLogger()
        {
            if (Logger == null)
            {
                var repository = LogManager.CreateRepository("NETCoreRepository");
                //log4net从log4net.config文件中读取配置信息
                XmlConfigurator.Configure(repository, new FileInfo("Configurations/log4net.config"));
                Logger = LogManager.GetLogger(repository.Name, "InfoLogger");
            }
        }

        public static ILog Logger { get; set; }

        /// <summary>
        /// Info日志
        /// </summary>
        /// <param name="message"></param>
        /// <param name="e"></param>
        public static void Info(string message, Exception e = null)
        {
            if (e is null)
                Logger.Info(message);
            else
                Logger.Info(message, e);
        }

        /// <summary>
        /// Debug日志
        /// </summary>
        /// <param name="message"></param>
        /// <param name="e"></param>
        public static void Debug(string message, Exception e = null)
        {
            if (e is null)
                Logger.Debug(message);
            else
                Logger.Debug(message, e);
        }

        /// <summary>
        /// Warn日志
        /// </summary>
        /// <param name="message"></param>
        /// <param name="e"></param>
        public static void Warn(string message, Exception e = null)
        {
            if (e is null)
                Logger.Warn(message);
            else
                Logger.Warn(message, e);
        }

        /// <summary>
        /// Error日志
        /// </summary>
        /// <param name="message"></param>
        /// <param name="e"></param>
        public static void Error(string message, Exception e = null)
        {
            if (e is null)
                Logger.Error(message);
            else
                Logger.Error(message, e);
        }

    }
}
