using System;
using System.Collections.Generic;

namespace Contactos.Entities
{
    public partial class Usuario
    {
        public long Id { get; set; }
        public string Usuario1 { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
