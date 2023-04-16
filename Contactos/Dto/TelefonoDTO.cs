using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contactos.Entities;

namespace Contactos.Dto
{
    public class TelefonoDTO
    {
        // public long? ContactosId { get; set; }
        public string? TipoTelefono { get; set; }
        public long NroTelefono { get; set; }
    }
}