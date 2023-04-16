using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contactos.Entities
{
    public class Telefono
    {
        [Key]
        public long Id { get; set; }
        [ForeignKey("Contacto")]
        public long? ContactosId { get; set; }
        public string? TipoTelefono { get; set; }
        public long NroTelefono { get; set; }

        public virtual Contacto? Contactos { get; set; }
    }
}
