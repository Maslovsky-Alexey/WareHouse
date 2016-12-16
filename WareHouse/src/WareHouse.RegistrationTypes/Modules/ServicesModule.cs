using Autofac;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Caches;
using WareHouse.Data.EF.Context;
using WareHouse.Data.EF.Repository;
using WareHouse.Data.Model;
using WareHouse.Domain.Service.ConcreteServices;
using WareHouse.Domain.Service.ElasticSearchProviders;
using WareHouse.Domain.Service.ModelsMapper.Configurators;
using WareHouse.Domain.Service.ProxyServices;
using WareHouse.Domain.ServiceInterfaces.Safe;
using WareHouse.Domain.ServiceInterfaces.Unsafe;
using WareHouse.LogHelper;
using WareHouse.PollingEventManager;

namespace WareHouse.RegistrationTypes.Modules
{
    public class ServicesModule : Module
    {
        private string fileLocation = "D:\\Dev2.0\\images";

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<NotificationsService>().As<ISafeNotificationsService>();
            builder.RegisterType<OperationService>();             
            builder.RegisterType<AccountService>();

            RegisterProxyServices(builder);
            RegisterSafeServices(builder);
            RegisterUnsafeServices(builder);
        }

        private void RegisterProxyServices(ContainerBuilder builder)
        {
            builder.Register(context => new ItemProxyService(new ItemService(context.Resolve<BaseRepository<Item>>(), context.Resolve<ItemMapConfigurator>(), fileLocation),
               context.Resolve<ICacheManager>().AddOrGetExistSection("ItemService", context.ResolveKeyed<ICache>("Items"))));

            builder.Register(context => new SupplyProxyService(new SupplyService(context.Resolve<BaseRepository<Supply>>(), context.Resolve<SupplyMapConfigurator>()),
                context.Resolve<ICacheManager>().AddOrGetExistSection("SupplyService", context.ResolveKeyed<ICache>("Supplies"))));

            builder.Register(context => new AccountProxyService(context.Resolve<AccountService>(), null));
        }

        public void RegisterSafeServices(ContainerBuilder builder)
        {
            builder.Register(context => new ClientService(context.Resolve<BaseRepository<Client>>(), context.Resolve<ClientMapConfigurator>())).As<ISafeClientService>();
            builder.Register(context => context.Resolve<ItemProxyService>()).As<ISafeItemService>().OnActivated(h => MyEventStream.MyEventStream.Instance.Subscribe(h.Instance));
            builder.Register(context => new ProviderService(context.Resolve<BaseRepository<Provider>>(), context.Resolve<ProviderMapConfigurator>())).As<ISafeProviderService>();
            builder.Register(context => new EmployeeService(context.Resolve<BaseRepository<Employee>>(), context.Resolve<EmployeeMapConfigurator>())).As<ISafeEmployeeService>();
            builder.Register(context => new ItemStatusService(context.Resolve<BaseRepository<ItemStatus>>(), context.Resolve<ItemStatusMapConfigurator>())).As<ISafeItemStatusService>();
            builder.Register(context => new WarehouseItemService(context.Resolve<BaseRepository<WarehouseItem>>(), context.Resolve<WarehouseItemMapConfigurator>(), context.Resolve<IElasticSearchtemProvider>())).As<ISafeWarehouseItemService>();
            builder.Register(context => new OrderService(context.Resolve<BaseRepository<Order>>(), context.Resolve<OrderMapConfigurator>())).As<ISafeOrderService>();
            builder.Register(context => context.Resolve<SupplyProxyService>()).As<ISafeSupplyService>().OnActivated(h => MyEventStream.MyEventStream.Instance.Subscribe(h.Instance));
            builder.Register(context => context.Resolve<OperationService>()).As<ISafeOperationService>();
            builder.Register(context => context.Resolve<AccountProxyService>()).As<ISafeAccountService>();
        }

        public void RegisterUnsafeServices(ContainerBuilder builder)
        {
            builder.Register(context => new ClientService(context.Resolve<BaseRepository<Client>>(), context.Resolve<ClientMapConfigurator>())).As<IUnsafeClientService>();
            builder.Register(context => new ItemService(context.Resolve<BaseRepository<Item>>(), context.Resolve<ItemMapConfigurator>(), fileLocation)).As<IUnsafeItemService>();
            builder.Register(context => new ProviderService(context.Resolve<BaseRepository<Provider>>(), context.Resolve<ProviderMapConfigurator>())).As<IUnsafeProviderService>();
            builder.Register(context => new EmployeeService(context.Resolve<BaseRepository<Employee>>(), context.Resolve<EmployeeMapConfigurator>())).As<IUnsafeEmployeeService>();
            builder.Register(context => new ItemStatusService(context.Resolve<BaseRepository<ItemStatus>>(), context.Resolve<ItemStatusMapConfigurator>())).As<IUnsafeItemStatusService>();
            builder.Register(context => new WarehouseItemService(context.Resolve<BaseRepository<WarehouseItem>>(), context.Resolve<WarehouseItemMapConfigurator>(), context.Resolve<IElasticSearchtemProvider>())).As<IUnsafeWarehouseItemService>();
            builder.Register(context => new OrderService(context.Resolve<BaseRepository<Order>>(), context.Resolve<OrderMapConfigurator>())).As<IUnsafeOrderService>();
            builder.Register(context => new SupplyService(context.Resolve<BaseRepository<Supply>>(), context.Resolve<SupplyMapConfigurator>())).As<IUnsafeSupplyService>();
            builder.RegisterType<OperationService>().As<IUnsafeOperationService>();
            builder.RegisterType<AccountService>().As<IUnsafeAccountService>();
        }
    }
}
