using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contactos.Entities;

namespace Contactos.Dto
{
    public class TelefonoContactoDTO
    {
        public string? TipoTelefono { get; set; }
        public long NroTelefono { get; set; }
        public virtual Contacto? Contactos { get; set; }

    }
}