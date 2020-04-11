using FluentValidation;
using MicroBackend.Domain.Core.Services.Constants;
using MicroBackend.Domain.Core.Services.Results;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MicroBackend.Domain.Core.Extensions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(httpContext, e);
            }
        }

        private Task HandleExceptionAsync(HttpContext httpContext, Exception e)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            int code = GlobalErrors.UnknownError;

            if (e.GetType() == typeof(ValidationException))
            {
                code = GlobalErrors.NotValidation;
            }

            return httpContext.Response.WriteAsync(JsonConvert.SerializeObject(
                    new ErrorDataResult<string>(
                        data: null,
                        message: e.Message,
                        code: code
                    )).ToString());
        }
    }
}
