using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CRMApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)

                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseKestrel(options => { options.Listen(IPAddress.Any, 9091); }); //5201�����õĶ˿ڣ���ĳ��Լ���
                    webBuilder.UseStartup<Startup>();
                    webBuilder.ConfigureKestrel(c => c.Limits.MaxRequestBodySize = 1024 * 1024 * 200); // ȫ�ֵĴ�С200M

                });
    }
}
