using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WareHouse.Domain.Service.ProxyServices.Cache
{
    public interface ICacheManager
    {
        ICache AddOrGetExistSection(string sectionKey, ICache cache);
    }
}
