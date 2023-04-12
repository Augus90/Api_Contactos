using System;
using System.Collections.Generic;

namespace Contactos.Entities
{
    public partial class Contacto
    {
        public Contacto()
        {
            Telefonos = new HashSet<Telefono>();
        }

        public long Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string? Apellido { get; set; }
        public string? TipoDocumento { get; set; }
        public long NroDocumento { get; set; }

        public virtual ICollection<Telefono> Telefonos { get; set; }
    }
}
