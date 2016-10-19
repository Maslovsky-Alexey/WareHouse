using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Data.Model;
using WareHouse.Domain.Model;
using WareHouse.MyOData;

namespace WareHouse.Domain.ServiceInterfaces
{
    public interface IOrderService : IService<Domain.Model.Order, Data.Model.Order>
    {
        Task UpdateOrderStatus(int id, int statusId);
    }
}
