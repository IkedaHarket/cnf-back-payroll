using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.ProyectName.API.Application.DTO.Request
{
    public class Login
    {
        /// <summary>
        /// rut del cliente con dígito verificador, puede venir con cualquier formato
        /// </summary>
        public string TaxId { get; set; }

        /// <summary>
        /// Contraseña del cliente
        /// </summary>
        public string Password { get; set; }
    }
}