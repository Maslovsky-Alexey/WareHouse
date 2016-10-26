using System.Threading.Tasks;
using WareHouse.Data.EF.Repository;
using WareHouse.Domain.Model;
using WareHouse.Domain.Service.ModelsMapper;
using WareHouse.Domain.Service.ModelsMapper.Configurators;
using WareHouse.Domain.ServiceInterfaces;
using System.Reactive.Subjects;
using System;
using System.Collections.Generic;

namespace WareHouse.Domain.Service.ConcreteServices
{
    public class ItemService : BaseService<Item, Data.Model.Item>, IItemService, IObservable<Item>
    {
        private List<IObserver<Item>> subscribers = new List<IObserver<Item>>();

        public ItemService(BaseRepository<Data.Model.Item> repository) : base(repository,
            new ModelsMapper<Data.Model.Item, Item>(new ItemMapConfigurator()))
        {
        }

        public async Task AddWithoutRepetition(Item model)
        {
            var item = await GetItemByName(model.Name, true);

            if (item != null)
                return;

            if (await Add(model) == Data.Repository.OperationStatus.Added)
                OnNext(model);
        }

        public async Task<Item> GetItemByName(string name, bool ignoreCase)
        {
            return MapToServiceModel(await ((ItemRepository) repository).GetItemByName(name, ignoreCase));
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(Item value)
        {
            subscribers.ForEach(subscriber => subscriber.OnNext(value));
        }

        public IDisposable Subscribe(IObserver<Item> observer)
        {
            subscribers.Add(observer);
            return null;
        }
    }
}