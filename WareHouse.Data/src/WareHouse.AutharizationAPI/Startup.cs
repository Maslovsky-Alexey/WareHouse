using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WareHouse.AutharizationAPI.Context.Models;
using WareHouse.AutharizationAPI.Context;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Autofac;
using Microsoft.EntityFrameworkCore;
using WareHouse.AutharizationAPI.Repositories.Interfaces;
using WareHouse.AutharizationAPI.Repositories;
using Autofac.Extensions.DependencyInjection;

namespace WareHouse.AutharizationAPI
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsEnvironment("Development"))
            {
                builder.AddApplicationInsightsSettings(developerMode: true);
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }
        public IContainer ApplicationContainer { get; private set; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<UsersContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 5;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = false;
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin",
                    builder => builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials()
                        .WithExposedHeaders("Authorization"));
            });

            services.AddApplicationInsightsTelemetry(Configuration);

            services.AddMvc();

            var containerBuilder = new ContainerBuilder();

            RegistrTypes(containerBuilder);

            containerBuilder.Populate(services);
            ApplicationContainer = containerBuilder.Build();

            var tokenEncryptor = ApplicationContainer.Resolve<IEncryptor>();

            tokenEncryptor.Key = Configuration.GetSection("Encrypt").GetValue<string>("Key");
            tokenEncryptor.VI = Configuration.GetSection("Encrypt").GetValue<string>("VI");

            return new AutofacServiceProvider(ApplicationContainer);
        }

        private void RegistrTypes(ContainerBuilder containerBuilder)
        {
            var connection = Configuration.GetConnectionString("DefaultConnection");
            var builder = new DbContextOptionsBuilder<UsersContext>().UseSqlServer(connection);

            containerBuilder.Register(context => { return new UsersContext(builder.Options); })
                .InstancePerDependency();

            containerBuilder.Register(c => TokenEncryptor.Instance).As<IEncryptor>().SingleInstance();
            containerBuilder.RegisterType<ApplicationUserRepository>().As<IApplicationUserRepository>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseCors("AllowSpecificOrigin");

            app.UseApplicationInsightsRequestTelemetry();
            if (env.IsDevelopment())
            {
               // app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                //app.UseExceptionHandler("/Home/Error");
            }
            app.UseApplicationInsightsExceptionTelemetry();
            app.UseStaticFiles();
            app.UseIdentity();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });


        }
    }
}
