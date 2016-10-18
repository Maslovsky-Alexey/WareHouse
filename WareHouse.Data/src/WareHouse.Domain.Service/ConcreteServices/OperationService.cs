using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Domain.Model;
using WareHouse.Domain.Model.ViewModel;
using WareHouse.Domain.ServiceInterfaces;

namespace WareHouse.Domain.Service.ConcreteServices
{
    public class OperationService : IOperationService
    {
        private IWarehouseItemService warehouseItemService;

        private IItemStatusService itemStatusService;


        public OperationService(IWarehouseItemService warehouseItemService, IItemStatusService itemStatusService)
        {
            this.itemStatusService = itemStatusService;
            this.warehouseItemService = warehouseItemService;
        }

        public async Task AddOrder(OrderViewModel item)
        {
            await warehouseItemService.Add(new WarehouseItem
            {
                Count = item.Count,
                Item = new Item { Id = item.ItemId },
                Status = await itemStatusService.GetStatus(Data.Model.Status.ProcessingOrder)
            });
        }

        public async Task AddSupply(SupplyViewModel item)
        {
            var status = await itemStatusService.GetStatus(Data.Model.Status.ProcessingSupply);

            var result = await warehouseItemService.Add(new WarehouseItem
            {
                Count = item.Count,
                ItemId = item.ItemId,
                StatusId = status.Id
            });
        }

        public async Task ConfirmOrder(int itemId)
        {
            await UpdateItemStatus(itemId, Data.Model.Status.OrederSuccess);
        }

        public async Task ConfirmSupply(int itemId)
        {
            await UpdateItemStatus(itemId, Data.Model.Status.SupplySuccess);
        }

        public async Task ReturnOrder(int itemId)
        {
            await UpdateItemStatus(itemId, Data.Model.Status.OrderFailed);
        }

        public async Task ReturnSupply(int itemId)
        {
            await UpdateItemStatus(itemId, Data.Model.Status.SupplyFailed);
        }

        private async Task UpdateItemStatus(int itemId, Data.Model.Status status)
        {
            var a = warehouseItemService.GetItem(itemId);

            if (a == null)
                return;

            await warehouseItemService.UpdateStatus(itemId, (await itemStatusService.GetStatus(status)).Id);
        }
    }
}
