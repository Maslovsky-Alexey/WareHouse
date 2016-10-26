using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using WareHouse.Data.Repository;
using WareHouse.Domain.Model;
using WareHouse.Domain.Model.ViewModel;
using WareHouse.Domain.Service.ConcreteServices;
using WareHouse.Domain.ServiceInterfaces;
using WareHouse.Domain.ServiceInterfaces.Safe;
using WareHouse.Domain.Service.ProxyServices.Cache;

namespace WareHouse.Domain.Service.ProxyServices
{
    public class AccountProxyService : ISafeAccountService
    {
        private ISafeAccountService safeAccountService;
        private ICache cache;


        public AccountProxyService(ISafeAccountService safeAccountService, ICache cache)
        {
            this.safeAccountService = safeAccountService;
            this.cache = cache;
        }


        public async Task<UserModel> GetCurrentUser(HttpContext httpContext)
        {
            return await safeAccountService.GetCurrentUser(httpContext);
        }

        public async Task<UserModel> GetUserByName(string username)
        {
            return await safeAccountService.GetUserByName(username);
        }

        public async Task<bool> Login(LoginModel model)
        {
            return await safeAccountService.Login(model);
        }
    }
}
