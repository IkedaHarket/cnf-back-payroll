using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.ProyectName.API.Domain.Exceptions
{
    public class RetriesException : Exception
    {
        public RetriesException() : base() { }
        public RetriesException(string message) : base(message) { }
        public RetriesException(string message, Exception inner) : base(message, inner) { }
    }
}
