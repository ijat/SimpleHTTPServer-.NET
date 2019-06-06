using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace SimpleHTTPServer
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(
            builder =>
            {
                builder.AddFilter("Microsoft", LogLevel.Error)
                       .AddFilter("System", LogLevel.Error)
                       .AddFilter("NToastNotify", LogLevel.Error)
                       .AddConsole();
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var options = new FileServerOptions()
            {
                FileProvider = env.ContentRootFileProvider,
                RequestPath = String.Empty,
                EnableDirectoryBrowsing = true,
                EnableDefaultFiles = true
            };

            options.StaticFileOptions.ServeUnknownFileTypes = true;

            app.UseFileServer(options);
        }
    }
}
