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
        // private readonly IUrlTransformerService _service;
        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext, IUrlTransformerService service)
        {
            if (service.IsValidArticlePath(httpContext.Request.Path))
            {
                var transformedUrl = await service.TransformUrl(httpContext);

                httpContext.Request.Path = transformedUrl;
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
