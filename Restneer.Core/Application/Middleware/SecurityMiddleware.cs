﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Restneer.Core.Application.Middleware
{
    public class SecurityMiddleware
    {
        public IConfiguration Configuration { get; set; }
        readonly RequestDelegate _next;

        public SecurityMiddleware(RequestDelegate next, IConfiguration configuration)
        {
            Configuration = configuration;
            _next = next;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            List<string> cleanedUrls = new List<string>();
            foreach (var uriPart in httpContext.Request.Path.Value.Split("/"))
            {
                if (uriPart != string.Empty) {
                    cleanedUrls.Add(uriPart);
                }
            }


            await _next(httpContext);

            /*httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = 403;
            await httpContext.Response.WriteAsync(new ErrorResponseValueObject()
            {
                Message = "Invalid api key"
            }.ToString());*/
        }
    }
}