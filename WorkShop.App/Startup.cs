using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.Results;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;
using WorkShop.Domain.Chat.DTO;
using WorkShop.Domain.Chat.Event;
using WorkShop.Domain.Client.DTO;
using WorkShop.IO.Infra.CrossCutting;
using WorkShop.IO.Infra.CrossCutting.Client;

namespace WorkShop.App
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddCors(options =>
            {
                options.AddPolicy("Front",
                policy => policy.WithOrigins("http://localhost:4200")
                .WithMethods("*")
                .WithHeaders("*")
                );
            });

            services.RegisterServices();
            services.ConfigureServices(Configuration);
            services.AddSignalR();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
            .AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver());;
        
          
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            // Enable Cors
            app.UseCors("Front");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseSignalR(routes =>
            {
                routes.MapHub<NotifyHub>("/notify");
            });
            app.UseMvc();

           
            var task = app.Configure(Configuration);
            task.Wait();
        }
    }
}
