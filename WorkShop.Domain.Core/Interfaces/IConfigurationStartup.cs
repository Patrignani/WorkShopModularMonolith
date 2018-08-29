using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace WorkShop.Domain.Core.Interfaces
{
    public interface IConfigurationStartup
    {
          void ConfigureService(IServiceCollection _services, IConfiguration _configuration);
    }
}