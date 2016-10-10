using System;
using System.Security.Principal;
using WareHouse.Data.Model;

namespace WebAPI
{
    public class UserIndentity : IIdentity
    {
        public ApplicationUser User { get; set; }

        public string AuthenticationType
        {
            get
            {
                return typeof(ApplicationUser).ToString();
            }
        }

        public bool IsAuthenticated
        {
            get
            {
                return User != null;
            }
        }

        public string Name
        {
            get
            {
                if (User != null)
                {
                    return User.UserName;
                }

                return "anonym";
            }
        }


        public UserIndentity(ApplicationUser user)
        {
            User = user;
        }
    }
}