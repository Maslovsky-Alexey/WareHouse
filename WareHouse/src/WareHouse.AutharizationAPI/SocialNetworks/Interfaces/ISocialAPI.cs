using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WareHouse.AutharizationAPI.SocialNetworks.Models;

namespace WareHouse.AutharizationAPI.SocialNetworks.Interfaces
{
    public interface ISocialAPI
    {
        string ProviderName { get; }

        string GetUriToGetToken(string redirectUri, string code);

        Task<TokenModel> GetAuthorizationToken(HttpRequest httpRequest, string redirectUri);

        AuthorizationAnswerCode GetCode(HttpRequest httpRequest);

        string GetUriToGetCode(string redirectUri);
    }
}
