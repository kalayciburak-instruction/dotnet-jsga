using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Core.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (DbUpdateException dbUpdateException)
            {
                await HandleDbUpdateExceptionAsync(context, dbUpdateException);
            }
            catch (Exception exception)
            {
                await HandleGeneralExceptionAsync(context, exception);
            }
        }

        private async Task HandleDbUpdateExceptionAsync(HttpContext context, DbUpdateException exception)
        {
            await WriteExceptionResponseAsync(context,
                                              StatusCodes.Status409Conflict,
                                              exception.GetType().Name,
                                              "Veritabanında bir hata oluştu.");
        }

        private async Task HandleGeneralExceptionAsync(HttpContext context, Exception exception)
        {
            await WriteExceptionResponseAsync(context,
                                              StatusCodes.Status500InternalServerError,
                                              exception.GetType().Name,
                                              exception.Message);
        }

        private async Task WriteExceptionResponseAsync(HttpContext context, int httpStatus, string exceptionType, string exceptionMessage)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = httpStatus;
            var result = new ExceptionResult
            {
                Type = exceptionType,
                Message = exceptionMessage
            };

            var json = JsonConvert.SerializeObject(result);
            await context.Response.WriteAsync(json);
        }
    }
}
