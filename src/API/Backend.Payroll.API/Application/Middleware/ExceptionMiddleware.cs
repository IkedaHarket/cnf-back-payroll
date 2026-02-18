using Backend.Payroll.API.Application.DTO.Response;
using Backend.Payroll.API.Domain.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Backend.Payroll.API.Application.Middleware
{
    public class ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await next(httpContext);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Ocurrió un error no controlado");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            var response = new BaseResponse<object>
            {
                Success = false,
                Message = exception.Message,
                Errors = new List<string> { exception.Message, exception?.InnerException?.ToString(), exception?.StackTrace }
            };

            switch (exception)
            {
                case InfraestructureException: 
                case RepositoryException: 
                    context.Response.StatusCode = (int)HttpStatusCode.BadGateway;
                    break;
                case NotFoundException:
                    context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                case BusinessException:
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                default:
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }

            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Formatting = Formatting.Indented 
            };

            var jsonResponse = JsonConvert.SerializeObject(response, settings);

            return context.Response.WriteAsync(jsonResponse);
        }
    }
}
