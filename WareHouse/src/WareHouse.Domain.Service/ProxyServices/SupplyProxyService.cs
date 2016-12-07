using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using WareHouse.Domain.Model;
using WareHouse.Domain.Model.ViewModel;
using WareHouse.Domain.ServiceInterfaces.Safe;
using WareHouse.Caches;

namespace WareHouse.Domain.Service.ProxyServices
{
    public class SupplyProxyService : BaseProxyService<Supply, Data.Model.Supply>, ISafeSupplyService
    {
        private ISafeSupplyService safeSupplyService;

        public SupplyProxyService(ISafeService<Model.Supply, Data.Model.Supply> safeService, ICache cache) : base(safeService, cache)
        {
            this.safeSupplyService = (ISafeSupplyService)safeService;
            cache.Clear();
        }

        public async Task<IEnumerable<SupplyViewModel>> GetAllAsViewModel()
        {
            var items = cache.Get<IEnumerable<SupplyViewModel>>($"all");

            if (items != null)
                return items;


            items = await safeSupplyService.GetAllAsViewModel();
            cache.AddOrUpdate($"all", items);
            return items;
        }


        public async Task<IEnumerable<SupplyViewModel>> GetProviderSupplies(string providerName)
        {
            var items = cache.Get<IEnumerable<SupplyViewModel>>($"all{providerName}");

            if (items != null)
                return items;


            items = await safeSupplyService.GetProviderSupplies(providerName);
            cache.AddOrUpdate($"all{providerName}", items);
            return items;
        }
    }
}
