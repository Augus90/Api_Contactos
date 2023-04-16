using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contactos.Entities;

namespace Contactos.Dto
{
    public class ContactoDTO
    {
        public string Nombre { get; set; } = null!;
        public string? Apellido { get; set; }
        public string? TipoDocumento { get; set; }
        public long NroDocumento { get; set; }
        public virtual ICollection<Telefono>? Telefonos { get; set; }
    }
}