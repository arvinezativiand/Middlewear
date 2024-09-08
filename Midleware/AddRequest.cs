using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Middlewear.DB.EF;
using System.Threading.Tasks;
using Middlewear.DB.Services;
using Middlewear.DB.Entity;
using System.Diagnostics.Metrics;

namespace Middlewear.Midleware;

public class AddRequest
{
    private readonly RequestDelegate _next;

    public AddRequest(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext httpContext, Crud crud)
    {
        crud.Add(new User()
        {
            Body = httpContext.Request.Body.ToString(),
            Host = httpContext.Request.Host.ToString(),
            IsHttps = httpContext.Request.IsHttps,
            Path = httpContext.Request.Path,
        });
        await _next(httpContext);
    }
}

public static class AddRequestExtensions
{
    public static IApplicationBuilder UseAddRequest(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<AddRequest>();
    }
}
