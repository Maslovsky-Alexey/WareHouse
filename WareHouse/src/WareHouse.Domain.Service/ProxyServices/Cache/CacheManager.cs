using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WareHouse.Domain.Service.ProxyServices.Cache
{
    public class CacheManager : ICacheManager
    {
        private static CacheManager instance;
        private Dictionary<string, ICache> sections;

        public static CacheManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new CacheManager();

                return instance;
            }
        }

        private CacheManager()
        {
            sections = new Dictionary<string, ICache>();
        }

        public ICache AddOrGetExistSection(string sectionKey, ICache cache)
        {
            try
            {
                sections.Add(sectionKey, cache);
            }
            catch
            {

            }

            return sections.FirstOrDefault(x => x.Key == sectionKey).Value;
        }
    }
}
