using System;
using System.Collections.Generic;
using System.Text;
using ObligatorioDDA2.Models.Logic;

namespace TestLogic.WebApi
{
    //Objetos de acceso rapido
    public static class OAR
    {
       public static Estadia estadiaVacacional = new Estadia
        {
            Entrada = DateTime.Now.AddDays(3),
            Salida = DateTime.Now.AddDays(15),
            RangoEdades = new FaseEdad[] { FaseEdad.Ninio, FaseEdad.Adulto, FaseEdad.Adulto }
        };

       public static PuntoTuristico puntaDelEste = new PuntoTuristico
       {
           Categoria = new Categoria[] { Categoria.Areas_Protegidas, Categoria.Playas },
           Descripcion = "Un lugar muy bello",
           Nombre = "Punta del este",
           Region = Region.Este
       };

       public static Alojamiento hotel = new Alojamiento
       {
           Nombre = "Crystal",
           Descripcion = "Un hotel familiar, cerca de las atracciones turisticas",
           Direccion = "Av Bulvevar 123",
           Estrellas = 5,
           PrecioNoche = 100,
           PuntoTuristico = puntaDelEste,
           NroTelefono = "097441254",
           InfoDeContacto = "Contactenos en www.crystal.com",
           SinCapacidad = false
       };

    }
}
