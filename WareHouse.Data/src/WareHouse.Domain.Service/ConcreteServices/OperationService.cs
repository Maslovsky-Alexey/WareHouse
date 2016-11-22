using System;
using System.Threading.Tasks;
using WareHouse.Data.Model;
using WareHouse.Data.Repository;
using WareHouse.Domain.Model.ViewModel;
using WareHouse.Domain.ServiceInterfaces;
using WareHouse.Domain.ServiceInterfaces.Safe;
using WareHouse.Domain.ServiceInterfaces.Unsafe;
using Item = WareHouse.Domain.Model.Item;
using Order = WareHouse.Domain.Model.Order;
using Supply = WareHouse.Domain.Model.Supply;
using WarehouseItem = WareHouse.Domain.Model.WarehouseItem;

namespace WareHouse.Domain.Service.ConcreteServices
{
    public class OperationService : IOperationService
    {
        private readonly ISafeItemService safeItemService;
        private readonly IUnsafeItemService unsafeItemService;

        private readonly ISafeItemStatusService safeItemStatusService;
        private readonly IUnsafeItemStatusService unsafeItemStatusService;

        private readonly ISafeOrderService safeOrderService;
        private readonly IUnsafeOrderService unsafeOrderService;

        private readonly ISafeSupplyService safeSupplyService;
        private readonly IUnsafeSupplyService unsafeSupplyService;

        private readonly ISafeWarehouseItemService safeWarehouseItemService;
        private readonly IUnsafeWarehouseItemService unsafeWarehouseItemService;


        public OperationService(
            ISafeWarehouseItemService safeWarehouseItemService, IUnsafeWarehouseItemService unsafeWarehouseItemService,
            ISafeItemService safeItemService, IUnsafeItemService unsafeItemService,
            ISafeItemStatusService safeItemStatusService, IUnsafeItemStatusService unsafeItemStatusService,
            ISafeOrderService safeOrderService, IUnsafeOrderService unsafeOrderService,
            ISafeSupplyService safeSupplyService, IUnsafeSupplyService unsafeSupplyService)
        {
            this.safeItemService = safeItemService;
            this.unsafeItemService = unsafeItemService;

            this.safeItemStatusService = safeItemStatusService;
            this.unsafeItemStatusService = unsafeItemStatusService;

            this.safeOrderService = safeOrderService;
            this.unsafeOrderService = unsafeOrderService;

            this.safeSupplyService = safeSupplyService;
            this.unsafeSupplyService = unsafeSupplyService;

            this.safeWarehouseItemService = safeWarehouseItemService;
            this.unsafeWarehouseItemService = unsafeWarehouseItemService;
        }

        public async Task AddItemWithoutRepetition(Item item)
        {
            await unsafeItemService.AddWithoutRepetition(item);

            item = await safeItemService.GetItemByName(item.Name, false);

            await unsafeWarehouseItemService.Add(new WarehouseItem
            {
                ItemId = item.Id,
                Count = 0
            });
        }

        public async Task<OperationStatus> AddOrder(OrderViewModel item)
        {
            return await unsafeOrderService.Add(new Order
            {
                ClientId = item.Client.Id,
                EmployeeId = item.Employee.Id,
                ItemId = item.Item.Id,
                StatusId = (await safeItemStatusService.GetStatus(Status.Processing)).Id,
                Count = item.Count,
                DateTime = DateTime.Now
            });

        }

        public async Task<OperationStatus> AddSupply(SupplyViewModel supply)
        {
            return await unsafeSupplyService.Add(new Supply
            {
                ProviderId = supply.Provider.Id,
                EmployeeId = supply.Employee.Id,
                ItemId = supply.Item.Id,
                StatusId = (await safeItemStatusService.GetStatus(Status.Processing)).Id,
                Count = supply.Count,
                DateTime = DateTime.Now
            });
        }

        public async Task<ConfirmationStatus> ConfirmOrder(int orderId)
        {
            var order = await safeOrderService.GetItem(orderId);

            if (order == null)
                return ConfirmationStatus.NotFound;

            var statusSuccess = await GetStatusId(Status.Success);

            if (order.StatusId == statusSuccess)
                return ConfirmationStatus.NotConfirmed;

            await unsafeWarehouseItemService.UpdateCount((await GetWarehouseItemByItemId(order.ItemId)).Id, -order.Count);

            await unsafeOrderService.UpdateOrderStatus(orderId, await GetStatusId(Status.Success));

            return ConfirmationStatus.Confirmed;
        }

        public async Task<ConfirmationStatus> ConfirmSupply(int supplyId)
        {
            var supply = await safeSupplyService.GetItem(supplyId);

            if (supply == null)
                return ConfirmationStatus.NotFound;

            var statusSuccess = await GetStatusId(Status.Success);

            if (supply.StatusId == statusSuccess)
                return ConfirmationStatus.NotConfirmed;

            await unsafeSupplyService.UpdateSupplyStatus(supplyId, statusSuccess);
           
            await unsafeWarehouseItemService.AddOrUpdate(new WarehouseItem
            {
                Count = supply.Count,
                Item = await safeItemService.GetItem(supply.ItemId)
            });

            return ConfirmationStatus.Confirmed;
        }


        public async Task<ReturnStatus> ReturnOrder(int orderId)
        {
            var order = await safeOrderService.GetItem(orderId);

            if (order == null)
                return ReturnStatus.NotFound;

            var statusSuccess = await GetStatusId(Status.Success);

            await unsafeOrderService.UpdateOrderStatus(orderId, await GetStatusId(Status.Failure));

            if (order.StatusId == statusSuccess)
            {
                await unsafeWarehouseItemService.UpdateCount(
                    (await GetWarehouseItemByItemId(order.ItemId)).Id, order.Count);

                return ReturnStatus.Returned;
            }

            return ReturnStatus.NotReturned;
        }

        public async Task<ReturnStatus> ReturnSupply(int supplyId)
        {
            var supply = await safeSupplyService.GetItem(supplyId);

            if (supply == null)
                return ReturnStatus.NotFound;

            var statusSuccess = await GetStatusId(Status.Success);

            await unsafeSupplyService.UpdateSupplyStatus(supplyId, await GetStatusId(Status.Failure));

            if (supply.StatusId == statusSuccess)
            {
                await unsafeWarehouseItemService.UpdateCount(
                    (await GetWarehouseItemByItemId(supply.ItemId)).Id, -supply.Count);

                return ReturnStatus.Returned;
            }

            return ReturnStatus.NotReturned;
        }

        private async Task<WarehouseItem> GetWarehouseItemByItemId(int itemId)
        {
            var item = await safeItemService.GetItem(itemId);
            return await safeWarehouseItemService.GetItemByName(item.Name, false);
        }

        private async Task<int> GetStatusId(Status status)
        {
            return (await safeItemStatusService.GetStatus(status)).Id;
        }
    }
}