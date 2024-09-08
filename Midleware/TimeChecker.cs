using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Middlewear.Services;
using System.Threading.Tasks;

namespace Middlewear.Midleware
{
    public class TimeChecker
    {
        private readonly RequestDelegate _next;
        private readonly IActiveHours _activeHours;

        public TimeChecker(RequestDelegate next, IActiveHours activeHours)
        {
            _next = next;
            _activeHours = activeHours;
        }


        public async Task Invoke(HttpContext httpContext)
        {
            if (!_activeHours.IsActive())
            {
                await httpContext.Response.WriteAsync("Not Active");
            }

            else
            {
                await _next(httpContext);
            }
        }
    }


    public static class TimeCheckerExtensions
    {
        public static IApplicationBuilder UseTimeChecker(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TimeChecker>();
        }
    }
}
