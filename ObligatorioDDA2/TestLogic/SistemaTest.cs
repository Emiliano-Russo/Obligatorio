using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObligatorioDDA2.Models;
using ObligatorioDDA2.Models.Logic;
using System.Collections.Generic;

namespace TestLogic
{
    [TestClass]
    public class SistemaTest
    {
        Sistema sistema = Sistema.GetInstancia();

        [TestMethod]
        public void GetRegiones_5Regiones()
        {
            List<Region> regiones = sistema.GetRegiones();
            int largo = regiones.Count;
            Assert.AreEqual(5, largo);
        }
    }
}
