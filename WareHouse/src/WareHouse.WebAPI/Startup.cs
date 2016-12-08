using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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
using WareHouse.Caches;

using WareHouse.Domain.Service.ModelsMapper.Configurators;
using WareHouse.LogHelper;
using WareHouse.MyEventStream;
using Autofac.Core;
using WareHouse.Domain.Service.ElasticSearchProviders;
using WareHouse.MyOData;
using WareHouse.HttpWebHelperLibrary;
using WareHouse.AuthAPIHelper;
using FluentValidation.AspNetCore;
using WareHouse.Domain.Model.ViewModel.ModelValidators;
using WareHouse.Data.SQL.Repository;
using WareHouse.PollingEventManager;
using System.Reflection;

namespace WareHouse.WebAPI
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
            var connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<WareHouseDbContext>(options => options.UseSqlServer(connection));

            var dboptions = new DbContextOptionsBuilder<WareHouseDbContext>().Options;

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

            services
                .AddMvc(options => { options.ModelBinderProviders.Insert(0, new ODataModelBinderProvider()); })
                .AddFluentValidation(ft => {
                    ft.RegisterValidatorsFromAssemblyContaining<Startup>();
                    ft.ValidatorFactoryType = typeof(ValidationFactory);
                });

            var containerBuilder = new ContainerBuilder();

            RegistrTypes(containerBuilder, dboptions);

            
            containerBuilder.Populate(services);
            ApplicationContainer = containerBuilder.Build();
            ApplicationContainer.ResolveKeyed<ILog>("SignIn");

            MyEventStream.MyEventStream.Instance.Subscribe(ApplicationContainer.Resolve<IPollingEventManager>());

            // Create the IServiceProvider based on the container.
            return new AutofacServiceProvider(ApplicationContainer);
        }

        private void RegistrTypes(ContainerBuilder containerBuilder, DbContextOptions<WareHouseDbContext> options)
        {
            var redisUrl = "localhost:6379";

            containerBuilder.Register(context => { return new WareHouseDbContext(options); })
                .InstancePerDependency();

            containerBuilder.Register(c => CacheManager.Instance).As<ICacheManager>().SingleInstance();

            containerBuilder.RegisterType<RedisCache>()
                .WithParameter("url", redisUrl)
                .WithParameter("dbIndex", 1)
                .Keyed<ICache>("Items");

            containerBuilder.RegisterType<RedisCache>()
                .WithParameter("url", redisUrl)
                .WithParameter("dbIndex", 2)
                .Keyed<ICache>("Orders");

            containerBuilder.RegisterType<RedisCache>()
                .WithParameter("url", redisUrl)
                .WithParameter("dbIndex", 3)
                .Keyed<ICache>("Supplies");

            containerBuilder.RegisterType<RedisCache>()
                .WithParameter("url", redisUrl)
                .WithParameter("dbIndex", 4)
                .Keyed<ICache>("PollingEventManager");

            containerBuilder.Register(context => PollingEventManager.PollingEventManager.Instance(context.ResolveKeyed<ICache>("PollingEventManager"))).As<IPollingEventManager>();

            containerBuilder.RegisterType<NotificationsService>().As<ISafeNotificationsService>();

            containerBuilder.Register(c => FileLog<WareHouse.Domain.Model.ViewModel.SignInLogModel>.Instance("d:\\log.txt")).Keyed<ILog>("SignIn").SingleInstance().OnActivated(h => MyEventStream.MyEventStream.Instance.Subscribe(h.Instance));
            containerBuilder.RegisterType<ConsoleLog>().As<ILog>();

            containerBuilder.RegisterType<WebRequestHelper>().As<IWebRequestHelper>();

            containerBuilder.RegisterType<ClientMapConfigurator>();
            containerBuilder.RegisterType<EmployeeMapConfigurator>();
            containerBuilder.RegisterType<ItemMapConfigurator>();
            containerBuilder.RegisterType<ItemStatusMapConfigurator>();
            containerBuilder.RegisterType<OrderMapConfigurator>();
            containerBuilder.RegisterType<SupplyMapConfigurator>();
            containerBuilder.RegisterType<WarehouseItemMapConfigurator>();
            containerBuilder.RegisterType<ProviderMapConfigurator>();

            containerBuilder.RegisterType<ElasticSearchProvider>().As<IElasticSearchtemProvider>();

            containerBuilder.RegisterType<ClientRepository>().As<BaseRepository<Client>>();
            containerBuilder.Register(context => new ClientService(context.Resolve<BaseRepository<Client>>(), context.Resolve<ClientMapConfigurator>())).As<IUnsafeClientService>();
            containerBuilder.Register(context => new ClientService(context.Resolve<BaseRepository<Client>>(), context.Resolve<ClientMapConfigurator>())).As<ISafeClientService>();

            containerBuilder.RegisterType<ItemRepository>().As<BaseRepository<Item>>();
            containerBuilder.Register(context => new ItemService(context.Resolve<BaseRepository<Item>>(), context.Resolve<ItemMapConfigurator>())).As<IUnsafeItemService>();
            containerBuilder.Register(context => new ItemProxyService(new ItemService(context.Resolve<BaseRepository<Item>>(), context.Resolve<ItemMapConfigurator>()), 
                context.Resolve<ICacheManager>().AddOrGetExistSection("ItemService", context.ResolveKeyed<ICache>("Items"))));
            containerBuilder.Register(context => context.Resolve<ItemProxyService>()).As<ISafeItemService>().OnActivated(h => MyEventStream.MyEventStream.Instance.Subscribe(h.Instance));

            containerBuilder.RegisterType<ProviderRepository>().As<BaseRepository<Provider>>();
            containerBuilder.Register(context => new ProviderService(context.Resolve<BaseRepository<Provider>>(), context.Resolve<ProviderMapConfigurator>())).As<IUnsafeProviderService>();
            containerBuilder.Register(context => new ProviderService(context.Resolve<BaseRepository<Provider>>(), context.Resolve<ProviderMapConfigurator>())).As<ISafeProviderService>();

            containerBuilder.RegisterType<EmployeeRepository>().As<BaseRepository<Employee>>();
            containerBuilder.Register(context => new EmployeeService(context.Resolve<BaseRepository<Employee>>(), context.Resolve<EmployeeMapConfigurator>())).As<IUnsafeEmployeeService>();
            containerBuilder.Register(context => new EmployeeService(context.Resolve<BaseRepository<Employee>>(), context.Resolve<EmployeeMapConfigurator>())).As<ISafeEmployeeService>();

            containerBuilder.RegisterType<ItemStatusRepository>().As<BaseRepository<ItemStatus>>();
            containerBuilder.Register(context => new ItemStatusService(context.Resolve<BaseRepository<ItemStatus>>(), context.Resolve<ItemStatusMapConfigurator>())).As<IUnsafeItemStatusService>();
            containerBuilder.Register(context => new ItemStatusService(context.Resolve<BaseRepository<ItemStatus>>(), context.Resolve<ItemStatusMapConfigurator>())).As<ISafeItemStatusService>();

            containerBuilder.RegisterType<WarehouseItemSQLRepository>().As<BaseRepository<WarehouseItem>>();
            containerBuilder.Register(context => new WarehouseItemService(context.Resolve<BaseRepository<WarehouseItem>>(), context.Resolve<WarehouseItemMapConfigurator>(), context.Resolve<IElasticSearchtemProvider>())).As<IUnsafeWarehouseItemService>();
            containerBuilder.Register(context => new WarehouseItemService(context.Resolve<BaseRepository<WarehouseItem>>(), context.Resolve<WarehouseItemMapConfigurator>(), context.Resolve<IElasticSearchtemProvider>())).As<ISafeWarehouseItemService>();

            containerBuilder.RegisterType<OrderRepository>().As<BaseRepository<Order>>();
            containerBuilder.Register(context => new OrderService(context.Resolve<BaseRepository<Order>>(), context.Resolve<OrderMapConfigurator>())).As<IUnsafeOrderService>();
            containerBuilder.Register(context => new OrderService(context.Resolve<BaseRepository<Order>>(), context.Resolve<OrderMapConfigurator>())).As<ISafeOrderService>();


            containerBuilder.RegisterType<SupplyRepository>().As<BaseRepository<Supply>>();
            containerBuilder.Register(context => new SupplyService(context.Resolve<BaseRepository<Supply>>(), context.Resolve<SupplyMapConfigurator>())).As<IUnsafeSupplyService>();
            containerBuilder.Register(context => new SupplyProxyService(new SupplyService(context.Resolve<BaseRepository<Supply>>(), context.Resolve<SupplyMapConfigurator>()),
                context.Resolve<ICacheManager>().AddOrGetExistSection("SupplyService", context.ResolveKeyed<ICache>("Supplies"))));
            containerBuilder.Register(context => context.Resolve<SupplyProxyService>()).As<ISafeSupplyService>().OnActivated(h => MyEventStream.MyEventStream.Instance.Subscribe(h.Instance));


            containerBuilder.RegisterType<OperationService>().As<IUnsafeOperationService>();
            containerBuilder.RegisterType<OperationService>();
            containerBuilder.Register(context => context.Resolve<OperationService>()).As<ISafeOperationService>();

            containerBuilder.RegisterType<AuthHelper>().As<IAuthHelper>().WithParameter("autharizationApiUrl", "http://localhost:11492");
            containerBuilder.RegisterType<AccountService>().As<IUnsafeAccountService>();
            containerBuilder.RegisterType<AccountService>();           
            containerBuilder.Register(context => new AccountProxyService(context.Resolve<AccountService>(), null));
            containerBuilder.Register(context => context.Resolve<AccountProxyService>()).As<ISafeAccountService>();
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