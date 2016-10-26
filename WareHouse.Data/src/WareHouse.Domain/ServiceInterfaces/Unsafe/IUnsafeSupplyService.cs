using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Domain.Model;
using WareHouse.Data.Repository;
using WareHouse.Domain.Model.ViewModel;

namespace WareHouse.Domain.ServiceInterfaces.Unsafe
{
    public interface IUnsafeSupplyService : IUnsafeService<Supply, Data.Model.Supply>
    {
        Task UpdateSupplyStatus(int id, int statusId);
    }
}
