using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Domain.Model;
using WareHouse.Data.Repository;
using WareHouse.Domain.Model.ViewModel;

namespace WareHouse.Domain.ServiceInterfaces.Unsafe
{
    public interface IUnsafeOperationService
    {
        Task<OperationStatus> AddOrder(OrderViewModel item);

        Task<OperationStatus> AddSupply(SupplyViewModel item);

        Task ConfirmOrder(int itemId);

        Task ConfirmSupply(int itemId);

        Task ReturnOrder(int itemId);

        Task ReturnSupply(int itemId);

        Task AddItemWithoutRepetition(Item item);
    }
}
