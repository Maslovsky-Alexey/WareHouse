using System;
using Microsoft.EntityFrameworkCore;
using WareHouse.Domain.ServiceInterfaces;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using WareHouse.Data.Model;
using WareHouse.Data.EF.Repository;

namespace WareHouse.Domain.Service.ConcreteServices
{
    public class ClientService : BaseService<Client>, IClientService
    {
        public ClientService(BaseRepository<Client> clients) : base(clients)
        {
        }
    }
}
