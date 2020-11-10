using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Bson;
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

            JsonResult actual = rc.Reservar(info);
            string esperada = "Punto turistico no existe";
            Assert.AreEqual(esperada,actual);
        }

        [TestMethod]
        public void Reserva2Test()
        {
            ReservaController rc = new ReservaController();           
            string actual = Reserva2Test_IngresarDatos(ref rc);
            string[] recorte = CapturarDatos_Json(actual, new string[3] { "Entrada", "Salida", "Codigo" });
            string esperada = "{\"InfoReserva\":{\"Key\":0,\"Nombre\":\"Hector\",\"Apellido\":\"Suarez\"," +
                "\"Email\":\"hector@gmail.com\",\"Estadia\":{\"Key\":0," +
                "\"Entrada\":\""+ recorte[0] + "\",\"Salida\":\""+recorte[1]+"\"," +
                "\"RangoEdades\":[1,0,0],\"RangoEdadInterno_no_usar\":\"Ninio;Adulto;Adulto\"}," +
                "\"Hotel\":{\"Nombre\":\"Crystal\",\"Estrellas\":5,\"PuntoTuristico\":{\"Nombre\":" +
                "\"Punta del este\",\"Descripcion\":\"Un lugar muy bello\",\"Region\":2,\"Categoria\":[2,3]," +
                "\"CategoriasInterno_no_usar\"" +
                ":\"Areas_Protegidas;Playas\",\"ImgName\":null,\"ImgNameInterno_no_usar\":null}," +
                "\"Direccion\":\"Av Bulvevar 123\",\"PrecioNoche\":100,\"Descripcion\":" +
                "\"Un hotel familiar, cerca de las atracciones turisticas\",\"SinCapacidad\":false," +
                "\"NroTelefono\":\"097441254\",\"InfoDeContacto\":\"Contactenos en www.crystal.com\"}}," +
                "\"Codigo\":" +"\""+ recorte[2] + "\",\"EstadoReserva\":0}";
            Assert.AreEqual(esperada, actual);
        }

        private string[] CapturarDatos_Json(string jsondata,string[] busqueda)
        {
            string[] retorno = new string[busqueda.Length];

            for (int i = 0; i < busqueda.Length; i++)
            {
                int indx = jsondata.IndexOf(busqueda[i]) + busqueda[i].Length + 3;
                string nuevo_sub_string = jsondata.Substring(indx, (jsondata.Length - indx));
                int indx_f = nuevo_sub_string.IndexOf(",")-1;
                if (indx_f == -2) indx_f = nuevo_sub_string.IndexOf("}");
                retorno[i] = jsondata.Substring(indx, indx_f);
            }
            
            return retorno;
        }

        private string Reserva2Test_IngresarDatos(ref ReservaController rc)
        {           
            Estadia estadia = OAR.estadiaVacacional;
            InfoReserva info = new InfoReserva
            {
                Nombre = "Hector",
                Apellido = "Suarez",
                Email = "hector@gmail.com",
                Estadia = estadia,
                Hotel = OAR.hotel
            };
            Sistema.GetInstancia().IncluirPuntoTuristico(OAR.puntaDelEste);
            Sistema.GetInstancia().IncluirAlojamiento(OAR.hotel);
            return System.Text.Json.JsonSerializer.Serialize(rc.Reservar(info).Value);
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
            string actual = System.Text.Json.JsonSerializer.Serialize(rc.CambiarEstado(reserva.Codigo, 3).Value);
            string esperado = "\"Acceso Restringido\"";
            Assert.AreEqual(esperado,actual);

            esperado = "{\"Estado\":0,\"Nombre\":\"Hector\",\"Descripcion\":\"Codigo reservado por mail: hector@gmail.com\"}";
            actual = System.Text.Json.JsonSerializer.Serialize(rc.Estado(reserva.Codigo).Value);
            Assert.AreEqual(actual,esperado);
        }

        [TestMethod]
        public void CambiarEstadoTest2()
        {
            ReservaController rc = new ReservaController();
            string actual = System.Text.Json.JsonSerializer.Serialize(rc.Estado("asd").Value);
            string esperado = "\"No existe asd en nuestro sistema\"";
            Assert.AreEqual(esperado,actual);
        }
    }
}
