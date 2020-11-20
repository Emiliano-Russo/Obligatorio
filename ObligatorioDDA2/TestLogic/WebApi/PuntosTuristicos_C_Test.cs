using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Microsoft.AspNetCore.Mvc;
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
            string actual = System.Text.Json.JsonSerializer.Serialize(ptc.Busqueda(2, null).Value);
            string esperado = "[{\"Nombre\":\"Punta del este\",\"Descripcion\":\"Un lugar muy bello\",\"Region\":2," +
                "\"Categoria\":[2,3],\"CategoriasInterno_no_usar\":\"Areas_Protegidas;Playas\",\"ImgName\":null,\"ImgNameInterno_no_usar\":null}]";
            Assert.AreEqual(esperado,actual);
            Sistema.GetInstancia().BorrarPuntosTuristicos();
            actual = System.Text.Json.JsonSerializer.Serialize(ptc.Busqueda(9, null).Value);
            esperado = "\"region no valida\"";
            Assert.AreEqual(esperado,actual);
        }

        [TestMethod]
        public void Busqueda2Test()
        {
            Sistema.GetInstancia().IncluirPuntoTuristico(OAR.puntaDelEste);
            PuntosTuristicosController ptc = new PuntosTuristicosController();
            string actual = System.Text.Json.JsonSerializer.Serialize(ptc.Busqueda(2, "3").Value);
            string esperado = "[{\"Nombre\":\"Punta del este\"," +
                "\"Descripcion\":\"Un lugar muy bello\",\"Region\":2," +
                "\"Categoria\":[2,3]," +
                "\"CategoriasInterno_no_usar\":\"Areas_Protegidas;Playas\"," +
                "\"ImgName\":null,\"ImgNameInterno_no_usar\":null}]";
            Assert.AreEqual(esperado,actual);
            Sistema.GetInstancia().BorrarPuntosTuristicos();
        }

        [TestMethod]
        public void BusquedaIncorrecta()
        {
            PuntosTuristicosController ptc = new PuntosTuristicosController();
            string actual = System.Text.Json.JsonSerializer.Serialize(ptc.Busqueda(0, "ASDASD").Value);
            string esperado = "\"Solo se admiten numeros\"";
            Assert.AreEqual(esperado,actual);
        }

        [TestMethod]
        public void BusquedaIncorrecta2()
        {
            PuntosTuristicosController ptc = new PuntosTuristicosController();
            string actual = System.Text.Json.JsonSerializer.Serialize(ptc.Busqueda(100, "1").Value);
            string esperado = "\"region no valida\"";
            Assert.AreEqual(esperado, actual);
            actual = System.Text.Json.JsonSerializer.Serialize(ptc.Busqueda(1, "9").Value);
            esperado = "\"Categorias no existentes\"";
            Assert.AreEqual(esperado, actual);
        }


        [TestMethod]
        public void TestAlataPunto()
        {
            PuntosTuristicosController ptc = new PuntosTuristicosController();
            string actual = System.Text.Json.JsonSerializer.Serialize(ptc.Alta(OAR.puntaDelEste).Value);
            string esperado = "\"Acceso Restringido\"";
            Assert.AreEqual(esperado,actual);
        }


    }
}
