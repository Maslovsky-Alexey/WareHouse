using Microsoft.AspNetCore.Http;

namespace WebAPI.Controllers
{
    public static class HeadersHelper
    {
        public static void AddAuthorizationHeader(HttpContext httpContext, string token) // TODO: Лучше сделать методом расширения
        {
            httpContext.Response.Headers.Add("Authorization", new[] {"Bearer " + token});
        }
    }
}