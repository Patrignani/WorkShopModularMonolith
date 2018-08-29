using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using WorkShop.Domain.Core.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using WorkShop.IO.Infra.Chat.Initializer;
using System.Threading.Tasks;
using WorkShop.IO.Infra.Client.Initializer;

namespace WorkShop.IO.Infra.CrossCutting
{
    public static class Startup
    {

        public static void ConfigureServices(this IServiceCollection _services, IConfiguration _configuration)
        {
            IConfigurationStartup configClient = new WorkShop.IO.Infra.Client.Startup.ConfigurationStartup();
            IConfigurationStartup configChat = new WorkShop.IO.Infra.Chat.Startup.ConfigurationStartup();

            configClient.ConfigureService(_services, _configuration);
            configChat.ConfigureService(_services, _configuration);
        }

        public static async Task Configure(this IApplicationBuilder app, IConfiguration _configuration)
        {
            var dataChatInitializer = new DataChatInitializer();
            var dataClientInitializer = new DataClientInitializer();

            await dataChatInitializer.InitializeDatabaseAsync(app.ApplicationServices, _configuration);
            await dataClientInitializer.InitializeDatabaseAsync(app.ApplicationServices, _configuration);
        }

        //MyDataInitializer dataInitializer = new MyDataInitializer();
        //await dataInitializer.InitializeDatabaseAsync(app.ApplicationServices);
    }
}
