using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.AuthAPIHelper.AutharizationAPIModel;

namespace WareHouse.AuthAPIHelper
{
    public interface IAuthHelper
    {
        Task<string> Login(PasswordNameModel model);
    
        Task<UserAPIModel> GetUserByName(string username);

        Task<UserAPIModel> GetUserByToken(string token);

        Task<IEnumerable<string>> GetUserRoles(string name);

        Task<UserAPIModel> AddRole(string username, string role);

        Task<UserAPIModel> RegisterUserWithRole(string name, string password, string role);
    }
}
