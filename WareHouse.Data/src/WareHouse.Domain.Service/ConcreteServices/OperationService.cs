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
                ClientId = item.ClientId,
                EmployeeId = item.EmployeeId,
                ItemId = item.ItemId,
                StatusId = (await itemStatusService.GetStatus(Status.Processing)).Id,
                Count = item.Count,
                DateTime = DateTime.Now
            });
        }

        public async Task AddSupply(SupplyViewModel item)
        {
            await supplyService.Add(new Supply
            {
                ProviderId = item.ProviderId,
                EmployeeId = item.EmployeeId,
                ItemId = item.ItemId,
                StatusId = (await itemStatusService.GetStatus(Status.Processing)).Id,
                Count = item.Count,
                DateTime = DateTime.Now
            });
        }

        public async Task ConfirmOrder(int itemId)
        {
            await orderService.UpdateOrderStatus(itemId, await GetStatusId(Status.Success));
        }

        public async Task ConfirmSupply(int itemId)
        {
            await supplyService.UpdateSupplyStatus(itemId, await GetStatusId(Status.Success));

            var supply = await supplyService.GetItem(itemId);

            await warehouseItemService.Add(new WarehouseItem
            {
                Count = supply.Count,
                ItemId = supply.ItemId
            });
        }


        public async Task ReturnOrder(int itemId)
        {
            await orderService.UpdateOrderStatus(itemId, await GetStatusId(Status.Failure));
        }

        public async Task ReturnSupply(int itemId)
        {
            await supplyService.UpdateSupplyStatus(itemId, await GetStatusId(Status.Failure));
        }

        private async Task<int> GetStatusId(Status status)
        {
            return (await itemStatusService.GetStatus(status)).Id;
        }
    }
}