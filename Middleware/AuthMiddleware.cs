using System;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;

namespace WEBAPI_Test.Middleware
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.Request.Headers["Pass"] == "hello")
            {
                await _next(context);
                
            }
            else
            {
                var text = "gaboleh";
                var data = System.Text.Encoding.UTF8.GetBytes(text);
                await context.Response.Body.WriteAsync(data, 0, data.Length);

            }

        }
    }
    public static class AuthMiddlewareExtension
    {
        public static IApplicationBuilder UseAuthMid(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AuthMiddleware>();
        }
    }
}
