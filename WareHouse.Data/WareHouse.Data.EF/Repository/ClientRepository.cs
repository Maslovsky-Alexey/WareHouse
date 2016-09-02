using System;
using Microsoft.EntityFrameworkCore;
using WareHouse.Data.Repository;
using WareHouse.Data.Model;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace WareHouse.Data.EF.Repository
{
    public class ClientRepository : IClientRepository
    {
        private DbSet<Client> clients;

        public ClientRepository(DbContext context)
        {
            clients = context.Set<Client>();
        }

        public async Task<IEnumerable<Client>> GetAll()
        {
            return await clients.ToArrayAsync();
        }

        public async Task Add(Client client)
        {
            await Task.Factory.StartNew(() => clients.Add(client));
        }

        public async Task Remove(Client client)
        {
            await Task.Factory.StartNew(() => clients.Remove(client));
        }

        public async Task<Client> GetItem(int id)
        {
            return await clients.FirstAsync(client => client.ID == id);
        }

        public async Task<int> Count()
        {
            return await Task.Factory.StartNew(clients.Count);
        }
    }
}
