using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObligatorioDDA2.Models;
using ObligatorioDDA2.Models.Logic;
using System.Collections.Generic;

namespace TestLogic
{
    [TestClass]
    public partial class SistemaTest
    {
        Sistema sistema = Sistema.GetInstancia();

        public SistemaTest() => sistema.BaseDeDatos = false;
        

        [TestMethod]
        public void GetRegiones_5Regiones()
        {
            List<Region> regiones = sistema.GetRegiones();
            int largo = regiones.Count;
            Assert.AreEqual(5, largo);
        }

        [TestMethod]
        public void GetRegiones_RegionesCorrectas()
        {
            List<Region> regiones = sistema.GetRegiones();
            for (int i = 0; i <= 5; i++)
            {
                bool contiene = regiones.Contains((Region)i);
                Assert.IsTrue(contiene);
            }
        }
    }
}
