using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WareHouse.Data.EF.Context;
using WareHouse.Data.Model;
using WareHouse.Data.Repository;

namespace WareHouse.Data.EF.Repository
{
    public class ClientRepository : BaseRepository<Client>, IClientRepository
    {
        public ClientRepository(WareHouseDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<Client> AssignWithApplicationUser(int clientId, string userId)
        {
            var client = await GetItem(clientId);

            if (client == null)
                return null;

            client.UserId = userId;
            await SaveChanges();
            return client;
        }

        public async Task<Client> GetClientByIdentityId(string identityId)
        {
            return await context.Clients.FirstOrDefaultAsync(x => x.UserId == identityId);
        }

        public async Task<Client> GetClientByName(string name, bool ignoreCase)
        {
            if (ignoreCase)
                return await context.Clients.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());
            return await context.Clients.FirstOrDefaultAsync(x => x.Name == name);
        }
    }
}