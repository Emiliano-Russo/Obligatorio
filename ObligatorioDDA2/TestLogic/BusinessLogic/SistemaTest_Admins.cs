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

        [TestInitialize]
        public void TestInitialize()
        {
            bool result = true;
            Sistema.GetInstancia().BaseDeDatos = true;
            Sistema.GetInstancia().BaseDeDatos = true;
            result = Sistema.GetInstancia().BaseDeDatos;
            Assert.IsTrue(result);

            Sistema.GetInstancia().BaseDeDatos = false;
            result = Sistema.GetInstancia().BaseDeDatos;
            Assert.IsFalse(result);
        }


            [TestMethod]
       [ExpectedException(typeof(ExcepcionLogin))]
        public void AgregarAdmin_Invalido()
        {
            Admin admin = new Admin
            {
                email = null,
                contrasenia = "asddas"
            };
            sistema.AgregarAdmin(admin);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionLogin))]
        public void AgregarAdmin_Invalido2()
        {
            Admin admin = new Admin
            {
                email = "juan@gmail.com",
                contrasenia = ""
            };
            sistema.AgregarAdmin(admin);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionLogin))]
        public void AgregarAdmin_Invalido3()
        {
            Admin admin = new Admin
            {
                email = "juan@gmail.com",
                contrasenia = null
            };
            sistema.AgregarAdmin(admin);
        }

        [TestMethod]
        public void AgregarAdmin_Valido()
        {
            Admin admin = new Admin
            {
                email = "juan@gmail.com",
                contrasenia = "contrasenia"
            };

            bool resultado = sistema.ExisteAdmin(admin);
            Assert.IsFalse(resultado);

            sistema.AgregarAdmin(admin);
            resultado = sistema.ExisteAdmin(admin);
            Assert.IsTrue(resultado);

            sistema.BorrarAdmin(admin);
            resultado = sistema.ExisteAdmin(admin);
            Assert.IsFalse(resultado);
        }

        //Validacion login
        [TestMethod]
        public void ValidacionLogin()
        {
            Admin admin = new Admin
            {
                email = "juan@gmail.com",
                contrasenia = "24sd6"
            };

            bool resultado = sistema.ValidacionLogin(admin);
            Assert.IsFalse(resultado);

            sistema.AgregarAdmin(admin);
            resultado =  sistema.ValidacionLogin(admin);
            Assert.IsTrue(resultado);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionLogin))]
        public void QuitarAdminNoExistente()
        {
            Admin admin = new Admin
            {
                email = "juan@gmail.com",
                contrasenia = "24sd6"
            };
            sistema.BorrarAdmin(admin);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionLogin))]
        public void AdminYaExistente()
        {
            Admin admin = new Admin
            {
                email = "juan@gmail.com",
                contrasenia = "24sd6"
            };
            sistema.AgregarAdmin(admin);
            sistema.AgregarAdmin(admin);
        }
    }
}
