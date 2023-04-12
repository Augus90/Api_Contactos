using System;
using System.Collections.Generic;

namespace Contactos.Entities
{
    public partial class Telefono
    {
        public long Id { get; set; }
        public long? ContactosId { get; set; }
        public string? TipoTelefono { get; set; }
        public long NroTelefono { get; set; }

        public virtual Contacto? Contactos { get; set; }
    }
}
