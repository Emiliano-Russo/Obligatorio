using BusinessLogic.Models.Entidades.Repositorio;
using Microsoft.EntityFrameworkCore;
using ObligatorioDDA2.Models.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObligatorioDDA2.Data
{
    public class EntidadesContext : DbContext
    {

        public DbSet<Alojamiento> Alojamientos { get; set; }

        public DbSet<PuntoTuristico> PuntosTuristicos { get; set; }

        public DbSet<InfoReserva> InfoReservas { get; set; }

        public DbSet<Reserva> Reservas { get; set; }

        public DbSet<Admin> Admins { get; set; }

        public DbSet<Puntuacion> Puntuacion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Data Source=DESKTOP-3MHID5U\\SQLEXPRESS;Initial Catalog=prueba;Integrated Security=True");
        }

    }
}
