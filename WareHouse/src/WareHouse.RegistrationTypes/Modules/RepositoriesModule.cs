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
using WareHouse.Data.SQL.Repository;
using WareHouse.LogHelper;
using WareHouse.PollingEventManager;

namespace WareHouse.RegistrationTypes.Modules
{
    public class RepositoriesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ClientRepository>().As<BaseRepository<Client>>();
            builder.RegisterType<ItemRepository>().As<BaseRepository<Item>>();
            builder.RegisterType<ProviderRepository>().As<BaseRepository<Provider>>();
            builder.RegisterType<EmployeeRepository>().As<BaseRepository<Employee>>();
            builder.RegisterType<ItemStatusRepository>().As<BaseRepository<ItemStatus>>();
            builder.RegisterType<WarehouseItemSQLRepository>().As<BaseRepository<WarehouseItem>>();
            builder.RegisterType<OrderRepository>().As<BaseRepository<Order>>();
            builder.RegisterType<SupplyRepository>().As<BaseRepository<Supply>>();
        }
    }
}
