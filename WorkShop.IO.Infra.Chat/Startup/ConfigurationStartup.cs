using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WorkShop.Domain.Core.Interfaces;
using WorkShop.IO.Infra.Chat.Context;

namespace WorkShop.IO.Infra.Chat.Startup
{
    public class ConfigurationStartup: IConfigurationStartup
    {
        public void ConfigureService(IServiceCollection _services, IConfiguration _configuration)
        {
            _services.AddEntityFrameworkNpgsql().AddDbContext<ChatContext>(options =>
           options.UseNpgsql(_configuration.GetConnectionString("Chat")));
            
        }
    }
}