using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ShoppingCart.Core.Interface;
using ShoppingCart.Data;
using ShoppingCart.Services;

namespace ShoppingCart.API
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Registering services for Db Context
            services.AddDbContext<ShoppingDbContext>(options => options.UseSqlServer
                (_configuration.GetConnectionString("DefaultConnection")));

            //Registering services for Identity framework
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ShoppingDbContext>().AddDefaultTokenProviders();

            //Registering custom services
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IAuthenticationRepository, AuthenticationRepository>();

            //Registering services for MVC
            services.AddMvc();

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            //Setting up the configuration class
            //var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            //Configuration = builder.Build();


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            //adding MVC in pipeline with default route
            app.UseMvcWithDefaultRoute();

            //This will run last if none of the middlewares are able to handle the request
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }

        //private IConfigurationRoot Configuration { get; set; }
    }
}
