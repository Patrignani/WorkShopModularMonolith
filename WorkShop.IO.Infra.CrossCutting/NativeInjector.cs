using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using WorkShop.Client.Interface;
using WorkShop.Domain.Chat.Event;
using WorkShop.Domain.Chat.Interface;
using WorkShop.Domain.Client.Event;
using WorkShop.IO.Infra.Chat.Context;
using WorkShop.IO.Infra.Client.Context;

namespace WorkShop.IO.Infra.CrossCutting.Client
{
   public static class NativeInjector
    {
        public static void RegisterServices(this IServiceCollection services)
        {
           
            //Client
            services.AddScoped<UserContext>();
            services.AddScoped<UserEvents>();
            services.AddScoped<UserLoggedEvent>();
            services.AddScoped<IUserRepository, Infra.Client.Repository.UserRepository>();
            services.AddScoped<IUserLoggedRepository, Infra.Client.Repository.UserLoggedRepository>();

            //Chat
            services.AddScoped<ChatContext>();
            services.AddScoped<GroupEvent>();
            services.AddScoped<GroupUserEvent>();
            services.AddScoped<IMessage, Chat.Repository.MessageRepository>();
            services.AddScoped<IGroup, Chat.Repository.GroupRepository>();
            services.AddScoped<IGroupUser, Chat.Repository.GroupUserRepository>();
        }
    }
}
