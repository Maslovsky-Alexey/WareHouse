using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Domain.Model;
using WareHouse.Domain.Model.ViewModel;

namespace WareHouse.Domain.ServiceInterfaces
{
    public interface IOperationService
    {
        Task AddOrder(OrderViewModel item);

        Task AddSupply(SupplyViewModel item);

        Task ConfirmOrder(int itemId);

        Task ConfirmSupply(int itemId);

        Task ReturnOrder(int itemId);

        Task ReturnSupply(int itemId);
    }
}
