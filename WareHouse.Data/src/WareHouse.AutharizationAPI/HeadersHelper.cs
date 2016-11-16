using Microsoft.AspNetCore.Http;

namespace WareHouse.AutharizationAPI
{
    public static class HeadersHelper
    {
        public static void AddAuthorizationHeader(this HttpContext httpContext, string token)
        {
            httpContext.Response.Headers.Add("Authorization", new[] {token});
        }
    }
}