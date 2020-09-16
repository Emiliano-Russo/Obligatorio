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

       [TestMethod]
       [ExpectedException(typeof(ExcepcionLogin))]
        public void AgregarAdmin_Invalido()
        {
            sistema.AgregarAdmin(null, "asddas");
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionLogin))]
        public void AgregarAdmin_Invalido2()
        {
            sistema.AgregarAdmin("juan@gmail.com", "");
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionLogin))]
        public void AgregarAdmin_Invalido3()
        {
            sistema.AgregarAdmin("juan@gmail.com", null);
        }

        [TestMethod]
        public void AgregarAdmin_Valido()
        {
            bool resultado = sistema.ExisteAdmin("juan@gmail.com");
            Assert.IsFalse(resultado);
            sistema.AgregarAdmin("juan@gmail.com", "1234psl");
            resultado = sistema.ExisteAdmin("juan@gmail.com");
            Assert.IsTrue(resultado);
            sistema.BorrarAdmin("juan@gmail.com");
            resultado = sistema.ExisteAdmin("juan@gmail.com");
            Assert.IsFalse(resultado);
        }

        //Validacion login
        [TestMethod]
        public void ValidacionLogin()
        {
            bool resultado = sistema.ValidacionLogin("juan@gmail.com","24sd6");
            Assert.IsFalse(resultado);
            sistema.AgregarAdmin("juan@gmail.com", "24sd6");
            resultado =  sistema.ValidacionLogin("juan@gmail.com", "24sd6");
            Assert.IsTrue(resultado);
        }
    }
}
