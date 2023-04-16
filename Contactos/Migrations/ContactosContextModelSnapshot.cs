﻿// <auto-generated />
using System;
using Contactos.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Contactos.Migrations
{
    [DbContext(typeof(ContactosContext))]
    partial class ContactosContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.5");

            modelBuilder.Entity("Contactos.Entities.Contacto", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Apellido")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<long>("NroDocumento")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TipoDocumento")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Contactos");
                });

            modelBuilder.Entity("Contactos.Entities.Telefono", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<long?>("ContactosId")
                        .HasColumnType("INTEGER");

                    b.Property<long>("NroTelefono")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TipoTelefono")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ContactosId");

                    b.ToTable("Telefonos");
                });

            modelBuilder.Entity("Contactos.Entities.Usuario", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Usuario1")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Contactos.Entities.Telefono", b =>
                {
                    b.HasOne("Contactos.Entities.Contacto", "Contactos")
                        .WithMany("Telefonos")
                        .HasForeignKey("ContactosId");

                    b.Navigation("Contactos");
                });

            modelBuilder.Entity("Contactos.Entities.Contacto", b =>
                {
                    b.Navigation("Telefonos");
                });
#pragma warning restore 612, 618
        }
    }
}
