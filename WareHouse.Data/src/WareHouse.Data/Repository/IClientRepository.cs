using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Data.Model;

namespace WareHouse.Data.Repository
{
    public interface IClientRepository : IRepository<Model.Client>
    {
        Task<Client> GetClientByName(string name, bool ignoreCase);

        Task<Client> GetClientByIdentityId(string identityId);

    }
}
