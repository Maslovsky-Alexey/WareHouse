using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Caches;
using WareHouse.PollingEventManager.Models;
using Newtonsoft.Json.Linq;

namespace WareHouse.PollingEventManager
{
    public class PollingEventManager : IPollingEventManager
    {
        private ICache cache;

        private static PollingEventManager instance;

        public static PollingEventManager Instance(ICache cache)
        {
            if (instance == null)
            {
                instance = new PollingEventManager(cache);
            }
             
            return instance;
        }

        public PollingEventManager(ICache cache)
        {
            this.cache = cache;
        }

        public IEnumerable<EventModel> GetFreshEvents(long ticks)
        {
            var allKeys = GetFreshKeys(cache.GetAllKeys(), ticks);

            var result = new List<EventModel>();

            foreach (var key in allKeys)
            {
                result.Add(cache.Get<EventModel>(key.ToString()));
            }

            return result;
        }

        public async Task<IEnumerable<EventModel>> GetFreshEventsAsync(long ticks)
        {
            var allKeys = GetFreshKeys(await cache.GetAllKeysAsync(), ticks);

            var result = new List<EventModel>();

            foreach (var key in allKeys)
            {
                result.Add(await cache.GetAsync<EventModel>(key.ToString()));
            }

            return result;
        }

        private IEnumerable<long> GetFreshKeys(IEnumerable<string> keys, long ticks)
        {
            return keys
                .Select(x => Convert.ToInt64(x))
                .Where(x => ticks < x);
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(object value)
        {
            var model = new EventModel
            {
                DataType = value.GetType().Name,
                Data = value,
                Ticks = DateTime.Now.Ticks
            };
            
            cache.AddOrUpdate(model.Ticks.ToString(), model);
        }
    }
}
