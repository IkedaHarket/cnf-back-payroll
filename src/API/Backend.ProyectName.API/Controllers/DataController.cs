using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Backend.ProyectName.API.Domain.Exceptions;
using Model = Backend.ProyectName.API.Infraestructure.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Backend.ProyectName.API.Application.Utils;
using System.IO;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using DTO = Backend.ProyectName.API.Application.DTO;
using Newtonsoft.Json.Linq;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using Backend.ServiceName.API.Application.Interfaces;

namespace Backend.ProyectName.API.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly IDataBusiness _dataBusiness;
        private readonly ILogger<DataController> _logger;

        public DataController(IDataBusiness dataBusiness, ILogger<DataController> logger)
        {
            _dataBusiness = dataBusiness;
            _logger = logger;
        }

        /// <summary>
        /// Descripcion del endpoint
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("data")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DTO.Response.DataResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(DTO.Response.ErrorResponse))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(DTO.Response.ErrorResponse))]
        public async Task<IActionResult> GetData(string taxId)
        {
            try
            {
                var taxIdClear = TaxId.FormatClear(taxId);
                DTO.Response.DataResponse response = await _dataBusiness.GetData(taxIdClear);
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

        private ObjectResult ErrorHandling(Exception ex, [CallerMemberName] string callerName = "")
        {
            string message = $"{Assembly.GetEntryAssembly().GetName().Name}:{callerName}: {ex.Message}";
            // Si es excepcion de rut invalido no se deja log
            if (ex.GetType() != typeof(InvalidRutException)) _logger.LogError(ex, message);
            return BadRequest(new DTO.Response.CodeResponse { Message = message });
        }
    }
}
