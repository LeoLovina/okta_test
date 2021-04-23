using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Common.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace WebApi.Exceptions
{
    // https://docs.microsoft.com/zh-tw/aspnet/core/fundamentals/middleware/write?view=aspnetcore-5.0
    public static class ExceptionMiddlewareExtensions
    {
        // Use extension method to expose the middleware
        public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExceptionMiddleware>();
        }
    }

    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger, RequestDelegate next)
        {
            this._next = next;
            this._logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, context.Request.Path);
                context.Response.StatusCode = 500;
                var details = ServiceResult.Failed(ex.Message);
                await context.Response
                    .WriteAsJsonAsync(details);
            }
        }
    }
}
