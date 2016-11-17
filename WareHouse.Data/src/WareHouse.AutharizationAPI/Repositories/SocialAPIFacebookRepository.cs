using WareHouse.AutharizationAPI.Repositories.Interfaces;
using WareHouse.AutharizationAPI.SocialNetworks.Interfaces;
using WareHouse.AutharizationAPI.Context;

namespace WareHouse.AutharizationAPI.Repositories
{
    public class SocialAPIFacebookRepository : SocialAPIRepository, ISocialAPIRepositoryFacebook
    {
        public SocialAPIFacebookRepository(IApplicationUserRepository userRepository, ISocialAPI socialAPI, UsersContext context) : base(userRepository, socialAPI, context)
        {
        }
    }
}
