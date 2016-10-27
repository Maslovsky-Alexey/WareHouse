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
    public class AccountProxyService : ISafeAccountService, System.IObservable<SignInLogModel>
    {
        private List<IObserver<SignInLogModel>> subscribers = new List<IObserver<SignInLogModel>>();

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
            if (!await safeAccountService.Login(model))
                return false;

            var user = await safeAccountService.GetUserByName(model.Username);

            OnNext(new SignInLogModel
            {
                UserName = user.Login,
                isEmployee = user.isEmployee,
                FullName = user.Name,
                DateTime = DateTime.Now
            });

            return true;
        }

        public IDisposable Subscribe(IObserver<SignInLogModel> observer)
        {
            subscribers.Add(observer);
            return null;
        }

        protected void OnNext(SignInLogModel value)
        {
            subscribers.ForEach(subscriber => subscriber.OnNext(value));
        }
    }
}
