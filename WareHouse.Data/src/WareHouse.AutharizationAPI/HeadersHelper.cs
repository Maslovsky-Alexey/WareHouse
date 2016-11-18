using Microsoft.AspNetCore.Http;

namespace WareHouse.AutharizationAPI
{
    // TODO: Такой же класс есть в проекте API, думаю можно вынести в отдельную сборку и использовтаь совместно
    public static class HeadersHelper
    {
        public static void AddAuthorizationHeader(this HttpContext httpContext, string token)
        {
            httpContext.Response.Headers.Add("Authorization", new[] {token});
        }
    }
}