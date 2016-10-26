using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using WareHouse.Data.Repository;
using WareHouse.Domain.Model;
using WareHouse.Domain.Model.ViewModel;
using WareHouse.Domain.Service.ConcreteServices;
using WareHouse.Domain.ServiceInterfaces;
using WareHouse.Domain.ServiceInterfaces.Safe;

namespace WareHouse.Domain.Service.ProxyServices
{
    public class ClientProxyService : ISafeClientService
    {
        private ISafeClientService safeClientService;


        public ClientProxyService(ISafeClientService safeClientService)
        {
            this.safeClientService = safeClientService;
        }      

        public async Task<int> Count()
        {
            return await safeClientService.Count();
        }

        public async Task<IEnumerable<Client>> GetAll()
        {
            return await safeClientService.GetAll();
        }

        public async Task<Client> GetClientByIdentityId(string identityId)
        {
            return await safeClientService.GetClientByIdentityId(identityId);
        }

        public async Task<Client> GetClientByName(string name, bool ignoreCase)
        {
            return await safeClientService.GetClientByName(name, ignoreCase);
        }

        public async Task<Client> GetItem(int id)
        {
            return await safeClientService.GetItem(id);
        }

    }
}
