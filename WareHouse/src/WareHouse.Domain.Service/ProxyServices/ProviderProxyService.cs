using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using WareHouse.Data.Repository;
using WareHouse.Domain.Model;
using WareHouse.Domain.Model.ViewModel;
using WareHouse.Domain.Service.ConcreteServices;
using WareHouse.Domain.ServiceInterfaces;
using WareHouse.Domain.ServiceInterfaces.Safe;

namespace WareHouse.Domain.Service.ProxyServices
{
    public class ProviderProxyService : ISafeProviderService
    {
        private ISafeProviderService safeProviderService;


        public ProviderProxyService(ISafeProviderService safeProviderService)
        {
            this.safeProviderService = safeProviderService;
        }


        public async Task<int> Count()
        {
            return await safeProviderService.Count();
        }

        public async Task<IEnumerable<Provider>> GetAll()
        {
            return await safeProviderService.GetAll();
        }

        public async Task<Provider> GetItem(int id)
        {
            return await safeProviderService.GetItem(id);
        }

        public async Task<Provider> GetProviderByName(string name, bool ignoreCase)
        {
            return await safeProviderService.GetProviderByName(name, ignoreCase);
        }

    }
}
