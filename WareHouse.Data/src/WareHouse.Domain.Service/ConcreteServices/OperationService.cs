using System;
using System.Threading.Tasks;
using WareHouse.Data.Model;
using WareHouse.Domain.Model.ViewModel;
using WareHouse.Domain.ServiceInterfaces;
using Item = WareHouse.Domain.Model.Item;
using Order = WareHouse.Domain.Model.Order;
using Supply = WareHouse.Domain.Model.Supply;
using WarehouseItem = WareHouse.Domain.Model.WarehouseItem;

namespace WareHouse.Domain.Service.ConcreteServices
{
    public class OperationService : IOperationService
    {
        private readonly IItemService itemService;
        private readonly IItemStatusService itemStatusService;
        private readonly IOrderService orderService;
        private readonly ISupplyService supplyService;
        private readonly IWarehouseItemService warehouseItemService;


        public OperationService(IWarehouseItemService warehouseItemService, IItemStatusService itemStatusService,
            ISupplyService supplyService, IOrderService orderService, IItemService itemService)
        {
            this.itemService = itemService;
            this.orderService = orderService;
            this.supplyService = supplyService;
            this.itemStatusService = itemStatusService;
            this.warehouseItemService = warehouseItemService;
        }

        public async Task AddItemWithoutRepetition(Item item)
        {
            await itemService.AddWithoutRepetition(item);

            item = await itemService.GetItemByName(item.Name, false);

            await warehouseItemService.Add(new WarehouseItem
            {
                ItemId = item.Id,
                Count = 0
            });
        }

        public async Task AddOrder(OrderViewModel item)
        {
            await orderService.Add(new Order
            {
                ClientId = item.Client.Id,
                EmployeeId = item.Employee.Id,
                ItemId = item.Item.Id,
                StatusId = (await itemStatusService.GetStatus(Status.Processing)).Id,
                Count = item.Count,
                DateTime = DateTime.Now
            });
        }

        public async Task AddSupply(SupplyViewModel item)
        {
            await supplyService.Add(new Supply
            {
                ProviderId = item.Provider.Id,
                EmployeeId = item.Employee.Id,
                ItemId = item.Item.Id,
                StatusId = (await itemStatusService.GetStatus(Status.Processing)).Id,
                Count = item.Count,
                DateTime = DateTime.Now
            });
        }

        public async Task ConfirmOrder(int orderId)
        {
            var order = await orderService.GetItem(orderId);
            var statusSuccess = await GetStatusId(Status.Success);

            if (order.StatusId == statusSuccess)
                return;

            await warehouseItemService.UpdateCount((await GetWarehouseItemByItemId(order.ItemId)).Id, -order.Count);

            await orderService.UpdateOrderStatus(orderId, await GetStatusId(Status.Success));
        }

        public async Task ConfirmSupply(int supplyId)
        {
            var supply = await supplyService.GetItem(supplyId);
            var statusSuccess = await GetStatusId(Status.Success);

            if (supply.StatusId == statusSuccess)
                return;

            await supplyService.UpdateSupplyStatus(supplyId, statusSuccess);
           
            await warehouseItemService.AddOrUpdate(new WarehouseItem
            {
                Count = supply.Count,
                Item = await itemService.GetItem(supply.ItemId)
            });
        }


        public async Task ReturnOrder(int orderId)
        {
            var order = await orderService.GetItem(orderId);
            var statusSuccess = await GetStatusId(Status.Success);

            await orderService.UpdateOrderStatus(orderId, await GetStatusId(Status.Failure));

            if (order.StatusId == statusSuccess)
            {
                await warehouseItemService.UpdateCount(
                    (await GetWarehouseItemByItemId(order.ItemId)).Id, order.Count);

                return;
            }            
        }

        public async Task ReturnSupply(int supplyId)
        {
            var supply = await supplyService.GetItem(supplyId);
            var statusSuccess = await GetStatusId(Status.Success);

            await supplyService.UpdateSupplyStatus(supplyId, await GetStatusId(Status.Failure));

            if (supply.StatusId == statusSuccess)
            {
                await warehouseItemService.UpdateCount(
                    (await GetWarehouseItemByItemId(supply.ItemId)).Id, -supply.Count);

                return;
            }
        }

        private async Task<WarehouseItem> GetWarehouseItemByItemId(int itemId)
        {
            var item = await itemService.GetItem(itemId);
            return await warehouseItemService.GetItemByName(item.Name, false);
        }

        private async Task<int> GetStatusId(Status status)
        {
            return (await itemStatusService.GetStatus(status)).Id;
        }
    }
}