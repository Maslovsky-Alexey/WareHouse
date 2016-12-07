using System.Collections.Generic;
using System.Threading.Tasks;
using WareHouse.Data.Model;
using WareHouse.Domain.ServiceInterfaces.Safe;

namespace WareHouse.Domain.Service.ProxyServices
{
    public class ItemStatusProxyService : ISafeItemStatusService
    {
        private ISafeItemStatusService safeItemStatusService;


        public ItemStatusProxyService(ISafeItemStatusService safeItemStatusService)
        {
            this.safeItemStatusService = safeItemStatusService;
        }


        public async Task<int> Count()
        {
            return await safeItemStatusService.Count();
        }

        public async Task<IEnumerable<Model.ItemStatus>> GetAll()
        {
            return await safeItemStatusService.GetAll();
        }

        public async Task<Model.ItemStatus> GetItem(int id)
        {
            return await safeItemStatusService.GetItem(id);
        }

        public async Task<Model.ItemStatus> GetStatus(Status status)
        {
            return await safeItemStatusService.GetStatus(status);
        }
    }
}
