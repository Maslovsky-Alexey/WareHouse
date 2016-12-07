using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.PollingEventManager.Models;

namespace WareHouse.Domain.ServiceInterfaces.Safe
{
    public interface ISafeNotificationsService
    {
        Task<IEnumerable<EventModel>> GetNotifications(long ticks);
    }
}
