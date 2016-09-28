using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Data.Model;

namespace WareHouse.Data.Repository
{
    public interface IProviderRepository : IRepository<Model.Provider>
    {
        Task<Provider> GetProviderByName(string name, bool ignoreCose);
    }
}
