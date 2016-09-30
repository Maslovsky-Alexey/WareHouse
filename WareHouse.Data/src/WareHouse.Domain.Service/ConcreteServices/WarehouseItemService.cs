﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Data.EF.Repository;
using WareHouse.Data.Repository;
using WareHouse.Domain.Model;
using WareHouse.Domain.Model.ViewModel;
using WareHouse.Domain.Service.ModelsMapper;
using WareHouse.Domain.Service.ModelsMapper.Configurators;
using WareHouse.Domain.ServiceInterfaces;

namespace WareHouse.Domain.Service.ConcreteServices
{
    public class WarehouseItemService : BaseService<Domain.Model.WarehouseItem, Data.Model.WarehouseItem>, IWarehouseItemService
    {
        IWarehouseItemRepository warehouseItemRepository;

        public WarehouseItemService(BaseRepository<Data.Model.WarehouseItem> repository) : base(repository, 
            new ModelsMapper<Data.Model.WarehouseItem, Domain.Model.WarehouseItem>(new WarehouseItemMapConfigurator()))
        {
            warehouseItemRepository = (IWarehouseItemRepository)repository;
        }

        public async Task AddOrUpdateAsViewModel(WarehouseItemViewModel model)
        {
            var item = (await GetItemsByName(model.Name, true)).FirstOrDefault(x => x.Status.Id == model.StatusId);

            if (item != null)
            {
                item.Item.Count = model.Count;
            }
            else
            {
                item = new WarehouseItem();
                item.Item = new Item { Name = model.Name };
                item.Count = model.Count;
                item.Status = new ItemStatus { Id = model.StatusId, Name = model.Status };

                await Add(item);
            }
        }

        public async Task<IEnumerable<WarehouseItemViewModel>> GetAllAsViewModel()
        {
            return (await ((WarehouseItemRepository)repository).GetAll()).Select(item => new WarehouseItemViewModel
            {
                ItemId = item.Item.Id,
                Name = item.Item.Name,
                Count = item.Count,
                Status = item.Status.Name,
                StatusId = item.Status.Id
            });
        }

        public async Task<IEnumerable<WarehouseItem>> GetItemsByName(string name, bool ignoreCase)
        {
            return (await((WarehouseItemRepository)repository).GetItemsByName(name, ignoreCase)).Select(item => MapToServiceModel(item));
        }

        public async Task UpdateStatus(int itemId, int itemStatusId)
        {
            await warehouseItemRepository.UpdateStatus(itemId, itemStatusId);
        }
    }
}
