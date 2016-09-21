using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using WareHouse.Data.EF.Repository;
using WareHouse.Data.Repository;
using WareHouse.Domain.Service.ModelsMapper;
using WareHouse.Domain.ServiceInterfaces;

namespace WareHouse.Domain.Service.ConcreteServices
{ 


    public class BaseService<ServiceModel, EFModel> : IService<ServiceModel, EFModel>
        where EFModel : Data.Model.BaseModel
        where ServiceModel : Domain.Model.BaseModel
    {
        protected BaseRepository<EFModel> repository;
        private ModelsMapper<EFModel, ServiceModel> mapper;


        public BaseService(BaseRepository<EFModel> repository, ModelsMapper<EFModel, ServiceModel> mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<ServiceModel>> GetAll()
        {
            return (await repository.GetAll()).Select(MapToServiceModel);
        }

        public IEnumerable<ServiceModel> GetAllSync()
        {
            return repository.GetAllSync().Select(MapToServiceModel);
        }
        
        public async Task<OperationStatus> Add(ServiceModel item)
        {
            return await repository.Add(MapToEFModel(item));
        }

        public async Task<OperationStatus> Remove(ServiceModel item)
        {
            return await repository.Remove(MapToEFModel(item));
        }

        public async Task<ServiceModel> GetItem(int id)
        {
            return MapToServiceModel(await repository.GetItem(id));
        }

        public async Task<int> Count()
        {
            return await repository.Count();
        }

        protected EFModel MapToEFModel(ServiceModel model)
        {
            return mapper.MapEF(model);
        }

        protected ServiceModel MapToServiceModel(EFModel model)
        {
            return mapper.MapService(model);
        }
    }
}