using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WareHouse.Domain.ServiceInterfaces
{
    public interface IItemStatusService : IService<Domain.Model.ItemStatus, Data.Model.ItemStatus>
    {
    }
}
