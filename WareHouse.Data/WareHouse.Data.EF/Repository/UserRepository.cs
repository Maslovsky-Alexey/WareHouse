using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WareHouse.Data.EF.Context;
using WareHouse.Data.Model;
using WareHouse.Data.Repository;

namespace WareHouse.Data.EF.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly WareHouseDbContext context;

        public UserRepository(WareHouseDbContext context)
        {
            this.context = context;
        }

        public async Task<ApplicationUser> GetUserByName(string name, bool ignoreCase)
        {
            if (ignoreCase)
                return await context.Users.FirstOrDefaultAsync(x => x.UserName.ToLower() == name.ToLower());
            return await context.Users.FirstOrDefaultAsync(x => x.UserName == name);
        }
    }
}