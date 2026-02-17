using Backend.Payroll.API.Application.DTO.Request;
using Backend.Payroll.API.Application.DTO.Response;
using Backend.Payroll.API.Application.Interfaces;
using Backend.Payroll.API.Application.Utils;
using Backend.Payroll.API.Domain.Exceptions;
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(HealthCheckResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(bool))]
        public async Task<IActionResult> HealthCheck()
        {

            try
            {
                var response = await _payrollBusiness.HealthCheck();
                return Ok(response);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return ErrorHandling(ex);
            }
        }

        /// <summary>
        /// Enviar nomina txt
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(bool))]
        public async Task<IActionResult> SendPayroll(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("No se ha seleccionado ningún archivo.");

            if (Path.GetExtension(file.FileName).ToLower() != ".txt")
                return BadRequest("Solo se permiten archivos .txt");

            try
            {
                var response = await _payrollBusiness.SendPayroll(file);
                return Ok();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return ErrorHandling(ex);
            }
        }

        /// <summary>
        /// Get Payroll Status
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("get-status")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(HealthCheckResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(bool))]
        public async Task<IActionResult> GetPayrollStatus(GetPayrollStatusRequest request)
        {

            try
            {
                var response = await _payrollBusiness.GetPayroll(request);
                return Ok(response);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return ErrorHandling(ex);
            }
        }

        /// <summary>
        /// Get Settlements
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("get-settlements")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(HealthCheckResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(bool))]
        public async Task<IActionResult> GetSettlements(GetSettlementsRequest request)
        {

            try
            {
                var response = await _payrollBusiness.GetSettlements(request);
                return Ok(response);
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return ErrorHandling(ex);
            }
        }

        private ObjectResult ErrorHandling(Exception ex)
        {
            string message = $"{ex.Message}";
            // Si es excepcion de rut invalido no se deja log
            if (ex.GetType() == typeof(InvalidRutException)) message = "El rut ingresado no es válido";
            if (ex.GetType() == typeof(NotFoundException)) return NotFound(new DTO.Response.CodeResponse { Message = message });
            return BadRequest(new DTO.Response.CodeResponse { Message = message });
        }
    }
}
