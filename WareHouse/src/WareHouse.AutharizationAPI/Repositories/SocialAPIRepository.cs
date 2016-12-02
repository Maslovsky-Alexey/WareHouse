using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.AutharizationAPI.Repositories.Interfaces;
using WareHouse.AutharizationAPI.SocialNetworks.Interfaces;
using WareHouse.AutharizationAPI.SocialNetworks.UriExtension;
using WareHouse.AutharizationAPI.SocialNetworks.SocialAPI;
using WareHouse.AutharizationAPI.SocialNetworks.Models;
using WareHouse.AutharizationAPI.Repositories.Models;
using WareHouse.AutharizationAPI.Context;
using Microsoft.EntityFrameworkCore;
using WareHouse.AutharizationAPI.PasswordGenerators;

namespace WareHouse.AutharizationAPI.Repositories
{
    public abstract class SocialAPIRepository : ISocialAPIRepository
    {
        private ISocialAPI socialAPI;

        private readonly IApplicationUserRepository userRepository;

        private readonly UsersContext context;

        private readonly IPasswordGenerator passwordGenerator;


        public SocialAPIRepository(IApplicationUserRepository userRepository, ISocialAPI socialAPI, UsersContext context, IPasswordGenerator passwordGenerator)
        {
            this.socialAPI = socialAPI;
            this.userRepository = userRepository;
            this.context = context;
            this.passwordGenerator = passwordGenerator;
        }

        public string GetUriToGetCode(string redirectUri, params KeyValue[] parameters)
        {
            var uri = new UriBuilder(redirectUri);

            foreach (var parameter in parameters)
                uri.AddGetParameter(parameter.Key, parameter.Value);

            return socialAPI.GetUriToGetCode(uri.ToString());
        }

        public async Task<TokenModel> GetAccessToken(HttpRequest request, string redirectUri)
        {
            return await socialAPI.GetAuthorizationToken(request, redirectUri);
        }

        public async Task<UserModel> RegisterUser(TokenModel token, string userName)
        {
            var user = await userRepository.Register(new RegisterModel { Username = userName, Password = passwordGenerator.GeneratePassword(20, 30) });

            if (user != null)
            {
                context.UserTokens.Add(new Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>
                {
                    LoginProvider = socialAPI.ProviderName,
                    Name = socialAPI.ProviderName,
                    UserId = user.Id,
                    Value = token.User_Id
                });

                if (await context.SaveChangesAsync() <= 0)
                    return null;
            }

            return user;
        }

        public async Task<UserModel> GetUserByToken(TokenModel token)
        {
            var getUserId = context.UserTokens.Where(x => x.LoginProvider == socialAPI.ProviderName).FirstOrDefault(x => x.Value == token.User_Id)?.UserId;

            return await userRepository.GetUserById(getUserId);
        }
    }
}
