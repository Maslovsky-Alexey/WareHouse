using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Domain.Model;

namespace WareHouse.Domain.ServiceInterfaces
{
    public interface IItemStatusService : IService<Domain.Model.ItemStatus, Data.Model.ItemStatus>
    {
        Task<ItemStatus> GetStatus(Data.Model.Status status);
    }
}
