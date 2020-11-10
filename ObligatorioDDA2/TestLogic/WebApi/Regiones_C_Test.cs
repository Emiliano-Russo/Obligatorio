using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObligatorioDDA2.Controllers;
using System.Text.Json;
using ObligatorioDDA2.Models.Logic;
using System.IO;
using Newtonsoft.Json;

namespace TestLogic.WebApi
{
    
    [TestClass]
    public class Regiones_C_Test
    {

        [TestMethod]
        public void IndexTest()
        {
           
            RegionesController rc = new RegionesController();
            var jsonresult= rc.Index();
            string actual = System.Text.Json.JsonSerializer.Serialize(jsonresult.Value);
            string esperado = "[\"Metropolitana\",\"Centro_Sur\",\"Este\",\"Litoral_Norte\",\"Corredor_Pajaros_Pintados\"]";
            Assert.AreEqual(esperado,actual);
        }

    }
}
