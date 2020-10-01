using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObligatorioDDA2.Controllers;

namespace TestLogic.WebApi
{
    
    [TestClass]
    public class Regiones_C_Test
    {

        [TestMethod]
        public void IndexTest()
        {
            RegionesController rc = new RegionesController();
            string actual = rc.Index();
            string esperado = "Metropolitana / Centro_Sur / Este / Litoral_Norte / Corredor_Pajaros_Pintados / ";
            Assert.AreEqual(esperado,actual);
        }

    }
}
