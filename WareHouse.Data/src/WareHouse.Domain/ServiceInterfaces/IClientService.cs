using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WareHouse.Domain.ServiceInterfaces
{
    public interface IClientService : IService<Domain.Model.Client, Data.Model.Client>
    {
        Task<Model.Client> GetClientByName(string name, bool ignoreCase);

        Task AddWithoutRepetition(Model.Client value);

        Task RemoveClientByName(Model.Client value);
    }
}
