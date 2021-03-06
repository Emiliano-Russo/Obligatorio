﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObligatorioDDA2.Controllers;
using ObligatorioDDA2.Models;
using ObligatorioDDA2.Models.Logic;

namespace TestLogic.WebApi
{
    [TestClass]
    public class Login_C_Test
    {
        [TestInitialize]
        public void Inicializar() => Sistema.GetInstancia().BaseDeDatos = false;

        [TestMethod]
        public void IngresarTest()
        {
            Sistema.GetInstancia().BorrarPuntosTuristicos();
            LoginController lc = new LoginController();
            string email = "ale@gmail.com";
            string contra = "1234";
            string actual = System.Text.Json.JsonSerializer.Serialize(lc.Ingresar(email, contra).Value);
            string esperado = "\"Credenciales no validas\"";
            Assert.AreEqual(esperado,actual);
        }

        [TestMethod]
        public void IndexTest()
        {
            LoginController lc = new LoginController();
            string actual = System.Text.Json.JsonSerializer.Serialize(lc.Index().Value);
            string esperado = "\"Pagina Login\"";
            Assert.AreEqual(esperado,actual);
        }

    }
}
