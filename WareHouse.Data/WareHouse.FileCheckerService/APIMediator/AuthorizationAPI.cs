using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHouse.FileCheckerService.APIMediator.Interfaces;
using WareHouse.FileCheckerService.Models.APIModel;

namespace WareHouse.FileCheckerService.APIMediator
{
    public class AuthorizationAPI : IAuthorizationAPI
    {
        private readonly BaseMediator baseMediator;

        public AuthorizationAPI(BaseMediator baseMediator)
        {
            this.baseMediator = baseMediator;
        }

        public string Login(LoginAPIModel model)
        {
            var response = baseMediator.SendRequest("http://localhost:33649/api/account/login", "post", JsonConvert.SerializeObject(model), "application/json; charset=UTF-8", "");

            return response.Headers["Authorization"];
        }
    }
}
