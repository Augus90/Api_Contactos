using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contactos.Entities
{
    public class Contacto
    {
        public Contacto()
        {
            Telefonos = new List<Telefono>();
        }

        [Key]
        public long Id { get; set; }
        [ForeignKey("Usuario")]
        public long UserId { get; set;}
        public virtual Usuario Usuarios {get; set;}
        public string Nombre { get; set; } = null!;
        public string? Apellido { get; set; }
        public string? TipoDocumento { get; set; }
        public long NroDocumento { get; set; }

        public List<Telefono>? Telefonos { get; set; }
    }
}
