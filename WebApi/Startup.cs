using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using WebApi.Configurations;

namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            
            Configuration = configuration;
            
            //UnhandledException记录
            AppDomain.CurrentDomain.UnhandledException += UnhandledException;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo 
                {
                    Version = "v1",
                    Title = "Sliding Detection Web Api",
                    Description = "NTN-YULON滑移检测项目 Web Api"
                });

                // 为 Swagger JSON and UI 设置xml文档注释路径
                try
                {
                    // 获取应用程序所在绝对目录
                    var basePath = Path.GetDirectoryName(typeof(Program).Assembly.Location);
                    var xmlPath = Path.Combine(basePath, "Configurations\\Swagger.xml");
                    c.IncludeXmlComments(xmlPath);
                }
                catch (Exception e)
                {                    
                    AppLogger.Warn($"Swagger.xml路径错误",e);
                }
                
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SlidingDetectionWeb v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        /// <summary>
        /// 未处理异常处理及记录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                Exception ex = e.ExceptionObject as Exception;
                AppLogger.Error($"UnhandledException:{ex.Message}",ex);
            }
            catch { }
        }
    }
}