using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.PollingEventManager.Models;

namespace WareHouse.PollingEventManager
{
    public interface IPollingEventManager : IObserver<object>
    {
        IEnumerable<EventModel> GetFreshEvents(long ticks);

        Task<IEnumerable<EventModel>> GetFreshEventsAsync(long ticks);
    }
}
