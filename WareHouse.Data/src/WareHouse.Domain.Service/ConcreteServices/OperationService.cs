using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Data.Model;
using WareHouse.Domain.Model;
using WareHouse.Domain.Model.ViewModel;
using WareHouse.Domain.ServiceInterfaces;
using Order = WareHouse.Domain.Model.Order;
using Supply = WareHouse.Domain.Model.Supply;

namespace WareHouse.Domain.Service.ConcreteServices
{
    public class OperationService : IOperationService
    {
        private readonly IWarehouseItemService warehouseItemService;

        private readonly IItemStatusService itemStatusService;
        private readonly ISupplyService supplyService;
        private readonly IOrderService orderService;


        public OperationService(IWarehouseItemService warehouseItemService, IItemStatusService itemStatusService, ISupplyService supplyService, IOrderService orderService)
        {
            this.orderService = orderService;
            this.supplyService = supplyService;
            this.itemStatusService = itemStatusService;
            this.warehouseItemService = warehouseItemService;
        }

        public async Task AddOrder(OrderViewModel item)
        {
            await orderService.Add(new Order
            {
                ClientId = item.ClientId,
                EmployeeId = item.EmployeeId,
                ItemId = item.ItemId,
                StatusId = (await itemStatusService.GetStatus(Data.Model.Status.Processing)).Id,
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
                StatusId = (await itemStatusService.GetStatus(Data.Model.Status.Processing)).Id,
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

            await warehouseItemService.Add(new Model.WarehouseItem
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

        private async Task<int> GetStatusId(Data.Model.Status status)
        {
            return (await itemStatusService.GetStatus(status)).Id;
        }
    }
}
