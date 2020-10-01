using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObligatorioDDA2.Controllers;
using ObligatorioDDA2.Models;

namespace TestLogic.WebApi
{
    [TestClass]
    public class PuntosTuristicos_C_Test
    {

        [TestInitialize]
        public void Inizializar()
        {
            Sistema.GetInstancia().BaseDeDatos = false;
            Sistema.GetInstancia().BorrarPuntosTuristicos();
        }

        [TestMethod]
        public void IndexTest()
        {
            PuntosTuristicosController ptc = new PuntosTuristicosController();
            string actual = ptc.Index();
            string esperado = "Especificar parametros en url";
            Assert.AreEqual(esperado,actual);
        }

        [TestMethod]
        public void BusquedaTest()
        {
            PuntosTuristicosController ptc =new PuntosTuristicosController();
            Sistema.GetInstancia().IncluirPuntoTuristico(OAR.puntaDelEste);
            string actual = ptc.Busqueda(2, null);
            string esperado = "puntos turisticos\rPunta del este: Un lugar muy bello | Region: Este | Categorias: Areas_Protegidas/ Playas/ \r";
            Assert.AreEqual(esperado,actual);
            Sistema.GetInstancia().BorrarPuntosTuristicos();
            actual = ptc.Busqueda(9, null);
            esperado = "region no valida";
            Assert.AreEqual(esperado,actual);
        }

        [TestMethod]
        public void Busqueda2Test()
        {
            Sistema.GetInstancia().IncluirPuntoTuristico(OAR.puntaDelEste);
            PuntosTuristicosController ptc = new PuntosTuristicosController();
            string actual = ptc.Busqueda(2, "3");
            string esperado = "puntos turisticos\rPunta del este: Un lugar muy bello | Region: Este | Categorias: Areas_Protegidas/ Playas/ \r";
            Assert.AreEqual(esperado,actual);
            Sistema.GetInstancia().BorrarPuntosTuristicos();
        }

        [TestMethod]
        public void BusquedaIncorrecta()
        {
            PuntosTuristicosController ptc = new PuntosTuristicosController();
            string actual = ptc.Busqueda(0, "ASDASD");
            string esperado = "Solo se admiten numeros";
            Assert.AreEqual(esperado,actual);
        }

        [TestMethod]
        public void BusquedaIncorrecta2()
        {
            PuntosTuristicosController ptc = new PuntosTuristicosController();
            string actual = ptc.Busqueda(100, "1");
            string esperado = "region no valida";
            Assert.AreEqual(esperado, actual);
            actual = ptc.Busqueda(1, "9");
            esperado = "Categorias no existentes";
            Assert.AreEqual(esperado, actual);
        }


        [TestMethod]
        public void TestAlataPunto()
        {
            PuntosTuristicosController ptc = new PuntosTuristicosController();
            string actual = ptc.Alta(OAR.puntaDelEste);
            string esperado = "Acceso Restringido";
            Assert.AreEqual(esperado,actual);
        }


    }
}
