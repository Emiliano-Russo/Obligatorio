using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObligatorioDDA2.Models;
using ObligatorioDDA2.Models.Exceptions;
using ObligatorioDDA2.Models.Logic;
using System;
using System.Collections.Generic;

namespace TestLogic
{
    public partial class SistemaTest
    {

        //CrearReserva
        [TestMethod]
       [ExpectedException(typeof(ExcepcionAlojamientoInvalido))]
        public void CrearReserva_AlojamientoInvalido()
        {
            InfoReserva info = new InfoReserva
            {
                Apellido = "Gonzalez",
                Nombre = "Juan",
                Email = "Juan@antel.com",
                Hotel = new Alojamiento(),
                Estadia = estadiaVacacional
            };
            sistema.CrearReserva(info);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionEstadiaInvalido))]
        public void CrearReserva_EstadiaInvalido()
        {
            Alojamiento Radison = new Alojamiento
            {
                Descripcion = "Un lugar con ambiente familiar",
                Direccion = "Avenida 123",
                Estrellas = 3f,
                InfoDeContacto = "Bienvenido al hotel",
                Nombre = "Radison",
                NroTelefono = "092777555",
                PrecioNoche = 100,
                PuntoTuristico = puntaDelEste,
                SinCapacidad = false
            };
            InfoReserva info = new InfoReserva
            {
                Apellido = "Gonzalez",
                Nombre = "Juan",
                Email = "Juan@antel.com",
                Hotel = Radison,
                Estadia = null
            };
            sistema.CrearReserva(info);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionInfoInvalida))]
        public void CrearReserva_InfoValida1()
        {
            Alojamiento Radison = new Alojamiento
            {
                Descripcion = "Un lugar con ambiente familiar",
                Direccion = "Avenida 123",
                Estrellas = 4.5f,
                InfoDeContacto = "Bienvenido al hotel",
                Nombre = "Radison",
                NroTelefono = "092777555",
                PrecioNoche = 100,
                PuntoTuristico = puntaDelEste,
                SinCapacidad = false
            };
            InfoReserva info = new InfoReserva
            {
                Apellido = "",
                Nombre = "Juan",
                Email = "Juan@antel.com",
                Hotel = Radison,
                Estadia = estadiaVacacional
            };
            sistema.CrearReserva(info);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionInfoInvalida))]
        public void CrearReserva_InfoValida2()
        {
            Alojamiento Radison = new Alojamiento
            {
                Descripcion = "Un lugar con ambiente familiar",
                Direccion = "Avenida 123",
                Estrellas = 4.5f,
                InfoDeContacto = "Bienvenido al hotel",
                Nombre = "Radison",
                NroTelefono = "092777555",
                PrecioNoche = 100,
                PuntoTuristico = puntaDelEste,
                SinCapacidad = false
            };
            InfoReserva info = new InfoReserva
            {
                Apellido = "Gonzalez",
                Nombre = "Juan",
                Email = "",
                Hotel = Radison,
                Estadia = estadiaVacacional
            };
            sistema.CrearReserva(info);
        }

        //ConsultarReserva
        [TestMethod]
        [ExpectedException(typeof(ExcepcionInfoInvalida))]
        public void ConsutlarReserva_InfoInvalida()
        {
            sistema.ConsultarReserva("ASDdas");
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionInfoInvalida))]
        public void ConsutlarReserva_InfoInvalida2()
        {
            sistema.ConsultarReserva(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionInfoInvalida))]
        public void ConsutlarReserva_InfoInvalida3()
        {
            sistema.ConsultarReserva("");
        }

        [TestMethod]
        public void ConsutlarReserva_Valido()
        {
            BorrarHotelesYPuntos();
            sistema.BorrarReservas();
            Alojamiento Radison = new Alojamiento
            {
                Descripcion = "Un lugar con ambiente familiar",
                Direccion = "Avenida 123",
                Estrellas = 4.5f,
                InfoDeContacto = "Bienvenido al hotel",
                Nombre = "Radison",
                NroTelefono = "092777555",
                PrecioNoche = 100,
                PuntoTuristico = puntaDelEste,
                SinCapacidad = false
            };
            sistema.IncluirPuntoTuristico(puntaDelEste);
            sistema.IncluirAlojamiento(Radison);

            InfoReserva info = new InfoReserva
            {
                Nombre = "Guillermo",
                Apellido = "Suarez",
                Hotel = Radison,
                Estadia = estadiaVacacional,
                Email = "guille@suarez.com"
            };
            Reserva reserva = sistema.CrearReserva(info);
            EstadoReserva estado = sistema.ConsultarReserva(reserva.Codigo);
            Assert.AreEqual(estado, EstadoReserva.Creada);
            sistema.BorrarReservas();
        }


        //Cambiar estado reserva
        [TestMethod]
        [ExpectedException(typeof(ExcepcionInfoInvalida))]
        public void CambiarEstadoReserva_CodigoInexistente()
        {
            sistema.CambiarEstadoReserva("asd", EstadoReserva.Expirada);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionInfoInvalida))]
        public void CambiarEstadoReserva_CodigoInexistente2()
        {
            sistema.CambiarEstadoReserva("", EstadoReserva.Expirada);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionInfoInvalida))]
        public void CambiarEstadoReserva_CodigoInexistente3()
        {
            sistema.CambiarEstadoReserva(null, EstadoReserva.Expirada);
        }

       [TestMethod]
        public void CambiarEstadoReserva_Valido()
        {
            BorrarHotelesYPuntos();
            
            Alojamiento Radison = new Alojamiento
            {
                Descripcion = "Un lugar con ambiente familiar",
                Direccion = "Avenida 123",
                Estrellas = 4.5f,
                InfoDeContacto = "Bienvenido al hotel",
                Nombre = "Radison",
                NroTelefono = "092777555",
                PrecioNoche = 100,
                PuntoTuristico = puntaDelEste,
                SinCapacidad = false
            };
            sistema.IncluirPuntoTuristico(puntaDelEste);
            sistema.IncluirAlojamiento(Radison);

            InfoReserva info = new InfoReserva
            {
                Nombre = "Guillermo",
                Apellido = "Suarez",
                Hotel = Radison,
                Estadia = estadiaVacacional,
                Email = "guille@suarez.com"
            };
            Reserva reserva = sistema.CrearReserva(info);
            Assert.IsTrue(reserva.EstadoReserva == EstadoReserva.Creada);
            sistema.CambiarEstadoReserva(reserva.Codigo,EstadoReserva.Pendiente_Pago);
            EstadoReserva estadoNuevo = sistema.ConsultarReserva(reserva.Codigo);
            Assert.IsTrue(estadoNuevo == EstadoReserva.Pendiente_Pago);
        }

    }
}
