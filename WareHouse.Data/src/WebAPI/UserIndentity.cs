using System.Security.Principal;
using WareHouse.Data.Model;

namespace WebAPI
{
    public class UserIndentity : IIdentity
    {
        public UserIndentity(ApplicaitonUser user)
        {
            User = user;
        }

        public ApplicaitonUser User { get; set; }

        public string AuthenticationType
        {
            get { return typeof(ApplicaitonUser).ToString(); }
        }

        public bool IsAuthenticated
        {
            get { return User != null; }
        }

        public string Name
        {
            get
            {
                if (User != null)
                    return User.UserName;

                return "anonym";
            }
        }
    }
}