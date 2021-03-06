﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using WareHouse.AutharizationAPI.SocialNetworks.Models;
using WareHouse.AutharizationAPI.SocialNetworks.UriExtension;
using WareHouse.AutharizationAPI.SocialNetworks.Interfaces;
using WareHouse.HttpWebHelperLibrary;

namespace WareHouse.AutharizationAPI.SocialNetworks.SocialAPI
{
    public class FacebookAPI : ISocialAPI
    {
        private string appId;

        private string appSecret;

        private readonly IWebRequestHelper webRequest;

        public FacebookAPI(string appId, string appSecret, IWebRequestHelper webRequest)
        {
            this.appId = appId;
            this.appSecret = appSecret;
        }

        public string ProviderName
        {
            get
            {
                return "Facebook";
            }
        }

        public async Task<TokenModel> GetAuthorizationToken(HttpRequest httpRequest, string redirectUri)
        {
            var codeModel = GetCode(httpRequest);

            var accessTokenUri = GetUriToGetToken(redirectUri, codeModel.Code);

            var accessTokenModel = webRequest.GetObjectFromResponse<TokenModel>(await webRequest.SendRequest(accessTokenUri, "get", ""));


            if (accessTokenModel != null && accessTokenModel.Access_Token != null)
            {
                var uriToGetUser = new UriBuilder("https://graph.facebook.com/me");
                uriToGetUser.AddGetParameter("access_token", accessTokenModel.Access_Token);
                var face = webRequest.GetObjectFromResponse<FacebookUserModel>(await webRequest.SendRequest(uriToGetUser.ToString(), "get", ""));
                accessTokenModel.User_Id = face.Id;
            }
          
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
            var uri = new UriBuilder("https://www.facebook.com/v2.8/dialog/oauth");

            uri.AddGetParameter("redirect_uri", redirectUri);
            uri.AddGetParameter("client_id", appId);
            uri.AddGetParameter("dsfsdfsdf", "sdfdsfdsfdsf");

            return uri.ToString();
        }

        public string GetUriToGetToken(string redirectUri, string code)
        {
            var uri = new UriBuilder("https://graph.facebook.com/v2.8/oauth/access_token");

            uri.AddGetParameter("redirect_uri", redirectUri);
            uri.AddGetParameter("client_id", appId);
            uri.AddGetParameter("client_secret", appSecret);
            uri.AddGetParameter("code", code);

            return uri.ToString();
        }
    }
}
