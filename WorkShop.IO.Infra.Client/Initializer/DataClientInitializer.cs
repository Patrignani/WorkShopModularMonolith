using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkShop.Client;
using WorkShop.IO.Infra.Client.Context;

namespace WorkShop.IO.Infra.Client.Initializer
{
   public class DataClientInitializer
    {
        public async Task InitializeDatabaseAsync(IServiceProvider serviceProvider, IConfiguration _configuration)
        {
            var optionsBuilder = new DbContextOptionsBuilder<UserContext>();
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("Client"));
            var db = new UserContext(optionsBuilder.Options);
            var databaseCreated = await db.Database.EnsureCreatedAsync();
            if (databaseCreated)
            {
                await GenerateData(db);
            }

        }

        private static async Task GenerateData(UserContext context)
        {
            await context.User.FirstOrDefaultAsync();
        }
    }
}
