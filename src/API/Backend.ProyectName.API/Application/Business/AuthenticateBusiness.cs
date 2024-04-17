using DTO = Backend.ProyectName.API.Application.DTO;
using Backend.ProyectName.API.Domain;
using Backend.ProyectName.API.Infraestructure.Interfaces;
using Mapster;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading.Tasks;
using Backend.ProyectName.API.Application.Utils;
using System.Drawing;
using System.Collections.Generic;
using Backend.ServiceName.API.Application.Interfaces;

namespace Backend.ProyectName.API.Application.Business
{
    public class AuthenticateBusiness : IAuthenticateBusiness
    {
        private readonly ICustomerAccountService _customerAccountService;
        private readonly IConfiguration _configService;

        public AuthenticateBusiness(ICustomerAccountService customerAccountService, IConfiguration configuration)
        {
            _customerAccountService = customerAccountService;
            _configService = configuration;
        }

        public async Task<DTO.Response.AuthenticationResult> AuthenticateUser(string taxId, string password)
        {
            var authResponse = await _customerAccountService.Authenticate(taxId, password);

            var resp = authResponse.Adapt<DTO.Response.AuthenticationResult>();

            if (!resp.Active) throw new Exception("La cuenta del cliente está inactiva.");

            return resp;
        }
    }
}