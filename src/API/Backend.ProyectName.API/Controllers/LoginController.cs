using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using DTO =Backend.ProyectName.API.Application.DTO;
using Backend.ProyectName.API.Application.Utils;
using Backend.ProyectName.API.Domain;
using Backend.ProyectName.API.Domain.Exceptions;
using Backend.ProyectName.API.Infraestructure.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Backend.ServiceName.API.Application.Interfaces;

namespace Backend.ProyectName.API.Controllers
{
    [AllowAnonymous]
    [Route("login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAuthenticateBusiness _authenticateBusiness;
        private readonly ILogger<LoginController> _logger;

        public LoginController(IAuthenticateBusiness authenticateBusiness, ILogger<LoginController> logger)
        {
            _authenticateBusiness = authenticateBusiness;
            _logger = logger;
        }

        /// <summary>
        /// Metodo que permite logearse 
        /// </summary>
        /// <param name="login">Objeto con los parametros para el login</param>
        /// <returns></returns>
        [HttpPost]
        [Route("auth")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DTO.Response.AuthenticationResult))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(DTO.Response.ErrorResponse))]
        public async Task<IActionResult> Authenticate([FromBody] DTO.Request.Login login)
        {
            try
            {
                if (login == null) return BadRequest(new DTO.Response.CodeResponse { Message = "El objeto login no puede ser nulo", Result = "Error" });

                if (!TaxId.IsValid(login.TaxId)) throw new InvalidRutException(login.TaxId);

                var response = await _authenticateBusiness.AuthenticateUser(TaxId.FormatClear(login.TaxId), login.Password);

                return Ok(response);
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