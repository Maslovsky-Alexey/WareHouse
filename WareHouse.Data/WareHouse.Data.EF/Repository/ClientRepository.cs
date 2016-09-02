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
    public class ClientRepository : IClientRepository
    {
        private WareHouseDbContext context;

        public ClientRepository(WareHouseDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Client>> GetAll()
        {
            return await context.Clients.ToArrayAsync();
        }

        public async Task Add(Client client)
        {
            await Task.Factory.StartNew(() => context.Clients.Add(client));
        }

        public async Task Remove(Client client)
        {
            await Task.Factory.StartNew(() => context.Clients.Remove(client));
        }

        public async Task<Client> GetItem(int id)
        {
            return await context.Clients.FirstAsync(client => client.ID == id);
        }

        public async Task<int> Count()
        {
            return await Task.Factory.StartNew(context.Clients.Count);
        }
    }
}
