using WareHouse.AutharizationAPI.Repositories.Interfaces;
using WareHouse.AutharizationAPI.SocialNetworks.Interfaces;
using WareHouse.AutharizationAPI.Context;
using WareHouse.AutharizationAPI.PasswordGenerators;

namespace WareHouse.AutharizationAPI.Repositories
{
    public class SocialAPIVkRepository : SocialAPIRepository, ISocialAPIRepositoryVk
    {
        public SocialAPIVkRepository(IApplicationUserRepository userRepository, ISocialAPI socialAPI, UsersContext context, IPasswordGenerator passwordGenerator) : base(userRepository, socialAPI, context, passwordGenerator)
        {
        }
    }
}
