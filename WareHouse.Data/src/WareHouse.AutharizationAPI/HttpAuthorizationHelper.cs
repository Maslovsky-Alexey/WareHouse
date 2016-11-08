using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WareHouse.AutharizationAPI
{
    public static class HttpAuthorizationHelper
    {
        public static void AddAuthorizationHeader(this HttpContext httpContext, string token)
        {
            httpContext.Response.Headers.Add("Authorization", new[] { "Bearer " + token });
        }
    }
}
