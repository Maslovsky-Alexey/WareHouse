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
using WareHouse.LogHelper;
using WareHouse.MyOData;
using FluentValidation.AspNetCore;
using WareHouse.Domain.Model.ViewModel.ModelValidators;
using WareHouse.PollingEventManager;
using System.Reflection;
using WareHouse.RegistrationTypes.Modules;
using System.Linq;

namespace WareHouse.WebAPI
{
    public partial class Startup
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

            RegistrTypes(containerBuilder);

            containerBuilder.Populate(services);
            ApplicationContainer = containerBuilder.Build();
            ApplicationContainer.ResolveKeyed<ILog>("SignIn");

            MyEventStream.MyEventStream.Instance.Subscribe(ApplicationContainer.Resolve<IPollingEventManager>());

            // Create the IServiceProvider based on the container.
            return new AutofacServiceProvider(ApplicationContainer);
        }

        private void RegistrTypes(ContainerBuilder containerBuilder)
        {          
            typeof(EFModule)
                .GetTypeInfo()
                .Assembly
                .GetTypes()
                .Select(x => x.GetTypeInfo())
                .Where(x => x.IsClass && !x.IsAbstract && x.IsSubclassOf(typeof(Autofac.Module)))
                .ToList()
                .ForEach(x => containerBuilder.RegisterModule((Autofac.Module)Activator.CreateInstance(x.AsType())));
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