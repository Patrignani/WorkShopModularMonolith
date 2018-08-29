using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WorkShop.Domain.Core.Interfaces;
using WorkShop.IO.Infra.Client.Context;

namespace WorkShop.IO.Infra.Client.Startup
{
    public class ConfigurationStartup : IConfigurationStartup
    {
        public void ConfigureService(IServiceCollection _services, IConfiguration _configuration)
        {
            _services.AddEntityFrameworkNpgsql().AddDbContext<UserContext>(options =>
           options.UseNpgsql(_configuration.GetConnectionString("Client")));
        }
    }
}
