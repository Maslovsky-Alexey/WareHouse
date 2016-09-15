using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Data.EF.Repository;
using WareHouse.Data.Repository;
using WareHouse.Domain.ServiceInterfaces;

namespace WareHouse.Domain.Service.ConcreteServices
{
    public class BaseService<ServiceModel, EFModel> : IService<ServiceModel, EFModel>
        where EFModel : Data.Model.BaseModel
        where ServiceModel : Domain.Model.BaseModel
    {
        protected BaseRepository<EFModel> repository;

        public BaseService(BaseRepository<EFModel> repository)
        {
            this.repository = repository;
        }

        public async Task<IEnumerable<ServiceModel>> GetAll()
        {
            return (await repository.GetAll()).Select(m => MapToServiceModel(m));
        }

        public async Task Add(ServiceModel item)
        {
            await repository.Add(MapToEFModel(item));
        }

        public async Task Remove(ServiceModel item)
        {
            await repository.Remove(MapToEFModel(item));
        }

        public async Task<ServiceModel> GetItem(int id)
        {
            return MapToServiceModel(await repository.GetItem(id));
        }

        public async Task<int> Count()
        {
            return await repository.Count();
        }

        public async Task SaveChanges()
        {
            await repository.SaveChanges();
        }

        protected virtual EFModel MapToEFModel(ServiceModel model)
        {
            return null;
        }

        protected virtual ServiceModel MapToServiceModel(EFModel model)
        {
            return null;
        }
    }
}
