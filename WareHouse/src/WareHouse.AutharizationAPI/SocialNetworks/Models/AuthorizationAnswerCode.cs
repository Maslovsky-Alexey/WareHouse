using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WareHouse.AutharizationAPI.SocialNetworks.Models
{
    public class AuthorizationAnswerCode
    {
        public string Code { get; set; }

        public string Error { get; set; }

        public string ErrorDescription { get; set; }

        public bool NeedRedirectToGetCode { get; set; }
    }
}
