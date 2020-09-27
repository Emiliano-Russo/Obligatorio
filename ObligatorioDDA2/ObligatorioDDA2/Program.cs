using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ObligatorioDDA2.Models;
using ObligatorioDDA2.Models.Logic;

namespace ObligatorioDDA2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            AgregarDatos();
            CreateHostBuilder(args).Build().Run();         
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static void AgregarDatos()
        {
            Sistema sistema = Sistema.GetInstancia();

            PuntoTuristico punto = new PuntoTuristico
            {
                Nombre = "Punta del este",
                Region = Region.Este,
                Categoria = new Categoria[] { Categoria.Playas,Categoria.Ciudades },
                Descripcion = "Una playa hermosa"
            };
            sistema.IncluirPuntoTuristico(punto);

            Alojamiento hotel = new Alojamiento
            {
                Descripcion = "Un buen alojamiento familiar",
                Direccion = "Av Imagination 741",
                Estrellas = 5,
                InfoDeContacto = "Contactenos por support@radison.com",
                Nombre = "Radison",
                NroTelefono = "475024381",
                PrecioNoche = 75,
                PuntoTuristico = punto,
                SinCapacidad = false
            };
            sistema.IncluirAlojamiento(hotel);

            Admin a = new Admin
            {
                email = "emi@gmail.com",
                contrasenia = "1234"
            };
            sistema.AgregarAdmin(a);
        }
    }
}
