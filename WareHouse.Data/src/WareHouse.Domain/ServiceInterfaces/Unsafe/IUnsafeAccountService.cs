using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.Data.Model;
using WareHouse.Data.Repository;
using WareHouse.Domain.Model.ViewModel;

namespace WareHouse.Domain.ServiceInterfaces.Unsafe
{
    public interface IUnsafeAccountService
    {
        Task<UserModel> RegisterClient(RegisterModel model);

        Task<UserModel> RegisterEmployee(RegisterModel model);

        Task<UserModel> AddRole(string username, string role);
    }
}
