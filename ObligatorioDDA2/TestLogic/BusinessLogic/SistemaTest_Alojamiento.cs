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
            sistema.GetHospedajes(estadia, punto);
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
            sistema.GetHospedajes(estadia, punto);
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
            sistema.GetHospedajes(estadia, punto);
        }


        [TestMethod]
        [ExpectedException(typeof(ExcepcionEstadiaInvalido))]
        public void GetAlojamiento_ObjetoInvalido4()
        {
            Estadia estadia = new Estadia
            {
                Entrada = DateTime.Now.AddDays(-5),
                Salida = DateTime.Now.AddDays(15),
                RangoEdades = new FaseEdad[] { FaseEdad.Ninio, FaseEdad.Adulto }
            };
            PuntoTuristico punto = new PuntoTuristico
            {
                Categoria = new Categoria[] { Categoria.Areas_Protegidas },
                Descripcion = "Un lugar bello",
                Nombre = "Costa de oro",
                Region = Region.Este
            };
            sistema.GetHospedajes(estadia, punto);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionPuntoTuristicoInvalido))]
        public void GetAlojamiento_ObjetoInvalido5()
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
                Descripcion = "Un lugar bello",
                Nombre = "",
                Region = Region.Este
            };
            sistema.GetHospedajes(estadia, punto);
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
            sistema.GetHospedajes(estadia, punto);
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
                Descripcion = "Un lugar muy bello",
                Nombre = "Punta del este",
                Region = Region.Este
            };
            sistema.GetHospedajes(estadia, punto);
        }

        //creado de forma publica a partir de ahora porque ya probamos su objeto invalido
        PuntoTuristico puntaDelEste = new PuntoTuristico
        {
            Categoria = new Categoria[] { Categoria.Areas_Protegidas, Categoria.Playas },
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

        private void BorrarHotelesYPuntos()
        {
            sistema.BorrarAlojamientos();
            sistema.BorrarPuntosTuristicos();
        }

        [TestMethod]
        public void GetAlojamiento_Valido()
        {
            BorrarHotelesYPuntos();

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

            Hospedaje hospedaje = new Hospedaje(alojamiento, estadiaVacacional);
            string toStringHosepdaje = hospedaje.ToString();
            string esperadoToStringHospedaje = alojamiento.ToString() +
                                               "Precio total: " + hospedaje.PrecioTotal + " $";

            Assert.AreEqual(esperadoToStringHospedaje, toStringHosepdaje);
            sistema.IncluirPuntoTuristico(puntaDelEste);
            sistema.IncluirAlojamiento(alojamiento);
            List<Hospedaje> lista = sistema.GetHospedajes(estadiaVacacional, puntaDelEste);
            Assert.IsTrue(lista.Contains(hospedaje));

            sistema.BorrarAlojamientos();
        }

        [TestMethod]
        public void GetAlojamiento_NoEncuentra()
        {
            BorrarHotelesYPuntos();
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

            sistema.IncluirPuntoTuristico(punto);
            sistema.IncluirPuntoTuristico(puntaDelEste);
            sistema.IncluirAlojamiento(alojamiento);
            Hospedaje hos = new Hospedaje(alojamiento, estadiaVacacional);
            List<Hospedaje> lista = sistema.GetHospedajes(estadiaVacacional, puntaDelEste);
            Assert.IsFalse(lista.Contains(hos));
            sistema.BorrarAlojamientos();
        }

        [TestMethod]
        public void GetAlojamiento_NoEncuentra2()
        {
            BorrarHotelesYPuntos();
            PuntoTuristico piria = new PuntoTuristico
            {
                Categoria = new Categoria[] { Categoria.Playas },
                Descripcion = "Playa bonita",
                Nombre = "Piria",
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
                PuntoTuristico = puntaDelEste,
                SinCapacidad = true
            };
            sistema.IncluirPuntoTuristico(piria);
            sistema.IncluirPuntoTuristico(puntaDelEste);
            sistema.IncluirAlojamiento(alojamiento);
            Hospedaje h = new Hospedaje(alojamiento, estadiaVacacional);
            List<Hospedaje> lista = sistema.GetHospedajes(estadiaVacacional, piria);
            Assert.IsFalse(lista.Contains(h));
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
                Direccion = "Bulevar123"
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
                InfoDeContacto = "Hola"
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
                Nombre = "Radison"
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
                Direccion = "Bulevar123",
                PrecioNoche = 120,
                PuntoTuristico = puntaDelEste
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
                Estrellas = 5
            };
            sistema.IncluirAlojamiento(alojamiento);
        }

        [TestMethod]
        public void IncluirAlojameiento_YaExiste()
        {
            BorrarHotelesYPuntos();
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
            sistema.IncluirPuntoTuristico(puntaDelEste);
            sistema.IncluirAlojamiento(alojamiento);
            try
            {
                sistema.IncluirAlojamiento(alojamiento);
            }
            catch (Exception e)
            {
                Assert.IsTrue(e.GetType() == typeof(ExcepcionAlojamientoInvalido));
            }
            finally
            {
                sistema.BorrarAlojamientos();
            }


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
            BorrarHotelesYPuntos();
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
            sistema.IncluirPuntoTuristico(puntaDelEste);
            sistema.IncluirAlojamiento(alojamiento);
            Hospedaje hos = new Hospedaje(alojamiento, estadiaVacacional);
            List<Hospedaje> lista = sistema.GetHospedajes(estadiaVacacional, puntaDelEste);
            Assert.IsTrue(lista.Contains(hos));
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
            BorrarHotelesYPuntos();
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
            sistema.IncluirPuntoTuristico(puntaDelEste);
            sistema.IncluirAlojamiento(alojamiento);
            List<Hospedaje> lista = sistema.GetHospedajes(estadiaVacacional, puntaDelEste);
            Alojamiento alj = lista[0].Alojamiento;
            Assert.IsFalse(alj.SinCapacidad);
            sistema.ModificarAlojamiento("Miramar", true);
            lista = sistema.GetHospedajes(estadiaVacacional, puntaDelEste);
            Assert.IsTrue(lista.Count == 0);
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
            BorrarHotelesYPuntos();
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
            sistema.IncluirPuntoTuristico(puntaDelEste);
            sistema.IncluirAlojamiento(alojamiento);
            sistema.BorrarAlojamiento("Miramar");
            Hospedaje hos = new Hospedaje(alojamiento, estadiaVacacional);
            List<Hospedaje> lista = sistema.GetHospedajes(estadiaVacacional, puntaDelEste);
            Assert.IsFalse(lista.Contains(hos));
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionPuntoTuristicoInvalido))]
        public void RegistrarAlojamiento_PuntoInexistente()
        {
            PuntoTuristico punto = puntaDelEste;
            punto.Nombre = "TehsHotel";

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
            sistema.BorrarAlojamientos();
        }

        [TestMethod]
        public void TestPrecioJubilado()
        {
            FaseEdad[] rango = { FaseEdad.Adulto, FaseEdad.Jubilado };
            Estadia estadia = CrearEstadia(rango);

            PuntoTuristico punta_de_este = CrearPuntaDelEste();
            sistema.IncluirPuntoTuristico(punta_de_este);
            Alojamiento hyatt = CrearHyatt(punta_de_este);
            sistema.IncluirAlojamiento(hyatt);

            List<Hospedaje> lista_hospedajes = sistema.GetHospedajes(estadia, punta_de_este);
            float precio_actual = lista_hospedajes[0].PrecioTotal;
            float precio_esperado = 300;
            Assert.AreEqual(precio_esperado, precio_actual);
            sistema.BorrarAlojamientos();
        }

        [TestMethod]
        public void TestPrecioJubilado_2Jubilados()
        {
            FaseEdad[] rango = { FaseEdad.Adulto, FaseEdad.Jubilado, FaseEdad.Jubilado };
            Estadia estadia = CrearEstadia(rango);

            PuntoTuristico punta_de_este = CrearPuntaDelEste();
            sistema.IncluirPuntoTuristico(punta_de_este);
            Alojamiento hyatt = CrearHyatt(punta_de_este);
            sistema.IncluirAlojamiento(hyatt);

            List<Hospedaje> lista_hospedajes = sistema.GetHospedajes(estadia, punta_de_este);
            float precio_actual = lista_hospedajes[0].PrecioTotal;
            float precio_esperado = 150 + 150 + 105;
            Assert.AreEqual(precio_esperado, precio_actual);
            sistema.BorrarAlojamientos();
        }


        [TestMethod]
        public void TestPrecioJubilado_3Jubilados()
        {
            FaseEdad[] rango = { FaseEdad.Adulto, FaseEdad.Jubilado, FaseEdad.Jubilado, FaseEdad.Jubilado };
            Estadia estadia = CrearEstadia(rango);

            PuntoTuristico punta_de_este = CrearPuntaDelEste();
            sistema.IncluirPuntoTuristico(punta_de_este);
            Alojamiento hyatt = CrearHyatt(punta_de_este);
            sistema.IncluirAlojamiento(hyatt);

            List<Hospedaje> lista_hospedajes = sistema.GetHospedajes(estadia, punta_de_este);
            float precio_actual = lista_hospedajes[0].PrecioTotal;
            float precio_esperado = 150 + 150 + 105 + 150;
            Assert.AreEqual(precio_esperado, precio_actual);
            sistema.BorrarAlojamientos();
        }

        [TestMethod]
        public void TestPrecioJubilado_4Jubilados()
        {
            FaseEdad[] rango = { FaseEdad.Adulto, FaseEdad.Jubilado, FaseEdad.Jubilado, FaseEdad.Jubilado,FaseEdad.Jubilado };
            Estadia estadia = CrearEstadia(rango);

            PuntoTuristico punta_de_este = CrearPuntaDelEste();
            sistema.IncluirPuntoTuristico(punta_de_este);
            Alojamiento hyatt = CrearHyatt(punta_de_este);
            sistema.IncluirAlojamiento(hyatt);

            List<Hospedaje> lista_hospedajes = sistema.GetHospedajes(estadia, punta_de_este);
            float precio_actual = lista_hospedajes[0].PrecioTotal;
            float precio_esperado = 150 + 150 + 105 + 150 + 105;
            Assert.AreEqual(precio_esperado, precio_actual);
            sistema.BorrarAlojamientos();
        }

        private Alojamiento CrearHyatt(PuntoTuristico punto)
        {
            return new Alojamiento
            {
                PuntoTuristico = punto,
                Descripcion = "Un lugar familiar",
                Direccion = "av BLR 1234",
                Estrellas = 5,
                InfoDeContacto = " SUPPORT",
                Nombre = "Hyatt",
                NroTelefono = " +5984412556",
                PrecioNoche = 50,
                SinCapacidad = false
            };
        }

        private Estadia CrearEstadia(FaseEdad[] rango)
        {
            return new Estadia
            {
                Entrada = DateTime.Now.AddDays(1),
                Salida = DateTime.Now.AddDays(4),
                RangoEdades = rango,
            };
        }

        private PuntoTuristico CrearPuntaDelEste()
        {
            return new PuntoTuristico
            {
                Categoria = new Categoria[] { Categoria.Playas, Categoria.Ciudades },
                Descripcion = "Un lugar bello",
                Nombre = "Punta del este",
                Region = Region.Este
            };
        }


    }
}
