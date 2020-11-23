using BusinessLogic.Models.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ObligatorioDDA2.Controllers;
using ObligatorioDDA2.Controllers.EntidadesAlRecibir;
using ObligatorioDDA2.Models;
using ObligatorioDDA2.Models.Exceptions;
using ObligatorioDDA2.Models.Logic;
using System.Collections.Specialized;
using WebApi.Controllers.EntidadesAlRecibir;

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

            Assert.AreEqual(esperado, resultado);
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
            string resultado = System.Text.Json.JsonSerializer.Serialize(hc.Busqueda(estancia).Value);
            string esperado = "[{\"Alojamiento\":{\"Nombre\":\"Crystal\",\"Estrellas\":5,\"PuntoTuristico\"" +
                ":{\"Nombre\":\"Punta del este\",\"Descripcion\":\"Un lugar muy bello\",\"Region\":2,\"Categoria\":[2,3]," +
                "\"CategoriasInterno_no_usar\":\"Areas_Protegidas;Playas\",\"ImgName\":null,\"ImgNameInterno_no_usar" +
                "\":null},\"Direccion\":\"Av Bulvevar 123\"," +
                "\"PrecioNoche\":100,\"Descripcion\":\"Un hotel familiar, cerca de las atracciones turisticas\"," +
                "\"SinCapacidad\":false,\"NroTelefono\":" +
                "\"097441254\",\"InfoDeContacto\":\"Contactenos en www.crystal.com\"},\"PrecioTotal\":3000}]";
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
            string resultado = System.Text.Json.JsonSerializer.Serialize(hc.Busqueda(e).Value);
            string esperado = "\"campos nulos\"";
            Assert.AreEqual(esperado, resultado);
        }


        [TestMethod]
        public void TestModificacion()
        {
            HospedajesController hc = new HospedajesController();
            string resultado = System.Text.Json.JsonSerializer.Serialize(hc.Modificar("asdjklas", true).Value);
            string esperado = "\"Acceso Restringido\"";
            Assert.AreEqual(esperado, resultado);
        }


        [TestMethod]
        public void TestModificacionLogin()
        {
            HospedajesController hc = new HospedajesController();
            string resultado = System.Text.Json.JsonSerializer.Serialize(hc.Modificar("asdsda", true).Value);
            string esperado = "\"Acceso Restringido\"";
            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod]
        public void TestAltaHospedaje()
        {
            HospedajesController hc = new HospedajesController();
            string actual = System.Text.Json.JsonSerializer.Serialize(hc.Alta(OAR.hotel).Value);
            string esperado = "\"Acceso Restringido\"";
            Assert.AreEqual(esperado, actual);
        }

        [TestMethod]
        public void TestBajaHospedaje()
        {
            HospedajesController hc = new HospedajesController();
            string actual = System.Text.Json.JsonSerializer.Serialize(hc.Baja(OAR.hotel.Nombre).Value);
            string esperado = "\"Acceso Restringido\"";
            Assert.AreEqual(esperado, actual);
        }

        [TestMethod]
        public void TestPuntuacion()
        {
            HospedajesController hc = new HospedajesController();
            Reserva reserva = sistema.CrearReserva(OAR.infoReserva);

            Puntuacion_Envio pe = new Puntuacion_Envio
            {
                Puntos = 5,
                Comentario = "Excelente hotel!",
                Codigo = reserva.Codigo
            };

            hc.Puntuar(pe);

            JsonResult resultJson = hc.PuntuacionFinal(OAR.hotel.Nombre);
            string result = System.Text.Json.JsonSerializer.Serialize(resultJson.Value);
            string esperado = "5";

            Assert.AreEqual(esperado, result);

            resultJson = hc.GetPuntuaciones(OAR.hotel.Nombre);
            result = System.Text.Json.JsonSerializer.Serialize(resultJson.Value);
            esperado = "[{\"Puntos\":" + pe.Puntos + ",\"Comentario\":\"" + pe.Comentario + "\"," +
                "\"Codigo\":\"" + pe.Codigo + "\",\"Nombre\":\"" + OAR.infoReserva.Nombre + "\",\"Apellido\":\"" + OAR.infoReserva.Apellido + "\"}]";

            Assert.AreEqual(esperado, result);
        }

        [TestMethod]
        public void TestPuntuacion_Excepcion()
        {
            HospedajesController hc = new HospedajesController();
            JsonResult resultadoJson = hc.GetPuntuaciones("adssda");
            string resultado = System.Text.Json.JsonSerializer.Serialize(resultadoJson.Value);
            string esperado = "\"No existe el alojamiento: adssda\"";
            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod]
        public void TestPuntuacion_Excepcion2()
        {
            HospedajesController hc = new HospedajesController();
            JsonResult resultJson = hc.Puntuar(null);
            string resultado = System.Text.Json.JsonSerializer.Serialize(resultJson.Value);
            string esperado = "\"Valores nulos\"";
            Assert.AreEqual(esperado, resultado);
        }

        [TestMethod]
        public void TestPuntuacionFinal_Excepcion()
        {
            HospedajesController hc = new HospedajesController();
            JsonResult resultJson = hc.PuntuacionFinal(null);
            string resultado = System.Text.Json.JsonSerializer.Serialize(resultJson.Value);
            string esperado = "\"Valores nulos\"";
            Assert.AreEqual(esperado, resultado);
        }

    }
}
