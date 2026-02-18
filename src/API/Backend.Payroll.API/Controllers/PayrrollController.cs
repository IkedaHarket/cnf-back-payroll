using Backend.Payroll.API.Application.DTO.Request;
using Backend.Payroll.API.Application.DTO.Response;
using Backend.Payroll.API.Application.Interfaces;
using Backend.Payroll.API.Application.Utils;
using Backend.Payroll.API.Domain.Exceptions;
using Backend.Payroll.API.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
using DTO = Backend.Payroll.API.Application.DTO;

namespace Backend.Payroll.API.Controllers
{
    [Route("payroll")]
    [ApiController]
    public class PayrollController(
        IPayrollBusiness _payrollBusiness
        ): ControllerBase
    {

        /// <summary>
        /// Health Check
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("health")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponse<HealthCheckResponse>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BaseResponse<object>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BaseResponse<object>))]
        public async Task<IActionResult> HealthCheck()
        {
            var response = await _payrollBusiness.HealthCheck();
            return Ok(response);
        }

        /// <summary>
        /// Enviar nomina txt
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponse<PayrollDocument>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BaseResponse<object>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BaseResponse<object>))]
        public async Task<IActionResult> SendPayroll(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No se ha seleccionado ningún archivo.");

            if (Path.GetExtension(file.FileName).ToLower() != ".txt")
                return BadRequest("Solo se permiten archivos .txt");

            var response = await _payrollBusiness.SendPayroll(file);
            return Ok(response);
        }

        /// <summary>
        /// Get Payroll Status
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("get-status")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponse<PayrollDocument>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BaseResponse<object>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BaseResponse<object>))]
        public async Task<IActionResult> GetPayrollStatus(GetPayrollStatusRequest request)
        {
            var response = await _payrollBusiness.GetPayroll(request);
            return Ok(response);
        }

        /// <summary>
        /// Get Settlements
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("get-settlements")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseResponse<Settlement>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(BaseResponse<object>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(BaseResponse<object>))]
        public async Task<IActionResult> GetSettlements(GetSettlementsRequest request)
        {
            var response = await _payrollBusiness.GetSettlements(request);
            return Ok(response);
        }

    }
}
