using Consul;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http;


namespace WebApi_Aps.Utils
{
    public static class ConsulHelper
    {
        public static void ConsulRegist()
        {
            ConsulClient client = new ConsulClient(c =>
            {
                //c.Address = new Uri("http://127.0.0.1:8500");
                c.Address = new Uri($"http://{ConfigurationManager.AppSettings["ConsulIP"]}:{ConfigurationManager.AppSettings["ConsulPort"]}");
                c.Datacenter = "dc1";
            });
            // 该项目文件夹下cmd命令：dotnet xx.dll --urls="http://*:9090" --ip:"127.0.0.1" --port:9090
            var address = ConfigurationManager.AppSettings["ServerIp"];  // 使用命令执行项目传递的ip地址;
            var port = int.Parse(ConfigurationManager.AppSettings["ServerPort"]); // 使用命令执行项目传递的端口
            var healthUrl = $"http://{address}:{port}{ ConfigurationManager.AppSettings["Health"]}";
            
            client.Agent.ServiceRegister(new AgentServiceRegistration()
            {
                ID = "service" + Guid.NewGuid(), // 唯一的
                Name = ConfigurationManager.AppSettings["ConsulGroup"], // 组名称-Group
                Address = address,
                Port = port,
                Tags = new string[] { healthUrl }, // 标签，<br>　　　　　　　　　　// 心跳健康检查

                Check = new AgentServiceCheck()
                {
                    Interval = TimeSpan.FromSeconds(12), // 间隔12s一次
                    HTTP = healthUrl,  // 调健康检查接口
                    Timeout = TimeSpan.FromSeconds(5), // 检查等待时间
                    DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(60) // 失败后多久移除 最小值60s
                }
            });
        }
    }
}