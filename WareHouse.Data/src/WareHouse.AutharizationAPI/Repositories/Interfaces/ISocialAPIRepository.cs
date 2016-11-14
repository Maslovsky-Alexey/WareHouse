using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.AutharizationAPI.Context.Models;
using WareHouse.AutharizationAPI.Repositories.Models;
using WareHouse.AutharizationAPI.SocialNetworks.Interfaces;
using WareHouse.AutharizationAPI.SocialNetworks.Models;
using WareHouse.AutharizationAPI.SocialNetworks.UriExtension;

namespace WareHouse.AutharizationAPI.Repositories.Interfaces
{

    public interface ISocialAPIRepository
    {
        Task<UserModel> RegisterUser(TokenModel token, string userName);

        Task<TokenModel> GetAccessToken(HttpRequest request, string redirectUri);

        string GetUriToGetCode(string redirectUri, params KeyValue[] parameters);

        Task<UserModel> GetUserByToken(TokenModel token);
    }
}
