using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Contactos.Entities;

namespace Contactos.Context
{
    public partial class ContactosContext : DbContext
    {
        public ContactosContext()
        {
        }

        public ContactosContext(DbContextOptions<ContactosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Contacto> Contactos { get; set; } = null!;
        public virtual DbSet<Telefono> Telefonos { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contacto>()
                .HasMany(c => c.Telefonos)
                .WithOne(t => t.Contactos)
                .HasForeignKey(f => f.ContactosId);

            modelBuilder.Entity<Usuario>().HasData(
                new Usuario{
                    Id = 1,
                    Usuario1 = "Admin",
                    Password = "Password"         
                }
            );
            modelBuilder.Entity<Contacto>().HasData(
                new Contacto{
                    Id = 1,
                    Nombre = "Mario",
                    Apellido = "Santos",
                    TipoDocumento = "DNI",
                    NroDocumento = 12345678
                },
                new Contacto{
                    Id = 2,
                    Nombre = "Emilio",
                    Apellido = "Ravenna",
                    TipoDocumento = "DNI",
                    NroDocumento = 23456789
                }
            );
            modelBuilder.Entity<Telefono>().HasData(
                new Telefono{
                    Id = 1,
                    ContactosId = 1,
                    TipoTelefono = "Movil",
                    NroTelefono = 1566778899
                },
                new Telefono{
                    Id = 2,
                    ContactosId = 1,
                    TipoTelefono = "Movil",
                    NroTelefono = 1599887766
                },
                new Telefono{
                    Id = 3,
                    ContactosId = 2,
                    TipoTelefono = "Movil",
                    NroTelefono = 1599887766
                }
            );
        }
    }
}
