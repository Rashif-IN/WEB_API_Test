using System;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using System.Collections.Generic;
using System.IO;

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
                //start
                var time_start = DateTime.Now;
                await _next(context);
                //stop
                var time_end = DateTime.Now - time_start;

                Log_.SaveAllLog(context.Response.StatusCode.ToString(), context.Request.Method.ToString(),time_end.TotalMilliseconds.ToString());

            }
            else
            {
                var time_start = DateTime.Now;
                Log_.PopulateLog("Someone tried to access");
                var text = "gaboleh";
                var data = System.Text.Encoding.UTF8.GetBytes(text);
                await context.Response.Body.WriteAsync(data, 0, data.Length);
                var time_end = DateTime.Now - time_start;
                Log_.SaveAllLog(context.Response.StatusCode.ToString(), context.Request.Method.ToString(), time_end.TotalMilliseconds.ToString());
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
    //------------------------------------------------------------------------------------
 
    public class Log_
    {
        public static string Msg;
        
        public static void SaveAllLog(string Y, string Z, string Time )
        {
                File.AppendAllText(@"/Users/user/Projects/WEBAPI_Test/app.log", $"{DateTime.Now} {Y} {Z} {Time} ms: {Msg} \n");
        }

        public static void PopulateLog(string msg)
        {
           
            Msg = msg;
        }
    }

  

}
