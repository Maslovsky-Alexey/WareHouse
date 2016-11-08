using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.AutharizationAPI.Context.Models;
using WareHouse.AutharizationAPI.Repositories.Models;

namespace WareHouse.AutharizationAPI.Repositories.Interfaces
{
    public enum OperationStatus
    {
        OK,
        Failed
    }

    public interface IApplicationUserRepository
    {
        Task<OperationStatus> Login(LoginModel model);

        Task<UserModel> Register(RegisterModel model);

        Task<UserModel> GetUserByName(string username);

        Task<OperationStatus> AddRole(string username, string role);

        Task<OperationStatus> RemoveRole(string username, string role);
    }
}
