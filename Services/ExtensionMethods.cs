using System;
using Microsoft.AspNetCore.Builder;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

using Microsoft.EntityFrameworkCore;
using Portfolio.Data;

using Portfolio.IServices;

namespace Portfolio.Services
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext, IUrlTransformerService service)
        {
            var pathToCheck = "Articles";

            var actualPath = httpContext.Request.Path;

            if (service.IsValidPath(actualPath, pathToCheck))
            {
                var transformedUrl = await service.TransformUrl(actualPath);

                httpContext.Request.Path = "/" + pathToCheck + "/" + transformedUrl;
            }

            await _next(httpContext);
        }
    }

    public static class IApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseTitleRouteHandler(this IApplicationBuilder @this)
        {
            return @this.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}
