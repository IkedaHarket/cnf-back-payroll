using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.ProyectName.API.Domain.Exceptions
{
    public class NotFoundPasswordException : Exception
    {
        public NotFoundPasswordException() { }
        public NotFoundPasswordException(string message) : base(message) { }
        public NotFoundPasswordException(string message, Exception inner) : base(message, inner) { }
    }
}
