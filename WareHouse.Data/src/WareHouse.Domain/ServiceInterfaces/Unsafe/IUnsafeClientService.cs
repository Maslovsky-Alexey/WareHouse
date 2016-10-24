using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Domain.Model;
using WareHouse.Data.Repository;
using WareHouse.Domain.Model.ViewModel;

namespace WareHouse.Domain.ServiceInterfaces.Unsafe
{
    public interface IUnsafeClientService
    {
        Task<bool> AddWithoutRepetition(Client value);

        Task<bool> RemoveClientByName(Client value);

        Task<Client> AssignWithApplicationUser(int clientId, string userId);
    }
}
