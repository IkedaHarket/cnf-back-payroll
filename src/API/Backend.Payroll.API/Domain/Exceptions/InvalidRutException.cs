using System;

namespace Backend.Payroll.API.Domain.Exceptions
{
    public class InvalidRutException : Exception
    {
        public InvalidRutException() : base("Rut inválido") { }

        /// <summary>
        /// Pasar el rut como parámetro
        /// </summary>
        /// <param name="rutWithDv"></param>
        public InvalidRutException(string rutWithDv) : base($"Rut {rutWithDv} inválido") { }
        public InvalidRutException(string rutWithDv, Exception inner) : base($"Rut {rutWithDv} inválido", inner) { }
    }
}
