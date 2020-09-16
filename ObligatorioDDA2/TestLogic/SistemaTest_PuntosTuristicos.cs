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
        //Test IncluirPuntoTuristico
        [TestMethod]
        [ExpectedException(typeof(ExcepcionPuntoTuristicoInvalido))]
        public void IncluirPuntoTuristico_NombreRegion()
        {
            PuntoTuristico punto = new PuntoTuristico();
            punto.Nombre = "Punta del este";
            punto.Region = Region.Este;
            sistema.IncluirPuntoTuristico(punto);           
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionPuntoTuristicoInvalido))]
        public void IncluirPuntoTuristico_Nada()
        {
            PuntoTuristico punto = new PuntoTuristico();
            sistema.IncluirPuntoTuristico(punto);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionPuntoTuristicoInvalido))]
        public void IncluirPuntoTuristico_Nombre()
        {
            PuntoTuristico punto = new PuntoTuristico();
            punto.Nombre = "Salinas";
            sistema.IncluirPuntoTuristico(punto);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionPuntoTuristicoInvalido))]
        public void IncluirPuntoTuristico_Categoria()
        {
            PuntoTuristico punto = new PuntoTuristico();
            punto.Categoria = new Categoria[] { Categoria.Playas, Categoria.Pueblos };
            sistema.IncluirPuntoTuristico(punto);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionPuntoTuristicoInvalido))]
        public void IncluirPuntoTuristico_Descripcion()
        {
            PuntoTuristico punto = new PuntoTuristico();
            punto.Descripcion = "La mejor palya del Uruguay";
            sistema.IncluirPuntoTuristico(punto);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionPuntoTuristicoInvalido))]
        public void IncluirPuntoTuristico_NombreDescripcion()
        {
            PuntoTuristico punto = new PuntoTuristico();
            punto.Nombre = "Punta del este";
            punto.Descripcion = "La mejor palya del Uruguay";
            sistema.IncluirPuntoTuristico(punto);
        }


        [TestMethod]
        [ExpectedException(typeof(ExcepcionPuntoTuristicoInvalido))]
        public void IncluirPuntoTuristico_RegionDescripcion()
        {
            PuntoTuristico punto = new PuntoTuristico();
            punto.Region = Region.Este;
            punto.Descripcion = "La mejor palya del Uruguay";
            sistema.IncluirPuntoTuristico(punto);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionPuntoTuristicoInvalido))]
        public void IncluirPuntoTuristico_RegionCategoriaNombre()
        {
            PuntoTuristico punto = new PuntoTuristico();
            punto.Region = Region.Este;
            punto.Categoria = new Categoria[] { Categoria.Playas, Categoria.Areas_Protegidas };
            punto.Nombre = "Punta del Este";
            sistema.IncluirPuntoTuristico(punto);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionPuntoTuristicoInvalido))]
        public void IncluirPuntoTuristico_NombreDescripcionRegion()
        {
            PuntoTuristico punto = new PuntoTuristico();
            punto.Nombre = "Punta del Este";
            punto.Descripcion = "La mejor playa del Uruguay";
            punto.Region = Region.Este;                    
            sistema.IncluirPuntoTuristico(punto);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionPuntoTuristicoInvalido))]
        public void IncluirPuntoTuristico_MuchasCategorias()
        {
            PuntoTuristico punto = new PuntoTuristico();
            punto.Nombre = "Punta del Este";
            punto.Descripcion = "La mejor playa del Uruguay";
            punto.Region = Region.Este;
            punto.Categoria = new Categoria[] { Categoria.Pueblos, Categoria.Playas, Categoria.Ciudades, Categoria.Areas_Protegidas, Categoria.Pueblos };
            sistema.IncluirPuntoTuristico(punto);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionPuntoTuristicoInvalido))]
        public void IncluirPuntoTuristico_CategoriasRepetidas()
        {
            PuntoTuristico punto = new PuntoTuristico();
            punto.Nombre = "Punta del Este";
            punto.Descripcion = "La mejor playa del Uruguay";
            punto.Region = Region.Este;
            punto.Categoria = new Categoria[] { Categoria.Pueblos, Categoria.Pueblos };
            sistema.IncluirPuntoTuristico(punto);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionPuntoTuristicoInvalido))]
        public void IncluirPuntoTuristico_NombreVacio()
        {
            PuntoTuristico punto = new PuntoTuristico();
            punto.Nombre = "";
            punto.Descripcion = "La mejor playa del Uruguay";
            punto.Region = Region.Este;
            punto.Categoria = new Categoria[] { Categoria.Pueblos };
            sistema.IncluirPuntoTuristico(punto);
        }


        [TestMethod]
        [ExpectedException(typeof(ExcepcionPuntoTuristicoInvalido))]
        public void IncluirPuntoTuristico_DescripcionVacio()
        {
            PuntoTuristico punto = new PuntoTuristico();
            punto.Nombre = "Punta del este";
            punto.Descripcion = "";
            punto.Region = Region.Este;
            punto.Categoria = new Categoria[] { Categoria.Pueblos };
            sistema.IncluirPuntoTuristico(punto);
        }

        [TestMethod]
        public void IncluirPuntoTuristico_NoSeEncuentra()
        {
            PuntoTuristico punto = new PuntoTuristico();
            punto.Nombre = "Piriapolis";
            punto.Region = Region.Este;
            punto.Categoria = new Categoria[] { Categoria.Playas, Categoria.Areas_Protegidas };
            punto.Descripcion = "De las mejores playas del Uruguay";
            sistema.IncluirPuntoTuristico(punto);
            List<PuntoTuristico> lista = sistema.GetPuntosTuristicos(Region.Litoral_Norte);
            Assert.IsTrue(!lista.Contains(punto));
            sistema.BorrarPuntosTuristicos();
        }

        [TestMethod]
        public void IncluirPuntoTuristico_Valido1()
        {
            PuntoTuristico punto = new PuntoTuristico();
            punto.Nombre = "Piriapolis";
            punto.Region = Region.Este;
            punto.Categoria = new Categoria[] { Categoria.Playas,Categoria.Areas_Protegidas};
            punto.Descripcion = "De las mejores playas del Uruguay";
            sistema.IncluirPuntoTuristico(punto);
            List<PuntoTuristico> lista = sistema.GetPuntosTuristicos(Region.Este);
            Assert.IsTrue(lista.Contains(punto));
            sistema.BorrarPuntosTuristicos();
        }

        [TestMethod]
        public void IncluirPuntoTuristico_Valido2()
        {
            PuntoTuristico punto = new PuntoTuristico();
            punto.Nombre = "Salinas";
            punto.Region = Region.Este;
            punto.Categoria = new Categoria[] { Categoria.Playas, Categoria.Pueblos };
            punto.Descripcion = "Una playa super traquila y familiar";
            sistema.IncluirPuntoTuristico(punto);
            List<PuntoTuristico> lista = sistema.GetPuntosTuristicos(Region.Este);
            Assert.IsTrue(lista.Contains(punto));
            sistema.BorrarPuntosTuristicos();
        }

        [TestMethod]
        public void IncluirPuntoTuristico_Valido3()
        {
            PuntoTuristico punto = new PuntoTuristico();
            punto.Nombre = "Ciudad del Plata";
            punto.Region = Region.Metropolitana;
            punto.Categoria = new Categoria[] { Categoria.Playas };
            punto.Descripcion = "Una playa donde la naturaleza abunda";
            sistema.IncluirPuntoTuristico(punto);
            List<PuntoTuristico> lista = sistema.GetPuntosTuristicos(Region.Metropolitana);
            Assert.IsTrue(lista.Contains(punto));
            sistema.BorrarPuntosTuristicos();
        }

        //GetPuntosTuristicos por categoria
        [TestMethod]
        public void GetPuntosTuristicosPorCategoria_Valido1()
        {
            PuntoTuristico punto = new PuntoTuristico();
            punto.Nombre = "Ciudad del Plata";
            punto.Region = Region.Metropolitana;
            punto.Categoria = new Categoria[] { Categoria.Playas };
            punto.Descripcion = "Una playa donde la naturaleza abunda";
            sistema.IncluirPuntoTuristico(punto);
            List<PuntoTuristico> lista = sistema.GetPuntosTuristicos(Region.Metropolitana,new Categoria[] { Categoria.Playas });
            Assert.IsTrue(lista.Contains(punto));
            sistema.BorrarPuntosTuristicos();
        }

        [TestMethod]
        public void GetPuntosTuristicosPorCategoria_Valido2()
        {
            PuntoTuristico punto = new PuntoTuristico();
            punto.Nombre = "Pajas Blancas";
            punto.Region = Region.Metropolitana;
            punto.Categoria = new Categoria[] { Categoria.Playas,Categoria.Pueblos };
            punto.Descripcion = "Una playa donde la naturaleza abunda";
            sistema.IncluirPuntoTuristico(punto);
            List<PuntoTuristico> lista = sistema.GetPuntosTuristicos(Region.Metropolitana,new Categoria[] {Categoria.Playas,Categoria.Pueblos});
            Assert.IsTrue(lista.Contains(punto));
            lista = sistema.GetPuntosTuristicos(Region.Metropolitana, new Categoria[] { Categoria.Pueblos });
            Assert.IsTrue(lista.Contains(punto));
            sistema.BorrarPuntosTuristicos();
        }

        [TestMethod]
        public void GetPuntosTuristicosPorCategoria_SinResultados()
        {
            PuntoTuristico punto = new PuntoTuristico();
            punto.Nombre = "Pajas Blancas";
            punto.Region = Region.Metropolitana;
            punto.Categoria = new Categoria[] { Categoria.Playas, Categoria.Pueblos };
            punto.Descripcion = "Una playa donde la naturaleza abunda";
            sistema.IncluirPuntoTuristico(punto);
            List<PuntoTuristico> lista = sistema.GetPuntosTuristicos(Region.Metropolitana, new Categoria[] { Categoria.Areas_Protegidas});
            Assert.IsTrue(!lista.Contains(punto));
        }

        //GetPuntosTuristicos 
        [TestMethod]
        public void GetPuntosTuristicos_Valido()
        {
            sistema.IncluirPuntoTuristico(puntaDelEste);
            List<PuntoTuristico> lista = sistema.GetPuntosTuristicos(Region.Este);
            Assert.IsTrue(lista.Contains(puntaDelEste));
        }

        [TestMethod]
        public void GetPuntosTuristicos_NoEncuentra()
        {
            sistema.IncluirPuntoTuristico(puntaDelEste);
            List<PuntoTuristico> lista = sistema.GetPuntosTuristicos(Region.Centro_Sur);
            Assert.IsFalse(lista.Contains(puntaDelEste));
        }

        //BorrarPuntosTuristicos (ya testeado con el resto de los metodos)
    }
}
