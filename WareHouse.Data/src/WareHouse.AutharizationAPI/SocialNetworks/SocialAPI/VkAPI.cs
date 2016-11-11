﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using WareHouse.AutharizationAPI.SocialNetworks.Models;
using WareHouse.AutharizationAPI.SocialNetworks.UriExtension;
using WareHouse.AutharizationAPI.SocialNetworks.Interfaces;
using WareHouse.AutharizationAPI.HttpHelper;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http.Extensions;

namespace WareHouse.AutharizationAPI.SocialNetworks.SocialAPI
{
    public class VkAPI : ISocialAPI
    {
        private string appId;

        private string appSecret; 

        public VkAPI(string appId, string appSecret)
        {
            this.appId = appId;
            this.appSecret = appSecret;
        }

        public string ProviderName
        {
            get
            {
                return "Vk";
            }
        }

        public async Task<TokenModel> GetAuthorizationToken(HttpRequest httpRequest, string redirectUri)
        {
            var codeModel = GetCode(httpRequest);

            var accessTokenUri = GetUriToGetToken(redirectUri, codeModel.Code);

            var webRequestHelper = new WebRequestHelper();

            var accessTokenModel = webRequestHelper.GetObjectFromResponse<Models.TokenModel>(await webRequestHelper.SendRequest(accessTokenUri, "get", ""));

            return accessTokenModel;
        }

        public AuthorizationAnswerCode GetCode(HttpRequest httpRequest)
        {
            if (httpRequest.Query.ContainsKey("code"))
            {
                return new AuthorizationAnswerCode
                {
                    Code = httpRequest.Query["code"],
                    NeedRedirectToGetCode = false
                };
            }
            else
            if (httpRequest.Query.ContainsKey("error"))
            {
                return new AuthorizationAnswerCode
                {
                    Error = httpRequest.Query["error"],
                    ErrorDescription = httpRequest.Query["error_description"],
                    NeedRedirectToGetCode = false
                };
            }

            return new AuthorizationAnswerCode
            {
                NeedRedirectToGetCode = true
            };
        }

        public string GetUriToGetCode(string redirectUri)
        {
            var uri = new UriBuilder("https://oauth.vk.com/authorize");

            uri.AddGetParameter("redirect_uri", redirectUri);
            uri.AddGetParameter("client_id", appId);
            uri.AddGetParameter("display", "page");


            return uri.ToString();
        }

        public string GetUriToGetToken(string redirectUri, string code)
        {
            var uri = new UriBuilder("https://oauth.vk.com/access_token");

            uri.AddGetParameter("redirect_uri", redirectUri);
            uri.AddGetParameter("client_id", appId);
            uri.AddGetParameter("client_secret", appSecret);
            uri.AddGetParameter("code", code);

            return uri.ToString();
        }
    }
}
