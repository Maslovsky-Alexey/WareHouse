﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Data.EF.Repository;
using WareHouse.Domain.ServiceInterfaces;
using WareHouse.Domain.Service.ModelsMapper;
using WareHouse.Domain.Service.ModelsMapper.Configurators;
using WareHouse.Domain.Model;
using WareHouse.MyOData;
using System.Linq.Expressions;

namespace WareHouse.Domain.Service.ConcreteServices
{
    public class ItemService : BaseService<Domain.Model.Item, Data.Model.Item>, IItemService
    {
        public ItemService(BaseRepository<Data.Model.Item> repository) : base(repository,
            new ModelsMapper<Data.Model.Item, Domain.Model.Item>(new ItemMapConfigurator()))
        {

        }

        public async Task<Model.Item> GetItemByName(string name, bool ignoreCase)
        {
            return MapToServiceModel(await ((ItemRepository)repository).GetItemByName(name, ignoreCase));
        }

        public async Task AddOrUpdateCount(Item value)
        {
            var item = await GetItemByName(value.Name, true);

            if (item != null)
            {
                await ((ItemRepository)repository).UpdateCount(item.Id, value.Count);
            }
            else
            {
                await Add(value);
            }
        }

        public async Task SubCount(Item value)
        {
            var oldItem = (await GetItemByName(value.Name, true));

            if (oldItem == null)
                return;

            var deltaCount = oldItem.Count - value.Count > 0 ? 0 - value.Count : 0;

            if (deltaCount == 0)
                return;

            await ((ItemRepository)repository).UpdateCount(oldItem.Id, deltaCount);
        }

        public async Task RemoveItemByName(Item value)
        {
            var removingItem = await GetItemByName(value.Name, true);

            if (removingItem != null)
                await Remove(await GetItem(removingItem.Id));
        }

        public async Task<PageModel> GetPage(int page, MyODataConfigurates config)
        {
            var a = MyOData.MyOData.CompileFunc<Item>(config);

            var result = new PageModel();
            result.Items = GetAllSync().Where(a)
                .Skip(page * 6)
                .Take(6);

            result.PrevPage = page - 1 < 0 ? 0 : page - 1;

            var maxPage = (await Count() - 1) / 6;
            result.NextPage = page + 1 > maxPage ? maxPage : page + 1;

            return result;
        }
    }
}
