using System;
using Microsoft.EntityFrameworkCore;
using WareHouse.Data.Repository;
using WareHouse.Data.Model;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using WareHouse.Data.EF.Context;


namespace WareHouse.Data.EF.Repository
{
    public class ClientRepository : BaseRepository<Client>, IClientRepository
    {
        private WareHouseDbContext context;

        public ClientRepository(WareHouseDbContext context) : base(context.Clients)
        {
            this.context = context;
        }
    }
}
