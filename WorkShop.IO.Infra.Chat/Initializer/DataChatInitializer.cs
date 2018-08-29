using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WorkShop.IO.Infra.Chat.Context;

using WorkShop.Domain.Chat;
using WorkShop.Domain.Chat.Constatnt;
using WorkShop.Domain.Chat.ENUM;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace WorkShop.IO.Infra.Chat.Initializer
{
   public  class DataChatInitializer
    {
 
        public async Task InitializeDatabaseAsync(IServiceProvider serviceProvider, IConfiguration _configuration)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ChatContext>();
            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("Chat"));
            var db = new ChatContext(optionsBuilder.Options);
            var databaseCreated = await db.Database.EnsureCreatedAsync();
            if (databaseCreated)
            {
                await GenerateData(db);
            }

        }

        private static async Task GenerateData(ChatContext context)
        {
            context.Group.Add(new Group(DataInit.PublicGroup, (int)TypeGroup.PublicGroup));
            await context.SaveChangesAsync();

        }
    }
}
