using System;
using System.Collections.Generic;
using Contactos.Entities;

namespace Contactos.Entities
{
    public partial class Usuario
    {
        public Usuario()
        {
            List<Contacto> Contactos = new List<Contacto>();
        }

        public long Id { get; set; }
        public string Usuario1 { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Rol {get; set;} = "usuario";
        public List<Contacto>? Contactos {get; set;}
    }
}
