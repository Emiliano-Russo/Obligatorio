using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ObligatorioDDA2.Controllers;
using ObligatorioDDA2.Controllers.EntidadesAlRecibir;
using ObligatorioDDA2.Models;
using ObligatorioDDA2.Models.Logic;
using System.Collections.Specialized;

namespace TestLogic.WebApi
{
    [TestClass]
    public class Hosepdaje_C_Test
    {
        Sistema sistema = Sistema.GetInstancia();
        

        [TestInitialize]
        public void Inicializar()
        {
            sistema.BorrarPuntosTuristicos();
            sistema.IncluirPuntoTuristico(OAR.puntaDelEste);
            sistema.IncluirAlojamiento(OAR.hotel);
        }

        [TestMethod]
        public void IndexTest()
        {
            HospedajesController hc = new HospedajesController();
            string resultado = hc.Index().ToLower();
            string esperado = "faltan parametros";

            Assert.AreEqual(esperado,resultado);
        }

        [TestMethod]
        public void TestBusqueda()
        {
            HospedajesController hc = new HospedajesController();
            Estancia estancia = new Estancia
            {
                Estadia = OAR.estadiaVacacional,
                Punto = OAR.puntaDelEste
            };
            string resultado = "";//hc.Busqueda(estancia);
            string esperado = OAR.hotel.ToString() +"Precio total: " + 3000 + " $"+ "\n";
            Assert.IsTrue(resultado.Equals(esperado));
        }

        [TestMethod]
        public void TestBusquedaNull()
        {
            HospedajesController hc = new HospedajesController();
            Estancia e = new Estancia
            {
                Estadia = OAR.estadiaVacacional,
                Punto = null
            };
            string resultado = "";//hc.Busqueda(e);
            string esperado = "campos nulos";
            Assert.AreEqual(esperado,resultado);
        }


        [TestMethod]
        public void TestModificacion()
        {
            HospedajesController hc = new HospedajesController();
            JsonResult resultado = hc.Modificar("asdjklas", true);
            string esperado = "Acceso Restringido";
            Assert.AreEqual(esperado,resultado);
        }

        
        [TestMethod]
        public void TestModificacionLogin()
        {
            HospedajesController hc = new HospedajesController();
            JsonResult resultado = hc.Modificar("asdsda", true);
            string esperado = "Acceso Restringido";
            Assert.AreEqual(esperado,resultado);
        }

        [TestMethod]
        public void TestAltaHospedaje()
        {
            HospedajesController hc = new HospedajesController();
            string actual = "";//hc.Alta(OAR.hotel);
            string esperado = "Acceso Restringido";
            Assert.AreEqual(esperado,actual);
        }

        [TestMethod]
        public void TestBajaHospedaje()
        {
            HospedajesController hc = new HospedajesController();
            string actual = "";//hc.Baja(OAR.hotel.Nombre);
            string esperado = "Acceso Restringido";
            Assert.AreEqual(esperado,actual);
        }

    }
}
