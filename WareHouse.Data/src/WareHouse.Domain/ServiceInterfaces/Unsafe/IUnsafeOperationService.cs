using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Domain.Model;
using WareHouse.Data.Repository;
using WareHouse.Domain.Model.ViewModel;

namespace WareHouse.Domain.ServiceInterfaces.Unsafe
{
    public enum ReturnStatus
    {
        Returned,
        NotFound,
        NotReturned
    }

    public enum ConfirmationStatus
    {
        Confirmed,
        NotFound,
        NotConfirmed
    }


    public interface IUnsafeOperationService
    {
        Task<OperationStatus> AddOrder(OrderViewModel item);

        Task<OperationStatus> AddSupply(SupplyViewModel item);

        Task<ConfirmationStatus> ConfirmOrder(int itemId);

        Task<ConfirmationStatus> ConfirmSupply(int itemId);

        Task<ReturnStatus> ReturnOrder(int itemId);

        Task<ReturnStatus> ReturnSupply(int itemId);

        Task AddItemWithoutRepetition(Item item);
    }
}
