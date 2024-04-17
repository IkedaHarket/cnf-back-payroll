using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.ProyectName.API.Domain
{
    public class Class
    {
        public Guid Id { get; set; }
        public string TaxId { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public int ProfileId { get; set; }
        public bool Active { get; set; }
    }
}
