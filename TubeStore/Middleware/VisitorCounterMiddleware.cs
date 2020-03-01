using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace TubeStore.Middleware
{
    public class VisitorCounterMiddleware
    {
        private readonly RequestDelegate _next;

        public VisitorCounterMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Session.GetString("Counter") == null)
                httpContext.Session.SetString("Counter", "1");

            string visitorId = httpContext.Request.Cookies["VisitorId"];
            
            if (visitorId == null)
            {
                httpContext.Response.Cookies.Append("VisitorId", Guid.NewGuid().ToString(), new CookieOptions()
                {
                    Path = "/",
                    HttpOnly = true,
                    Secure = false,
                });
                int counter = Int32.Parse(httpContext.Session.GetString("Counter")) + 1;
                httpContext.Session.SetString("Counter", counter.ToString());
            }

            await _next(httpContext);
        }
    }


    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<VisitorCounterMiddleware>();
        }
    }
}
