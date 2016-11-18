using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHouse.FileCheckerService.APIMediator.Interfaces;
using WareHouse.FileCheckerService.APIMediator.WebRequestHelper;
using WareHouse.FileCheckerService.Models.APIModel;

namespace WareHouse.FileCheckerService.APIMediator
{
    public class AuthorizationAPI : IAuthorizationAPI
    {
        private readonly IWebRequestHelper webRequestHelper;

        public AuthorizationAPI(IWebRequestHelper webRequestHelper)
        {
            this.webRequestHelper = webRequestHelper;
        }

        // TODO: операция дублируется в WareHouse.Domain.Service.ConcreteServices.AccountService.Login. Нужно создать nuget пакет по работе с AuthAPI
        public string Login(LoginAPIModel model)
        {
            var response = webRequestHelper.Post("/api/account/login", JsonConvert.SerializeObject(model), "application/json; charset=UTF-8", "");

            if (response.HasError)
                return "";

            return response.ContainsHeader("Authorization") ? response["Authorization"] : "";
        }
    }
}
