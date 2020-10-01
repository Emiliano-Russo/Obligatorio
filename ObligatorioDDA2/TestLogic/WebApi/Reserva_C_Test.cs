using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObligatorioDDA2.Controllers;
using ObligatorioDDA2.Models;
using ObligatorioDDA2.Models.Logic;

namespace TestLogic.WebApi
{
    [TestClass]
    public class Reserva_C_Test
    {

        [TestInitialize]
        public void Inicializar()
        {
            Sistema.GetInstancia().BaseDeDatos = false;
            Sistema.GetInstancia().BorrarReservas();
        }

        [TestMethod]
        public void Index()
        {
            ReservaController rc = new ReservaController();
            string actual = rc.Index();
            string esperado = "Por favor ingrese los datos";
            Assert.AreEqual(esperado,actual);
        }

        [TestMethod]
        public void ReservaTest()
        {
            ReservaController rc = new ReservaController();

            InfoReserva info = new InfoReserva
            {
                Nombre = "Hector",
                Apellido = "Suarez",
                Email = "hector@gmail.com",
                Estadia = OAR.estadiaVacacional,
                Hotel = OAR.hotel
            };

            string actual = rc.Reservar(info);
            string esperada = "Punto turistico no existe";
            Assert.AreEqual(esperada,actual);
        }

        [TestMethod]
        public void Reserva2Test()
        {
            ReservaController rc = new ReservaController();
            InfoReserva info = new InfoReserva
            {
                Nombre = "Hector",
                Apellido = "Suarez",
                Email = "hector@gmail.com",
                Estadia = OAR.estadiaVacacional,
                Hotel = OAR.hotel
            };
            Sistema.GetInstancia().IncluirPuntoTuristico(OAR.puntaDelEste);
            Sistema.GetInstancia().IncluirAlojamiento(OAR.hotel);
            string actual = rc.Reservar(info);
            string codigo = actual.Substring(15, 11);
            string esperada = "codigo reserva:"+codigo+"| Nro Telefono: 097441254 | Info:Contactenos en www.crystal.com";
            Assert.AreEqual(esperada, actual);
        }

        [TestMethod]
        public void CambiarEstadoTest()
        {
            Sistema.GetInstancia().BorrarReservas();
            ReservaController rc = new ReservaController();
            InfoReserva info = new InfoReserva
            {
                Nombre = "Hector",
                Apellido = "Suarez",
                Email = "hector@gmail.com",
                Estadia = OAR.estadiaVacacional,
                Hotel = OAR.hotel
            };
            Sistema.GetInstancia().IncluirPuntoTuristico(OAR.puntaDelEste);
            Sistema.GetInstancia().IncluirAlojamiento(OAR.hotel);
            Reserva reserva = Sistema.GetInstancia().CrearReserva(info);
            string actual = rc.CambiarEstado(reserva.Codigo, 3);
            string esperado = "Acceso Restringido";
            Assert.AreEqual(esperado,actual);

            esperado = "Nombre: Hector | Estado: Creada | Descripcion: Codigo reservado por mail: hector@gmail.com";
            actual = rc.Estado(reserva.Codigo);
            Assert.AreEqual(actual,esperado);
        }

        [TestMethod]
        public void CambiarEstadoTest2()
        {
            ReservaController rc = new ReservaController();
            string actual = rc.Estado("asd");
            string esperado = "No existe asd en nuestro sistema";
            Assert.AreEqual(esperado,actual);
        }
    }
}
