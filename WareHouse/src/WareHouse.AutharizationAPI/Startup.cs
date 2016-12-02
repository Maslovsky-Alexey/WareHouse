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
using Microsoft.AspNetCore.Mvc;
using WareHouse.AutharizationAPI.SocialNetworks.SocialAPI;
using WareHouse.AutharizationAPI.SocialNetworks.Interfaces;
using System.Reflection;
using Novell.Directory.Ldap;
using WareHouse.AutharizationAPI.RolesMapper.Models;
using WareHouse.AutharizationAPI.RolesMapper;
using WareHouse.AutharizationAPI.LdapHelper;
using WareHouse.HttpWebHelperLibrary;
using WareHouse.LogHelper;

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

            LdapHelper.LdapHelper ldap = new LdapHelper.LdapHelper(
                Configuration.GetValue<string>("LdapSettings", "baseSearchCatalog"),
                Configuration.GetValue<string>("LdapSettings", "admin", "nickname"),
                Configuration.GetValue<string>("LdapSettings", "admin", "password"),
                Configuration.GetValue<string>("LdapSettings", "hostname"),
                Configuration.GetValue<int>("LdapSettings", "port")
            );

            var adRoles = Configuration.GetValueFromJSON<IEnumerable<LdapConfigurationRole>>("LdapSettings", "rolesMapping");

            var faceboookAppId = GetSocialApiId("facebook");
            var facebookAppSecret = GetSocialApiSecret("facebook");

            var vkAppId = GetSocialApiId("vk");
            var vkAppSecret = GetSocialApiSecret("vk");

            containerBuilder.Register(context => { return new UsersContext(builder.Options); })
                .InstancePerDependency();

            containerBuilder.RegisterType<PasswordGenerators.PasswordGenerator>().As<PasswordGenerators.IPasswordGenerator>();

            containerBuilder.Register(c => TokenEncryptor.Instance).As<IEncryptor>().SingleInstance();
            containerBuilder.RegisterType<ApplicationUserRepository>().As<IApplicationUserRepository>();

            containerBuilder.RegisterType<FacebookAPI>().Keyed<ISocialAPI>("facebook")
                .WithParameter("appId", faceboookAppId)
                .WithParameter("appSecret", facebookAppSecret);

            containerBuilder.RegisterType<VkAPI>().Keyed<ISocialAPI>("vk")
                .WithParameter("appId", vkAppId)
                .WithParameter("appSecret", vkAppSecret);

            containerBuilder.RegisterType<ConsoleLog>().As<ILog>();
            containerBuilder.RegisterType<WebRequestHelper>().As<IWebRequestHelper>();
     
            containerBuilder.RegisterType<SocialAPIVkRepository>().As<ISocialAPIRepositoryVk>().WithParameter(
                (ParameterInfo info, IComponentContext ctx) => info.Name == "socialAPI", 
                (ParameterInfo info, IComponentContext ctx) => ctx.ResolveKeyed<ISocialAPI>("vk"));

            containerBuilder.RegisterType<SocialAPIFacebookRepository>().As<ISocialAPIRepositoryFacebook>().WithParameter(
                (ParameterInfo info, IComponentContext ctx) => info.Name == "socialAPI",
                (ParameterInfo info, IComponentContext ctx) => ctx.ResolveKeyed<ISocialAPI>("facebook"));

            containerBuilder.RegisterType<RolesMapper.RolesMapper>().As<IRolesMapper>().WithParameter(
                (ParameterInfo info, IComponentContext ctx) => info.GetType() == typeof(IEnumerable<LdapConfigurationRole>),
                (ParameterInfo info, IComponentContext ctx) => adRoles);

            containerBuilder.Register(ctx => ldap).As<ILdapHelper>();
            containerBuilder.RegisterType<LdapRepository>().As<ILdapRepository>();

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

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

        private string GetSocialApiId(string provider)
        {          
            return Configuration.GetValue<string>("SocialAPI", provider, "id");
        }

        private string GetSocialApiSecret(string provider)
        {
            return Configuration.GetValue<string>("SocialAPI", provider, "secret");
        }
    }
}
