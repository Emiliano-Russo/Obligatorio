﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ObligatorioDDA2.Data;

namespace ObligatorioDDA2.Migrations
{
    [DbContext(typeof(EntidadesContext))]
    [Migration("20201111220950_Puntuaciones")]
    partial class Puntuaciones
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BusinessLogic.Models.Entidades.Repositorio.Puntuacion", b =>
                {
                    b.Property<int>("Key")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comentario")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Puntos")
                        .HasColumnType("int");

                    b.Property<string>("ReservaCodigo")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Key");

                    b.HasIndex("ReservaCodigo");

                    b.ToTable("Puntuacion");
                });

            modelBuilder.Entity("ObligatorioDDA2.Models.Logic.Admin", b =>
                {
                    b.Property<string>("email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("contrasenia")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("email");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("ObligatorioDDA2.Models.Logic.Alojamiento", b =>
                {
                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Estrellas")
                        .HasColumnType("real");

                    b.Property<string>("InfoDeContacto")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NroTelefono")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("PrecioNoche")
                        .HasColumnType("real");

                    b.Property<string>("PuntoTuristicoNombre")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("SinCapacidad")
                        .HasColumnType("bit");

                    b.HasKey("Nombre");

                    b.HasIndex("PuntoTuristicoNombre");

                    b.ToTable("Alojamiento");
                });

            modelBuilder.Entity("ObligatorioDDA2.Models.Logic.Estadia", b =>
                {
                    b.Property<int>("Key")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Entrada")
                        .HasColumnType("datetime2");

                    b.Property<string>("RangoEdadInterno_no_usar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Salida")
                        .HasColumnType("datetime2");

                    b.HasKey("Key");

                    b.ToTable("Estadia");
                });

            modelBuilder.Entity("ObligatorioDDA2.Models.Logic.InfoReserva", b =>
                {
                    b.Property<int>("Key")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EstadiaKey")
                        .HasColumnType("int");

                    b.Property<string>("HotelNombre")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Key");

                    b.HasIndex("EstadiaKey");

                    b.HasIndex("HotelNombre");

                    b.ToTable("InfoReserva");
                });

            modelBuilder.Entity("ObligatorioDDA2.Models.Logic.PuntoTuristico", b =>
                {
                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("CategoriasInterno_no_usar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImgNameInterno_no_usar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Region")
                        .HasColumnType("int");

                    b.HasKey("Nombre");

                    b.ToTable("PuntosTuristicos");
                });

            modelBuilder.Entity("ObligatorioDDA2.Models.Logic.Reserva", b =>
                {
                    b.Property<string>("Codigo")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("EstadoReserva")
                        .HasColumnType("int");

                    b.Property<int?>("InfoReservaKey")
                        .HasColumnType("int");

                    b.HasKey("Codigo");

                    b.HasIndex("InfoReservaKey");

                    b.ToTable("Reserva");
                });

            modelBuilder.Entity("BusinessLogic.Models.Entidades.Repositorio.Puntuacion", b =>
                {
                    b.HasOne("ObligatorioDDA2.Models.Logic.Reserva", "Reserva")
                        .WithMany()
                        .HasForeignKey("ReservaCodigo");
                });

            modelBuilder.Entity("ObligatorioDDA2.Models.Logic.Alojamiento", b =>
                {
                    b.HasOne("ObligatorioDDA2.Models.Logic.PuntoTuristico", "PuntoTuristico")
                        .WithMany()
                        .HasForeignKey("PuntoTuristicoNombre");
                });

            modelBuilder.Entity("ObligatorioDDA2.Models.Logic.InfoReserva", b =>
                {
                    b.HasOne("ObligatorioDDA2.Models.Logic.Estadia", "Estadia")
                        .WithMany()
                        .HasForeignKey("EstadiaKey");

                    b.HasOne("ObligatorioDDA2.Models.Logic.Alojamiento", "Hotel")
                        .WithMany()
                        .HasForeignKey("HotelNombre");
                });

            modelBuilder.Entity("ObligatorioDDA2.Models.Logic.Reserva", b =>
                {
                    b.HasOne("ObligatorioDDA2.Models.Logic.InfoReserva", "InfoReserva")
                        .WithMany()
                        .HasForeignKey("InfoReservaKey");
                });
#pragma warning restore 612, 618
        }
    }
}
