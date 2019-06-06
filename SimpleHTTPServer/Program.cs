using System;
using System.IO;
using System.Linq;
using System.Net;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace SimpleHTTPServer
{
    public class Program
    {
        static string rootPath = Directory.GetCurrentDirectory();

        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            string path = Directory.GetCurrentDirectory();
            string portStr = args.ElementAtOrDefault(0);
            int port = String.IsNullOrEmpty(portStr) ? 8000 : Int32.Parse(portStr);
            string privkeyPath = args.ElementAtOrDefault(1);
            string privkeySecret = args.ElementAtOrDefault(2);

            if (String.IsNullOrWhiteSpace(privkeyPath))
                return WebHost.CreateDefaultBuilder(args)
                        .UseUrls($"http://*:{port}")
                        .UseContentRoot(path)
                        .UseKestrel()
                        .UseStartup<Startup>();
            else
                return WebHost.CreateDefaultBuilder(args)
                .UseContentRoot(path)
                .UseKestrel(options =>
                {
                    options.Listen(IPAddress.Any, port, listenOptions => {
                        listenOptions.UseHttps(privkeyPath, privkeySecret);
                    });
                })
                .UseStartup<Startup>();
        }
    }
}
