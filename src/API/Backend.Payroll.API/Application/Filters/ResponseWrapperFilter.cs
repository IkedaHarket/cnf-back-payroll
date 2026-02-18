using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Backend.Payroll.API.Application.DTO.Response;
using System.Net;

namespace Backend.Payroll.API.Application.Filters
{
    public class ResponseWrapperFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (context.Exception == null && context.Result is ObjectResult objectResult)
            {
                if (objectResult.Value != null &&
                    objectResult.Value.GetType().IsGenericType &&
                    objectResult.Value.GetType().GetGenericTypeDefinition() == typeof(BaseResponse<>))
                {
                    return;
                }

                var response = new BaseResponse<object>
                {
                    Success = true,
                    Message = "Operación exitosa",
                    Data = objectResult.Value,
                };

                objectResult.Value = response;
            }
        }
    }
}