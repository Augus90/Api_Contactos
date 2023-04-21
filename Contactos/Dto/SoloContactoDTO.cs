using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Contactos.Dto
{
    public class SoloContactoDTO
    {
        public string Nombre { get; set; } = null!;
        public string? Apellido { get; set; }
        public string? TipoDocumento { get; set; }
        public long NroDocumento { get; set; }
    }
}