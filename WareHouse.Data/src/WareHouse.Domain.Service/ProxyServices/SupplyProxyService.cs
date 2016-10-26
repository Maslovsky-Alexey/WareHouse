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
    public class SupplyProxyService : ISafeSupplyService
    {
        private ISafeSupplyService safeSupplyService;


        public SupplyProxyService(ISafeSupplyService safeSupplyService)
        {
            this.safeSupplyService = safeSupplyService;
        }

        public async Task<int> Count()
        {
            return await safeSupplyService.Count();
        }

        public async Task<IEnumerable<Supply>> GetAll()
        {
            return await safeSupplyService.GetAll();
        }

        public async Task<IEnumerable<SupplyViewModel>> GetAllAsViewModel()
        {
            return await safeSupplyService.GetAllAsViewModel();
        }

        public async Task<Supply> GetItem(int id)
        {
            return await safeSupplyService.GetItem(id);
        }

        public async Task<IEnumerable<SupplyViewModel>> GetProviderSupplies(string providerName)
        {
            return await safeSupplyService.GetProviderSupplies(providerName);
        }
    }
}
