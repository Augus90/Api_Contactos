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

            modelBuilder.Entity<Usuario>()
                .HasMany(c => c.Contactos)
                .WithOne(t => t.Usuarios)
                .HasForeignKey(f => f.UserId);
        }
    }
}
