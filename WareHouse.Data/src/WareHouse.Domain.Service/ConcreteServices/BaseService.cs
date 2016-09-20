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
            return (await repository.GetAll()).Select(MapToServiceModel);
        }

        public IEnumerable<ServiceModel> GetAllSync()
        {
            return repository.GetAllSync().Select(MapToServiceModel);
            ;
        }

        //TODO: Операции изменения данных должны возвращать статус выполнения операции, не всегда они завершабтся успешно. Операция создания должна еще возвращать идентификатор новой записи.
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

        //TODO: Эта операция не нужна на уровне сервиса, не нужно отдавать контроль над транзакцией вызывающему коду, каждая операция изменения в сервисе должна быть атомарной для вызывающего кода.
        public async Task SaveChanges()
        {
            await repository.SaveChanges();
        }


        //TODO: Когда будет сделан обобщенный класс для маппинка, то эту логику можно будет реализовать прямо здесь
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