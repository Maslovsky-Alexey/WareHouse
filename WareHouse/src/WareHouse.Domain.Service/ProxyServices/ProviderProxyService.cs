using System.Collections.Generic;
using System.Threading.Tasks;
using WareHouse.Domain.Model;
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
