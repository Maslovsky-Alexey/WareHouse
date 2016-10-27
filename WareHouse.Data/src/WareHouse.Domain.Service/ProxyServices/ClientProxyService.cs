using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using WareHouse.Data.Repository;
using WareHouse.Domain.Model;
using WareHouse.Domain.Model.ViewModel;
using WareHouse.Domain.Service.ConcreteServices;
using WareHouse.Domain.Service.ProxyServices.Cache;
using WareHouse.Domain.ServiceInterfaces;
using WareHouse.Domain.ServiceInterfaces.Safe;

namespace WareHouse.Domain.Service.ProxyServices
{
    public class ClientProxyService : BaseProxyService<Client, Data.Model.Client>, ISafeClientService
    {
        private ISafeClientService safeClientService;

        public ClientProxyService(ISafeService<Model.Client, Data.Model.Client> safeService, ICache cache) : base(safeService, cache)
        {
            this.safeClientService = (ISafeClientService)safeService;
        }

        public async Task<Client> GetClientByIdentityId(string identityId)
        {
            var client = (Client)cache.Get($"id{identityId}");

            if (client != null)
                return client;

            client = await safeClientService.GetClientByIdentityId(identityId);
            cache.AddOrUpdate($"id{identityId}", client);
            return client;
        }

        public async Task<Client> GetClientByName(string name, bool ignoreCase)
        {
            var client = (Client)cache.Get($"name{name}");

            if (client != null)
                return client;

            client = await safeClientService.GetClientByName(name, ignoreCase);
            cache.AddOrUpdate($"name{name}", client);
            return client;
        }
    }
}
