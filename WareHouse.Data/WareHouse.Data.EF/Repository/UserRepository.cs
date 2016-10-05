using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Data.EF.Context;
using WareHouse.Data.Model;
using WareHouse.Data.Repository;

namespace WareHouse.Data.EF.Repository
{
    public class UserRepository : IUserRepository
    {
        private WareHouseDbContext context;

        public UserRepository(WareHouseDbContext context)
        {
            this.context = context;
        }

        public async Task<ApplicationUser> GetUserByName(string name, bool ignoreCase)
        {
            if (ignoreCase)
            {
                return await context.Users.FirstOrDefaultAsync(x => x.UserName.ToLower() == name.ToLower());
            }
            else
            {
                return await context.Users.FirstOrDefaultAsync(x => x.UserName == name);
            }
        }
    }
}
