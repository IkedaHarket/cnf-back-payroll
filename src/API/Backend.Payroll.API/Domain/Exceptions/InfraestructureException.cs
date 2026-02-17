using System;

namespace Backend.Payroll.API.Domain.Exceptions
{
    public class InfraestructureException : Exception
    {
        public InfraestructureException() { }
        public InfraestructureException(string message) : base(message) { }
        public InfraestructureException(string message, Exception inner) : base(message, inner) { }
    }
}
