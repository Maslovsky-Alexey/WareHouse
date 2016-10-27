using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using WareHouse.Data.EF.Context;
using WareHouse.Data.EF.Repository;
using WareHouse.Data.Model;
using WareHouse.Data.Repository;
using WareHouse.Domain.Service.ConcreteServices;
using WareHouse.Domain.ServiceInterfaces;
using WareHouse.Domain.Service.ProxyServices;
using WareHouse.Domain.ServiceInterfaces.Unsafe;
using WareHouse.Domain.ServiceInterfaces.Safe;
using WareHouse.Domain.Service.ProxyServices.Cache;
using WebAPI.EventStream;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
                .AddEnvironmentVariables();

            if (env.IsDevelopment())
                builder.AddApplicationInsightsSettings(true);
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }
        public IContainer ApplicationContainer { get; private set; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            //    var connection = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=WareHouse;uid=Admin;password=123123;";    

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

            services.AddMvc(options => { options.ModelBinderProviders.Insert(0, new ODataModelBinderProvider()); });

            var containerBuilder = new ContainerBuilder();

            RegistrTypes(containerBuilder);


            containerBuilder.Populate(services);
            ApplicationContainer = containerBuilder.Build();
            ApplicationContainer.Resolve<LogHelper.ILog>();

            var tokenEncryptor = ApplicationContainer.Resolve<IEncryptor>();

            tokenEncryptor.Key = Configuration.GetSection("Encrypt").GetValue<string>("Key");
            tokenEncryptor.VI = Configuration.GetSection("Encrypt").GetValue<string>("VI");

            // Create the IServiceProvider based on the container.
            return new AutofacServiceProvider(ApplicationContainer);
        }

        private void RegistrTypes(ContainerBuilder containerBuilder)
        {
            var connection = Configuration.GetConnectionString("DefaultConnection");
            var builder = new DbContextOptionsBuilder<WareHouseDbContext>().UseSqlServer(connection);

            containerBuilder.Register(context => { return new WareHouseDbContext(builder.Options); })
                .InstancePerDependency();

            containerBuilder.Register(c => CacheManager.Instance).As<ICacheManager>().SingleInstance();
            containerBuilder.RegisterType<LocalCache>().As<ICache>();

            containerBuilder.Register(c => LogHelper.LogHelper.Instance("d:\\log.txt")).As<LogHelper.ILog>().SingleInstance().OnActivated(h => MyEventStream.Instance.Subscribe(h.Instance));

            containerBuilder.RegisterType<ClientRepository>().As<BaseRepository<Client>>();
            containerBuilder.RegisterType<ClientService>().As<IUnsafeClientService>();
            containerBuilder.Register(context => new ClientService(context.Resolve<BaseRepository<Client>>())).As<ISafeClientService>();

            containerBuilder.RegisterType<ItemRepository>().As<BaseRepository<Item>>();
            containerBuilder.RegisterType<ItemService>().As<IUnsafeItemService>().OnActivated(h => MyEventStream.Instance.Add(h.Instance));
            containerBuilder.Register(context => new ItemProxyService(new ItemService(context.Resolve<BaseRepository<Item>>()), 
                context.Resolve<ICacheManager>().AddOrGetExistSection("ItemService", context.Resolve<ICache>())));
            containerBuilder.Register(context => context.Resolve<ItemProxyService>()).As<ISafeItemService>().OnActivated(h => MyEventStream.Instance.Subscribe(h.Instance));

            containerBuilder.RegisterType<ProviderRepository>().As<BaseRepository<Provider>>();
            containerBuilder.RegisterType<ProviderService>().As<IUnsafeProviderService>();
            containerBuilder.Register(context => new ProviderService(context.Resolve<BaseRepository<Provider>>())).As<ISafeProviderService>();

            containerBuilder.RegisterType<EmployeeRepository>().As<BaseRepository<Employee>>();
            containerBuilder.RegisterType<EmployeeService>().As<IUnsafeEmployeeService>();
            containerBuilder.Register(context => new EmployeeService(context.Resolve<BaseRepository<Employee>>())).As<ISafeEmployeeService>();

            containerBuilder.RegisterType<ItemStatusRepository>().As<BaseRepository<ItemStatus>>();
            containerBuilder.RegisterType<ItemStatusService>().As<IUnsafeItemStatusService>();
            containerBuilder.Register(context => new ItemStatusService(context.Resolve<BaseRepository<ItemStatus>>())).As<ISafeItemStatusService>();

            containerBuilder.RegisterType<WarehouseItemRepository>().As<BaseRepository<WarehouseItem>>();
            containerBuilder.RegisterType<WarehouseItemService>().As<IUnsafeWarehouseItemService>();
            containerBuilder.Register(context => new WarehouseItemService(context.Resolve<BaseRepository<WarehouseItem>>())).As<ISafeWarehouseItemService>();

            containerBuilder.RegisterType<UserRepository>().As<IUserRepository>();
            containerBuilder.RegisterType<UserService>().As<IUnsafeUserService>();
            containerBuilder.Register(context => new UserService(context.Resolve<IUserRepository>())).As<ISafeUserService>();

            containerBuilder.RegisterType<OrderRepository>().As<BaseRepository<Order>>();
            containerBuilder.RegisterType<OrderService>().As<IUnsafeOrderService>().OnActivated(h => MyEventStream.Instance.Add(h.Instance)); ;
            containerBuilder.Register(context => new OrderProxyService(new OrderService(context.Resolve<BaseRepository<Order>>()),
                context.Resolve<ICacheManager>().AddOrGetExistSection("OrderService", context.Resolve<ICache>())));
            containerBuilder.Register(context => context.Resolve<OrderProxyService>()).As<ISafeOrderService>().OnActivated(h => MyEventStream.Instance.Subscribe(h.Instance));


            containerBuilder.RegisterType<SupplyRepository>().As<BaseRepository<Supply>>();
            containerBuilder.RegisterType<SupplyService>().As<IUnsafeSupplyService>().OnActivated(h => MyEventStream.Instance.Add(h.Instance));
            containerBuilder.Register(context => new SupplyProxyService(new SupplyService(context.Resolve<BaseRepository<Supply>>()),
                context.Resolve<ICacheManager>().AddOrGetExistSection("SupplyService", context.Resolve<ICache>())));
            containerBuilder.Register(context => context.Resolve<SupplyProxyService>()).As<ISafeSupplyService>().OnActivated(h => MyEventStream.Instance.Subscribe(h.Instance));


            containerBuilder.RegisterType<OperationService>().As<IUnsafeOperationService>();
            containerBuilder.RegisterType<OperationService>();
            containerBuilder.Register(context => context.Resolve<OperationService>()).As<ISafeOperationService>();

            containerBuilder.RegisterType<AccountService>().As<IUnsafeAccountService>();
            containerBuilder.RegisterType<AccountService>();
            containerBuilder.Register(context => new AccountProxyService(context.Resolve<AccountService>(), null));
            containerBuilder.Register(context => context.Resolve<AccountProxyService>()).As<ISafeAccountService>().OnActivated(h => MyEventStream.Instance.Add(h.Instance));

            containerBuilder.Register(c => TokenEncryptor.Instance).As<IEncryptor>().SingleInstance();
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
                    "default",
                    "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}