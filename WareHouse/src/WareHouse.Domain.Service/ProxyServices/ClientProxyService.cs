using System.Threading.Tasks;
using WareHouse.Domain.Model;
using WareHouse.Caches;
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
            var client = cache.Get<Client>($"id{identityId}");

            if (client != null)
                return client;

            client = await safeClientService.GetClientByIdentityId(identityId);
            cache.AddOrUpdate($"id{identityId}", client);
            return client;
        }

        public async Task<Client> GetClientByName(string name, bool ignoreCase)
        {
            var client = cache.Get<Client>($"name{name}");

            if (client != null)
                return client;

            client = await safeClientService.GetClientByName(name, ignoreCase);
            cache.AddOrUpdate($"name{name}", client);
            return client;
        }
    }
}
