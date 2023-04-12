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
            modelBuilder.Entity<Contacto>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Apellido).HasColumnType("varchar(50)");

                entity.Property(e => e.Nombre).HasColumnType("varchar(50)");

                entity.Property(e => e.NroDocumento)
                    .HasColumnType("int")
                    .HasColumnName("Nro_documento");

                entity.Property(e => e.TipoDocumento)
                    .HasColumnType("varchar(30)")
                    .HasColumnName("Tipo_documento");
            });

            modelBuilder.Entity<Telefono>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ContactosId)
                    .HasColumnType("int")
                    .HasColumnName("Contactos_id");

                entity.Property(e => e.NroTelefono)
                    .HasColumnType("int")
                    .HasColumnName("Nro_telefono");

                entity.Property(e => e.TipoTelefono)
                    .HasColumnType("varchar(30)")
                    .HasColumnName("Tipo_telefono");

                entity.HasOne(d => d.Contactos)
                    .WithMany(p => p.Telefonos)
                    .HasForeignKey(d => d.ContactosId);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuario");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Password)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("password");

                entity.Property(e => e.Usuario1)
                    .HasColumnType("varchar(50)")
                    .HasColumnName("usuario");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
