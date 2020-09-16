using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObligatorioDDA2.Models.Exceptions;
using ObligatorioDDA2.Models.Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestLogic
{
    public partial class SistemaTest
    {
       
        [TestMethod]
        [ExpectedException(typeof(ExcepcionEstadiaInvalido))]
        public void GetAlojamiento_ObjetoInvalido()
        {
            Estadia estadia = new Estadia();
            PuntoTuristico punto = new PuntoTuristico();
            sistema.GetAlojamiento(estadia, punto);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionEstadiaInvalido))]
        public void GetAlojamiento_ObjetoInvalido2()
        {
            Estadia estadia = new Estadia
            {
                Entrada = DateTime.Now,
                Salida = new DateTime(2012, 12, 25),
                RangoEdades = new FaseEdad[] { FaseEdad.Adulto, FaseEdad.Adulto }
            };
            PuntoTuristico punto = new PuntoTuristico
            {
                Categoria = new Categoria[] { Categoria.Areas_Protegidas },
                Descripcion = "Un lugar bello",
                Nombre = "Punta del este",
                Region = Region.Este
            };
            sistema.GetAlojamiento(estadia, punto);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionEstadiaInvalido))]
        public void GetAlojamiento_ObjetoInvalido3()
        {
            Estadia estadia = new Estadia
            {
                Entrada = DateTime.Now.AddDays(3),
                Salida = DateTime.Now.AddDays(15),
                RangoEdades = new FaseEdad[] { }
            };
            PuntoTuristico punto = new PuntoTuristico
            {
                Categoria = new Categoria[] { Categoria.Areas_Protegidas },
                Descripcion = "Un lugar bello",
                Nombre = "Costa de oro",
                Region = Region.Este
            };
            sistema.GetAlojamiento(estadia, punto);
        }


        [TestMethod]
        [ExpectedException(typeof(ExcepcionEstadiaInvalido))]
        public void GetAlojamiento_ObjetoInvalido4()
        {
            Estadia estadia = new Estadia
            {
                Entrada = DateTime.Now.AddDays(-5),
                Salida = DateTime.Now.AddDays(15),
                RangoEdades = new FaseEdad[] {FaseEdad.Ninio,FaseEdad.Adulto }
            };
            PuntoTuristico punto = new PuntoTuristico
            {
                Categoria = new Categoria[] { Categoria.Areas_Protegidas },
                Descripcion = "Un lugar bello",
                Nombre = "Costa de oro",
                Region = Region.Este
            };
            sistema.GetAlojamiento(estadia, punto);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionPuntoTuristicoInvalido))]
        public void GetAlojamiento_ObjetoInvalido5()
        {
            Estadia estadia = new Estadia
            {
                Entrada = DateTime.Now.AddDays(3),
                Salida = DateTime.Now.AddDays(15),
                RangoEdades = new FaseEdad[] { FaseEdad.Ninio, FaseEdad.Adulto,FaseEdad.Adulto }
            };
            PuntoTuristico punto = new PuntoTuristico
            {
                Categoria = new Categoria[] { Categoria.Areas_Protegidas },
                Descripcion = "Un lugar bello",
                Nombre = "",
                Region = Region.Este
            };
            sistema.GetAlojamiento(estadia, punto);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionPuntoTuristicoInvalido))]
        public void GetAlojamiento_ObjetoInvalido6()
        {
            Estadia estadia = new Estadia
            {
                Entrada = DateTime.Now.AddDays(3),
                Salida = DateTime.Now.AddDays(15),
                RangoEdades = new FaseEdad[] { FaseEdad.Ninio, FaseEdad.Adulto, FaseEdad.Adulto }
            };
            PuntoTuristico punto = new PuntoTuristico
            {
                Categoria = new Categoria[] { Categoria.Areas_Protegidas },
                Nombre = "Punta del este",
                Region = Region.Este
            };
            sistema.GetAlojamiento(estadia, punto);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionPuntoTuristicoInvalido))]
        public void GetAlojamiento_ObjetoInvalido7()
        {
            Estadia estadia = new Estadia
            {
                Entrada = DateTime.Now.AddDays(3),
                Salida = DateTime.Now.AddDays(15),
                RangoEdades = new FaseEdad[] { FaseEdad.Ninio, FaseEdad.Adulto, FaseEdad.Adulto }
            };
            PuntoTuristico punto = new PuntoTuristico
            {
                Categoria = new Categoria[] { },
                Descripcion="Un lugar muy bello",
                Nombre = "Punta del este",
                Region = Region.Este
            };
            sistema.GetAlojamiento(estadia, punto);
        }

        //creado de forma publica a partir de ahora porque ya probamos su objeto invalido
        PuntoTuristico puntaDelEste = new PuntoTuristico
        {
            Categoria = new Categoria[] { Categoria.Areas_Protegidas,Categoria.Playas},
            Descripcion = "Un lugar muy bello",
            Nombre = "Punta del este",
            Region = Region.Este
        };

        Estadia estadiaVacacional = new Estadia
        {
            Entrada = DateTime.Now.AddDays(3),
            Salida = DateTime.Now.AddDays(15),
            RangoEdades = new FaseEdad[] { FaseEdad.Ninio, FaseEdad.Adulto, FaseEdad.Adulto }
        };

        [TestMethod]
        public void GetAlojamiento_Valido()
        {         
            Alojamiento alojamiento = new Alojamiento
            {
                Descripcion = "Un lugar con ambiente familiar",
                Direccion = "Avenida 123",
                Estrellas = 4.5f,
                InfoDeContacto = "Bienvenido al hotel",
                Nombre = "Miramar",
                NroTelefono = "092777555",
                PrecioNoche = 100,
                PuntoTuristico = puntaDelEste,
                SinCapacidad = false
            };
            sistema.IncluirAlojamiento(alojamiento);
            List<Alojamiento> lista =  sistema.GetAlojamiento(estadiaVacacional, puntaDelEste);
            Assert.IsTrue(lista.Contains(alojamiento));
            sistema.BorrarAlojamientos();
        }

        [TestMethod]
        public void GetAlojamiento_NoEncuentra()
        {
            PuntoTuristico punto = new PuntoTuristico
            {
                Categoria = new Categoria[] { Categoria.Areas_Protegidas, Categoria.Ciudades },
                Descripcion = "lugar agradable",
                Nombre = "Costa de oro",
                Region = Region.Este
            };

            Alojamiento alojamiento = new Alojamiento
            {
                Descripcion = "Un lugar con ambiente familiar",
                Direccion = "Avenida 123",
                Estrellas = 4.5f,
                InfoDeContacto = "Bienvenido al hotel",
                Nombre = "Miramar",
                NroTelefono = "092777555",
                PrecioNoche = 100,
                PuntoTuristico = punto,
                SinCapacidad = false
            };
            sistema.IncluirAlojamiento(alojamiento);
            List<Alojamiento> lista = sistema.GetAlojamiento(estadiaVacacional,puntaDelEste);
            Assert.IsFalse(lista.Contains(alojamiento));
            sistema.BorrarAlojamientos();
        }

        [TestMethod]
        public void GetAlojamiento_NoEncuentra2()
        {
            Alojamiento alojamiento = new Alojamiento
            {
                Descripcion = "Un lugar con ambiente familiar",
                Direccion = "Avenida 123",
                Estrellas = 4.5f,
                InfoDeContacto = "Bienvenido al hotel",
                Nombre = "Miramar",
                NroTelefono = "092777555",
                PrecioNoche = 100,
                PuntoTuristico = puntaDelEste,
                SinCapacidad = true
            };
            sistema.IncluirAlojamiento(alojamiento);
            List<Alojamiento> lista = sistema.GetAlojamiento(estadiaVacacional, puntaDelEste);
            Assert.IsFalse(lista.Contains(alojamiento));
            sistema.BorrarAlojamientos();
        }

        //Test InculirAlojamiento

        [TestMethod]
        [ExpectedException(typeof(ExcepcionAlojamientoInvalido))]
        public void IncluirAlojameiento_ObjetoInvalido1()
        {
            Alojamiento alojamiento = new Alojamiento();
            sistema.IncluirAlojamiento(alojamiento);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionAlojamientoInvalido))]
        public void IncluirAlojameiento_ObjetoInvalido2()
        {
            Alojamiento alojamiento = new Alojamiento
            {
                Descripcion = "Un lugar maravilloso"
            };
            sistema.IncluirAlojamiento(alojamiento);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionAlojamientoInvalido))]
        public void IncluirAlojameiento_ObjetoInvalido3()
        {
            Alojamiento alojamiento = new Alojamiento
            {
                Descripcion = "Un lugar maravilloso"
            };
            sistema.IncluirAlojamiento(alojamiento);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionAlojamientoInvalido))]
        public void IncluirAlojameiento_ObjetoInvalido4()
        {
            Alojamiento alojamiento = new Alojamiento
            {
                Descripcion = "Un lugar maravilloso",
                Direccion ="Bulevar123"
            };
            sistema.IncluirAlojamiento(alojamiento);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionAlojamientoInvalido))]
        public void IncluirAlojameiento_ObjetoInvalido5()
        {
            Alojamiento alojamiento = new Alojamiento
            {
                Descripcion = "Un lugar maravilloso",
                Direccion = "Bulevar123",
                Estrellas = 3.5f
            };
            sistema.IncluirAlojamiento(alojamiento);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionAlojamientoInvalido))]
        public void IncluirAlojameiento_ObjetoInvalido6()
        {
            Alojamiento alojamiento = new Alojamiento
            {
                Descripcion = "Un lugar maravilloso",
                Direccion = "Bulevar123",
                Estrellas = 3.5f,
                InfoDeContacto="Hola"
            };
            sistema.IncluirAlojamiento(alojamiento);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionAlojamientoInvalido))]
        public void IncluirAlojameiento_ObjetoInvalido7()
        {
            Alojamiento alojamiento = new Alojamiento
            {
                Descripcion = "Un lugar maravilloso",
                Direccion = "Bulevar123",
                Estrellas = 3.5f,
                InfoDeContacto = "Hola",
                Nombre="Radison"
            };
            sistema.IncluirAlojamiento(alojamiento);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionAlojamientoInvalido))]
        public void IncluirAlojameiento_ObjetoInvalido8()
        {
            Alojamiento alojamiento = new Alojamiento
            {
                Nombre = "Radison",
                Direccion="Bulevar123",
                PrecioNoche=120,
                PuntoTuristico=puntaDelEste
            };
            sistema.IncluirAlojamiento(alojamiento);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionAlojamientoInvalido))]
        public void IncluirAlojameiento_ObjetoInvalido9()
        {
            Alojamiento alojamiento = new Alojamiento
            {
                Nombre = "Radison",
                Direccion = "Bulevar123",
                PrecioNoche = 120,
                PuntoTuristico = puntaDelEste,
                SinCapacidad = false
            };
            sistema.IncluirAlojamiento(alojamiento);
        }


        [TestMethod]
        [ExpectedException(typeof(ExcepcionAlojamientoInvalido))]
        public void IncluirAlojameiento_ObjetoInvalido10()
        {
            Alojamiento alojamiento = new Alojamiento
            {
                Nombre = "Radison",
                Direccion = "Bulevar123",
                PrecioNoche = 120,
                PuntoTuristico = puntaDelEste,
                SinCapacidad = false,
                Estrellas=5
            };
            sistema.IncluirAlojamiento(alojamiento);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionAlojamientoInvalido))]
        public void IncluirAlojameiento_YaExiste()
        {
            Alojamiento alojamiento = new Alojamiento
            {
                Descripcion = "Un lugar con ambiente familiar",
                Direccion = "Avenida 123",
                Estrellas = 4.5f,
                InfoDeContacto = "Bienvenido al hotel",
                Nombre = "Miramar",
                NroTelefono = "092777555",
                PrecioNoche = 100,
                PuntoTuristico = puntaDelEste,
                SinCapacidad = false
            };
            sistema.IncluirAlojamiento(alojamiento);
            sistema.IncluirAlojamiento(alojamiento);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionAlojamientoInvalido))]
        public void IncluirAlojameiento_EstrellasInvalidas()
        {
            Alojamiento alojamiento = new Alojamiento
            {
                Descripcion = "Un lugar con ambiente familiar",
                Direccion = "Avenida 123",
                Estrellas = 0f,
                InfoDeContacto = "Bienvenido al hotel",
                Nombre = "Miramar",
                NroTelefono = "092777555",
                PrecioNoche = 100,
                PuntoTuristico = puntaDelEste,
                SinCapacidad = false
            };
            sistema.IncluirAlojamiento(alojamiento);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionAlojamientoInvalido))]
        public void IncluirAlojameiento_EstrellasInvalidas2()
        {
            Alojamiento alojamiento = new Alojamiento
            {
                Descripcion = "Un lugar con ambiente familiar",
                Direccion = "Avenida 123",
                Estrellas = 6f,
                InfoDeContacto = "Bienvenido al hotel",
                Nombre = "Miramar",
                NroTelefono = "092777555",
                PrecioNoche = 100,
                PuntoTuristico = puntaDelEste,
                SinCapacidad = false
            };
            sistema.IncluirAlojamiento(alojamiento);
        }

        [TestMethod]
        public void IncluirAlojamiento_Valido()
        {
            Alojamiento alojamiento = new Alojamiento
            {
                Descripcion = "Un lugar con ambiente familiar",
                Direccion = "Avenida 123",
                Estrellas = 4.5f,
                InfoDeContacto = "Bienvenido al hotel",
                Nombre = "Miramar",
                NroTelefono = "092777555",
                PrecioNoche = 100,
                PuntoTuristico = puntaDelEste,
                SinCapacidad = false
            };
            sistema.IncluirAlojamiento(alojamiento);
            List<Alojamiento> lista = sistema.GetAlojamiento(estadiaVacacional, puntaDelEste);
            Assert.IsTrue(lista.Contains(alojamiento));
            sistema.BorrarAlojamientos();
        }


        //Test ModificarAlojamiento
        [TestMethod]
        [ExpectedException(typeof(ExcepcionAlojamientoInvalido))]
        public void ModificarAlojamiento_NoSeEncuentraNombre()
        {
            sistema.ModificarAlojamiento("", false);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionAlojamientoInvalido))]
        public void ModificarAlojamiento_NoSeEncuentraNombre2()
        {
            sistema.ModificarAlojamiento("Rivadavia", false);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionAlojamientoInvalido))]
        public void ModificarAlojamiento_NoSeEncuentraNombre3()
        {
            sistema.ModificarAlojamiento("Radison", true);
        }


        [TestMethod]
        public void ModificarAlojamiento_Valido()
        {
            Alojamiento alojamiento = new Alojamiento
            {
                Descripcion = "Un lugar con ambiente familiar",
                Direccion = "Avenida 123",
                Estrellas = 4.5f,
                InfoDeContacto = "Bienvenido al hotel",
                Nombre = "Miramar",
                NroTelefono = "092777555",
                PrecioNoche = 100,
                PuntoTuristico = puntaDelEste,
                SinCapacidad = true
            };
            sistema.IncluirAlojamiento(alojamiento);
            List<Alojamiento> lista = sistema.GetAlojamiento(estadiaVacacional, puntaDelEste);
            Alojamiento alj = lista[0];
            Assert.IsTrue(alj.SinCapacidad);
            sistema.ModificarAlojamiento("Miramar", false);
            lista = sistema.GetAlojamiento(estadiaVacacional, puntaDelEste);
            alj = lista[0];
            Assert.IsFalse(alj.SinCapacidad);
            sistema.BorrarAlojamientos();
        }

        //Borrar alojamiento

        [TestMethod]
        [ExpectedException(typeof(ExcepcionAlojamientoInvalido))]
        public void BorrarAlojamiento_Invalido()
        {
            sistema.BorrarAlojamiento("");
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionAlojamientoInvalido))]
        public void BorrarAlojamiento_Invalido2()
        {
            sistema.BorrarAlojamiento("Herks");
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionAlojamientoInvalido))]
        public void BorrarAlojamiento_Invalido3()
        {
            sistema.BorrarAlojamiento(null);
        }

        [TestMethod]
        public void BorrarAlojamiento_Valido()
        {
            Alojamiento alojamiento = new Alojamiento
            {
                Descripcion = "Un lugar con ambiente familiar",
                Direccion = "Avenida 123",
                Estrellas = 4.5f,
                InfoDeContacto = "Bienvenido al hotel",
                Nombre = "Miramar",
                NroTelefono = "092777555",
                PrecioNoche = 100,
                PuntoTuristico = puntaDelEste,
                SinCapacidad = false
            };
            sistema.IncluirAlojamiento(alojamiento);
            sistema.BorrarAlojamiento("Miramar");
            List<Alojamiento> lista = sistema.GetAlojamiento(estadiaVacacional, puntaDelEste);
            Assert.IsFalse(lista.Contains(alojamiento));
        }


    }
}
