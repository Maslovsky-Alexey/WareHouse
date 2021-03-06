﻿using Microsoft.AspNetCore.Http;

namespace WareHouse.HttpEx
{
    public static class HeadersHelper
    {
        public static void AddAuthorizationHeader(this HttpContext httpContext, string token)
        {
            httpContext.Response.Headers.Add("Authorization", new[] { $"Bearer {token}" });
        }

        public static string GetAuthorizationHeader(this HttpContext httpContext)
        {
            if (httpContext.Request.Headers.Keys.Contains("Authorization"))
            {
                return httpContext.Request.Headers["Authorization"];
            }

            return null;           
        }
    }
}