using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Domain.Model;
using WareHouse.Domain.Model.ViewModel;

namespace WareHouse.Domain.ServiceInterfaces.Safe
{
    public interface ISafeItemStatusService
    {
        Task<ItemStatus> GetStatus(Data.Model.Status status);
    }
}
