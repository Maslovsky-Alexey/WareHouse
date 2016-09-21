using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Domain.Model;

namespace WareHouse.Domain.ServiceInterfaces
{
    public interface IProviderService : IService<Domain.Model.Provider, Data.Model.Provider>
    {
        Task<Model.Provider> GetProviderByName(string name, bool ignoreCase);

        Task AddWithoutRepetition(Model.Provider value);

        Task RemoveProviderByName(Provider value);
    }
}
