using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using WareHouse.Data.EF.Context;
using Autofac;
using WareHouse.Domain.Service.ConcreteServices;
using WareHouse.Domain.ServiceInterfaces;
using Autofac.Extensions.DependencyInjection;
using Autofac.Core;
using WareHouse.Data.EF.Repository;
using WareHouse.Data.Repository;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using WareHouse.Data.Model;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();

            if (env.IsDevelopment())
            {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }
        public IContainer ApplicationContainer { get; private set; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            // TODO: Вынести в конфигурацию
            //    var connection = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=WareHouse;uid=Admin;password=123123;";    
            var connection = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=WareHouse.Data.EF.Context.WarehouseDbContext;Integrated Security=True";


            services.AddDbContext<WareHouseDbContext>(options => options.UseSqlServer(connection));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<WareHouseDbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredLength = 5;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = false;
            });

            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);

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

            services.AddMvc();

            var containerBuilder = new ContainerBuilder();

            RegistrTypes(containerBuilder);

            containerBuilder.Populate(services);
            this.ApplicationContainer = containerBuilder.Build();

            // Create the IServiceProvider based on the container.
            return new AutofacServiceProvider(this.ApplicationContainer);
        }

        private void RegistrTypes(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<ClientRepository>().As<BaseRepository<WareHouse.Data.Model.Client>>();
            containerBuilder.RegisterType<ClientService>().As<IClientService>();

            containerBuilder.RegisterType<ItemRepository>().As<BaseRepository<WareHouse.Data.Model.Item>>();
            containerBuilder.RegisterType<ItemService>().As<IItemService>();

            containerBuilder.RegisterType<ProviderRepository>().As<BaseRepository<WareHouse.Data.Model.Provider>>();
            containerBuilder.RegisterType<ProviderService>().As<IProviderService>();

            containerBuilder.RegisterType<EmployeeRepository>().As<BaseRepository<WareHouse.Data.Model.Employee>>();
            containerBuilder.RegisterType<EmployeeService>().As<IEmployeeService>();

            containerBuilder.RegisterType<ItemStatusRepository>().As<BaseRepository<WareHouse.Data.Model.ItemStatus>>();
            containerBuilder.RegisterType<ItemStatusService>().As<IItemStatusService>();

            containerBuilder.RegisterType<WarehouseItemRepository>().As<BaseRepository<WareHouse.Data.Model.WarehouseItem>>();
            containerBuilder.RegisterType<WarehouseItemService>().As<IWarehouseItemService>();

            containerBuilder.RegisterType<UserRepository>().As<IUserRepository>();
            containerBuilder.RegisterType<UserService>().As<IUserService>();

            containerBuilder.RegisterType<OperationService>().As<IOperationService>();
            containerBuilder.RegisterType<AccountService>().As<IAccountService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseApplicationInsightsRequestTelemetry();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseCors("AllowSpecificOrigin");

            app.UseApplicationInsightsExceptionTelemetry();

            app.UseStaticFiles();

            app.UseIdentity();

            app.UseMiddleware<AuthenticationMddleware>();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
