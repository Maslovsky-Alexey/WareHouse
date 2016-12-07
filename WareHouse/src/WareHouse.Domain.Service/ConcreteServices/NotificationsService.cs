using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Domain.ServiceInterfaces;
using WareHouse.PollingEventManager;
using WareHouse.PollingEventManager.Models;

namespace WareHouse.Domain.Service.ConcreteServices
{
    public class NotificationsService : INotificationsService
    {
        IPollingEventManager pollingEventManager;

        public NotificationsService(IPollingEventManager pollingEventManager)
        {
            this.pollingEventManager = pollingEventManager;
        }

        public async Task<IEnumerable<EventModel>> GetNotifications(long ticks)
        {
            return await pollingEventManager.GetFreshEventsAsync(ticks);
        }
    }
}
