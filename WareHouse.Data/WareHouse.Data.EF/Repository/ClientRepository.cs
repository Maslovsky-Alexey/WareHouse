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
        public ClientRepository(WareHouseDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<Client> GetClientByName(string name, bool ignoreCase)
        {
            if (ignoreCase)
            {
                return await context.Clients.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());
            }
            else
            {
                return await context.Clients.FirstOrDefaultAsync(x => x.Name == name);
            }            
        }
    }
}
