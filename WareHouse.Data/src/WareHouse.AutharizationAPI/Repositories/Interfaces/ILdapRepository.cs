using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.AutharizationAPI.Repositories.Models;

namespace WareHouse.AutharizationAPI.Repositories.Interfaces
{
    public interface ILdapRepository
    {
        Task<OperationStatus> Login(LoginModel model);

        Task<UserModel> GetUserByName(string username);
    }
}
