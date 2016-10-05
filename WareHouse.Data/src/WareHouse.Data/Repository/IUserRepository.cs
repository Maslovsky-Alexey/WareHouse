using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Data.Model;

namespace WareHouse.Data.Repository
{
    public interface IUserRepository
    {
        Task<ApplicationUser> GetUserByName(string name, bool ignoreCase);
    }
}
