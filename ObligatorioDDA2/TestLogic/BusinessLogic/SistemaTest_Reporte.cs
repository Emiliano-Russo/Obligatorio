using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObligatorioDDA2.Models;
using ObligatorioDDA2.Models.Exceptions;
using ObligatorioDDA2.Models.Logic;
using System;
using System.Collections.Generic;
using ObligatorioDDA2.Models.Entidades;
using BusinessLogic.Models.Entidades;
using TestLogic.WebApi;
using Castle.Core.Internal;

namespace TestLogic
{

    public partial class SistemaTest
    {
        [TestMethod]
        public void TestReporteA()
        {
            PuntoTuristico punto = this.GetStandar_PuntoTuristico();
            sistema.IncluirPuntoTuristico(punto);
            Alojamiento hotel = this.CrearAlojamiento("JeyPalace", punto);
            sistema.IncluirAlojamiento(hotel);
            InfoReserva infoReserva = this.CrearInfoReserva(hotel);
            Reserva reserva = sistema.CrearReserva(infoReserva);
            InfoReporte info = this.Construir_Info(punto.Nombre);
            List<Hotel_CantReservas> lista = sistema.ReporteA(info);
            Assert.IsTrue(lista.Count == 1);

            sistema.CrearReserva(infoReserva);
            info = this.Construir_Info(punto.Nombre);
            lista = sistema.ReporteA(info);
            Assert.IsTrue(lista.Count == 2);
           
            sistema.CambiarEstadoReserva(reserva.Codigo, EstadoReserva.Rechazada);
            lista = sistema.ReporteA(info);
            Assert.IsTrue(lista.Count == 1);
            sistema.BorrarReservas();
        }


        [TestMethod]
        public void TestReporteA_Orden()
        {
            PuntoTuristico punto = GetStandar_PuntoTuristico();
            sistema.IncluirPuntoTuristico(punto);
            Alojamiento hotel1 = this.CrearAlojamiento("JeyPalace", punto);
            Alojamiento hotel2 = this.CrearAlojamiento("Felix", punto);
            sistema.IncluirAlojamiento(hotel1);
            sistema.IncluirAlojamiento(hotel2);
            InfoReserva infoReserva1 = this.CrearInfoReserva(hotel1);
            InfoReserva infoReserva12 = this.CrearInfoReserva(hotel1);
            InfoReserva infoReserva2 = this.CrearInfoReserva(hotel2);

            sistema.CrearReserva(infoReserva1);
            sistema.CrearReserva(infoReserva12);
            sistema.CrearReserva(infoReserva2);

            List<Hotel_CantReservas> lista = sistema.ReporteA(Construir_Info(punto.Nombre));

            Assert.IsTrue(lista[0].Hotel == hotel1.Nombre);
            Assert.IsTrue(lista[1].Hotel == hotel2.Nombre);
        }


        [TestMethod]
        public void TestReporteA_Vacio()
        {
            InfoReporte info = this.Construir_Info("asdads");
            List<Hotel_CantReservas> lista = sistema.ReporteA(info);
            Assert.IsTrue(lista.Count == 0);
        }

        [TestMethod]
        public void TestReporteA_NoCruzaFecha()
        {
            PuntoTuristico punto = this.GetStandar_PuntoTuristico();
            sistema.IncluirPuntoTuristico(punto);
            Alojamiento hotel = CrearAlojamiento("JeyPalace", punto);
            sistema.IncluirAlojamiento(hotel);
            InfoReserva infoReserva = this.CrearInfoReserva(hotel);
            sistema.CrearReserva(infoReserva);
            InfoReporte info = new InfoReporte
            {
                NombrePunto = punto.Nombre,
                Inicio = OAR.estadiaVacacional.Entrada.AddDays(20),
                Final = OAR.estadiaVacacional.Salida.AddDays(30)
            };
            List<Hotel_CantReservas> lista = sistema.ReporteA(info);
            Assert.IsTrue(lista.Count == 0);
            sistema.BorrarReservas();
        }


        private InfoReserva CrearInfoReserva(Alojamiento hotel)
        {
            return new InfoReserva
            {
                Nombre = "Hector",
                Apellido = "Rodriguez",
                Email = "hector@gmail.com",
                Hotel = hotel,
                Estadia = OAR.estadiaVacacional
            };
        }

        private PuntoTuristico GetStandar_PuntoTuristico()
        {
            return new PuntoTuristico
            {
                Categoria = new Categoria[] { Categoria.Playas, Categoria.Pueblos },
                Descripcion = "Lugar natural",
                ImgName = new string[] { "imagen" },
                Nombre = "Veriku",
                Region = Region.Corredor_Pajaros_Pintados
            };
        }

        private Alojamiento CrearAlojamiento(string nombre, PuntoTuristico punto)
        {
            return new Alojamiento
            {
                Nombre = nombre,
                Descripcion = "Lugar familiar",
                Direccion = "Av blvr 1234",
                Estrellas = 4,
                NroTelefono = "+598481327",
                PrecioNoche = 80,
                PuntoTuristico = punto,
                InfoDeContacto = "Contactenos al support@" + nombre + ".com.uy",
                SinCapacidad = false
            };
        }

        private InfoReporte Construir_Info(string punto)
        {
            InfoReporte info = new InfoReporte
            {
                Inicio = OAR.estadiaVacacional.Entrada.AddDays(1),
                Final = OAR.estadiaVacacional.Salida,
                NombrePunto = punto
            };
            return info;
        }




    }
}
