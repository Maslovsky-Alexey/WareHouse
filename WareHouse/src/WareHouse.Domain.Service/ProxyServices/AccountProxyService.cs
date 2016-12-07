using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using WareHouse.Domain.Model.ViewModel;
using WareHouse.Domain.ServiceInterfaces.Safe;
using WareHouse.Caches;

namespace WareHouse.Domain.Service.ProxyServices
{
    public class AccountProxyService : ISafeAccountService, IObservable<SignInLogModel>
    {
        private ISafeAccountService safeAccountService;
        private ICache cache;


        public AccountProxyService(ISafeAccountService safeAccountService, ICache cache)
        {
            this.safeAccountService = safeAccountService;
            this.cache = cache;
        }

        public async Task<UserModel> GetUserByName(string username)
        {
            return await safeAccountService.GetUserByName(username);
        }

        public IDisposable Subscribe(IObserver<SignInLogModel> observer)
        {
            return null;
        }

        protected void OnNext(SignInLogModel value)
        {
            MyEventStream.MyEventStream.Instance.Emit(value);
        }

        public async Task<string> Login(LoginModel model)
        {
            var token = await safeAccountService.Login(model);

            if (token == null)
                return null;

            var user = await safeAccountService.GetUserByName(model.Username);

            OnNext(new SignInLogModel
            {
                UserName = user.Login,
                isEmployee = user.isEmployee,
                FullName = user.Name,
                DateTime = DateTime.Now
            });

            return token;
        }

        public async Task<IEnumerable<string>> GetUserRoles(string name)
        {
            return await safeAccountService.GetUserRoles(name);
        }

        public async Task<UserModel> GetCurrentUser(HttpContext httpContext)
        {
            return await safeAccountService.GetCurrentUser(httpContext);
        }

        public async Task<UserModel> GetUserByToken(string token)
        {
            return await safeAccountService.GetUserByToken(token);
        }
    }
}
