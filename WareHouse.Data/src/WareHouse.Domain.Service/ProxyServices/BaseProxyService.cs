using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Data.Model;
using WareHouse.Domain.Service.ProxyServices.Cache;
using WareHouse.Domain.ServiceInterfaces.Safe;

namespace WareHouse.Domain.Service.ProxyServices
{
    public class BaseProxyService<TServiceModel, TEFModel> : ISafeService<TServiceModel, TEFModel>, IObserver<TServiceModel>
        where TEFModel : BaseModel
        where TServiceModel : Model.BaseModel
    {
        protected ISafeService<TServiceModel, TEFModel> safeService;
        protected ICache cache;

        public BaseProxyService(ISafeService<TServiceModel, TEFModel> safeService, ICache cache)
        {
            this.safeService = safeService;
            this.cache = cache;
        }

        public async Task<int> Count()
        {
            return await safeService.Count();
        }

        public async Task<IEnumerable<TServiceModel>> GetAll()
        {
            var items = cache.Get<IEnumerable<TServiceModel>>("all");

            if (items != null)
                return items;

            items = await safeService.GetAll();
            cache.AddOrUpdate("all", items);

            return items;
        }

        public async Task<TServiceModel> GetItem(int id)
        {
            var item = cache.Get<TServiceModel>($"item{id}");

            if (item != null)
                return item;

            item = await safeService.GetItem(id);
            cache.AddOrUpdate($"item{id}", item);

            return item;
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(TServiceModel value)
        {
            cache.Clear();
        }
    }
}
