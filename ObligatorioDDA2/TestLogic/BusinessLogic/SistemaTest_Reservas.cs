using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObligatorioDDA2.Models;
using ObligatorioDDA2.Models.Exceptions;
using ObligatorioDDA2.Models.Logic;
using System;
using System.Collections.Generic;
using ObligatorioDDA2.Models.Entidades;

namespace TestLogic
{
    public partial class SistemaTest
    {

        //CrearReserva
        [TestMethod]
       [ExpectedException(typeof(ExcepcionAlojamientoInvalido))]
        public void CrearReserva_AlojamientoInvalido()
        {
            InfoReserva info = new InfoReserva
            {
                Apellido = "Gonzalez",
                Nombre = "Juan",
                Email = "Juan@antel.com",
                Hotel = new Alojamiento(),
                Estadia = estadiaVacacional
            };
            sistema.CrearReserva(info);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionEstadiaInvalido))]
        public void CrearReserva_EstadiaInvalido()
        {
            Alojamiento Radison = new Alojamiento
            {
                Descripcion = "Un lugar con ambiente familiar",
                Direccion = "Avenida 123",
                Estrellas = 3f,
                InfoDeContacto = "Bienvenido al hotel",
                Nombre = "Radison",
                NroTelefono = "092777555",
                PrecioNoche = 100,
                PuntoTuristico = puntaDelEste,
                SinCapacidad = false
            };
            InfoReserva info = new InfoReserva
            {
                Apellido = "Gonzalez",
                Nombre = "Juan",
                Email = "Juan@antel.com",
                Hotel = Radison,
                Estadia = null
            };
            sistema.CrearReserva(info);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionInfoInvalida))]
        public void CrearReserva_InfoValida1()
        {
            Alojamiento Radison = new Alojamiento
            {
                Descripcion = "Un lugar con ambiente familiar",
                Direccion = "Avenida 123",
                Estrellas = 4.5f,
                InfoDeContacto = "Bienvenido al hotel",
                Nombre = "Radison",
                NroTelefono = "092777555",
                PrecioNoche = 100,
                PuntoTuristico = puntaDelEste,
                SinCapacidad = false
            };
            InfoReserva info = new InfoReserva
            {
                Apellido = "",
                Nombre = "Juan",
                Email = "Juan@antel.com",
                Hotel = Radison,
                Estadia = estadiaVacacional
            };
            sistema.CrearReserva(info);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionInfoInvalida))]
        public void CrearReserva_InfoValida2()
        {
            Alojamiento Radison = new Alojamiento
            {
                Descripcion = "Un lugar con ambiente familiar",
                Direccion = "Avenida 123",
                Estrellas = 4.5f,
                InfoDeContacto = "Bienvenido al hotel",
                Nombre = "Radison",
                NroTelefono = "092777555",
                PrecioNoche = 100,
                PuntoTuristico = puntaDelEste,
                SinCapacidad = false
            };
            InfoReserva info = new InfoReserva
            {
                Apellido = "Gonzalez",
                Nombre = "Juan",
                Email = "",
                Hotel = Radison,
                Estadia = estadiaVacacional
            };
            sistema.CrearReserva(info);
        }

        //ConsultarReserva
        [TestMethod]
        [ExpectedException(typeof(ExcepcionInfoInvalida))]
        public void ConsutlarReserva_InfoInvalida()
        {
            sistema.ConsultarReserva("ASDdas");
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionInfoInvalida))]
        public void ConsutlarReserva_InfoInvalida2()
        {
            sistema.ConsultarReserva(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionInfoInvalida))]
        public void ConsutlarReserva_InfoInvalida3()
        {
            sistema.ConsultarReserva("");
        }

        [TestMethod]
        public void ConsutlarReserva_Valido()
        {
            BorrarHotelesYPuntos();
            sistema.BorrarReservas();
            Alojamiento Radison = new Alojamiento
            {
                Descripcion = "Un lugar con ambiente familiar",
                Direccion = "Avenida 123",
                Estrellas = 4.5f,
                InfoDeContacto = "Bienvenido al hotel",
                Nombre = "Radison",
                NroTelefono = "092777555",
                PrecioNoche = 100,
                PuntoTuristico = puntaDelEste,
                SinCapacidad = false
            };
            sistema.IncluirPuntoTuristico(puntaDelEste);
            sistema.IncluirAlojamiento(Radison);

            InfoReserva info = new InfoReserva
            {
                Nombre = "Guillermo",
                Apellido = "Suarez",
                Hotel = Radison,
                Estadia = estadiaVacacional,
                Email = "guille@suarez.com"
            };
            Reserva reserva = sistema.CrearReserva(info);
            ConsultaEstado ce = sistema.ConsultarReserva(reserva.Codigo);
            Assert.AreEqual(ce.Estado, EstadoReserva.Creada);
            Assert.AreEqual(ce.Nombre, info.Nombre);
            string descripcion = "Codigo reservado por mail: " + info.Email;
            Assert.AreEqual(ce.Descripcion,descripcion);
            string resultToString = ce.ToString();
            string esperadoToString = "Nombre: " + ce.Nombre + " | Estado: " + ce.Estado + " | Descripcion: " + ce.Descripcion;
            Assert.AreEqual(esperadoToString,resultToString);
            sistema.BorrarReservas();
        }


        //Cambiar estado reserva
        [TestMethod]
        [ExpectedException(typeof(ExcepcionInfoInvalida))]
        public void CambiarEstadoReserva_CodigoInexistente()
        {
            sistema.CambiarEstadoReserva("asd", EstadoReserva.Expirada);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionInfoInvalida))]
        public void CambiarEstadoReserva_CodigoInexistente2()
        {
            sistema.CambiarEstadoReserva("", EstadoReserva.Expirada);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionInfoInvalida))]
        public void CambiarEstadoReserva_CodigoInexistente3()
        {
            sistema.CambiarEstadoReserva(null, EstadoReserva.Expirada);
        }

       [TestMethod]
        public void CambiarEstadoReserva_Valido()
        {
            BorrarHotelesYPuntos();
            
            Alojamiento Radison = new Alojamiento
            {
                Descripcion = "Un lugar con ambiente familiar",
                Direccion = "Avenida 123",
                Estrellas = 4.5f,
                InfoDeContacto = "Bienvenido al hotel",
                Nombre = "Radison",
                NroTelefono = "092777555",
                PrecioNoche = 100,
                PuntoTuristico = puntaDelEste,
                SinCapacidad = false
            };
            sistema.IncluirPuntoTuristico(puntaDelEste);
            sistema.IncluirAlojamiento(Radison);

            FaseEdad[] fe = estadiaVacacional.RangoEdades;
            estadiaVacacional.RangoEdades = null;
            Assert.IsNull(estadiaVacacional.RangoEdades);
            estadiaVacacional.RangoEdades = fe;

            InfoReserva info = new InfoReserva
            {
                Nombre = "Guillermo",
                Apellido = "Suarez",
                Hotel = Radison,
                Estadia = estadiaVacacional,
                Email = "guille@suarez.com"
            };
            Reserva reserva = sistema.CrearReserva(info);
            Assert.IsTrue(reserva.EstadoReserva == EstadoReserva.Creada);
            sistema.CambiarEstadoReserva(reserva.Codigo,EstadoReserva.Pendiente_Pago);
            ConsultaEstado ce = sistema.ConsultarReserva(reserva.Codigo);
            Assert.IsTrue(ce.Estado == EstadoReserva.Pendiente_Pago);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FaseEdadIncorrecto()
        {
            Estadia estadia = new Estadia
            {
                Key = 4,
                Entrada = estadiaVacacional.Entrada,
                Salida = estadiaVacacional.Salida,
                RangoEdades = estadiaVacacional.RangoEdades
            };
            Assert.AreEqual(4,estadia.Key);
            estadia.RangoEdadInterno_no_usar = "ksadjfskj;asdasdasd;asd";
            FaseEdad[] fe =  estadia.RangoEdades;
        }

        [TestMethod]
        public void TestKeyInfoReserva()
        {
            InfoReserva info = new InfoReserva
            {
                Key = 5
            };
            Assert.AreEqual(5,info.Key);
        }

        [TestMethod]
        public void ToStringDeReserva()
        {
            Alojamiento Radison = new Alojamiento
            {
                Descripcion = "Un lugar con ambiente familiar",
                Direccion = "Avenida 123",
                Estrellas = 4.5f,
                InfoDeContacto = "Bienvenido al hotel",
                Nombre = "Radison",
                NroTelefono = "092777555",
                PrecioNoche = 100,
                PuntoTuristico = puntaDelEste,
                SinCapacidad = false
            };

            InfoReserva info = new InfoReserva
            {
                Nombre = "Guillermo",
                Apellido = "Suarez",
                Hotel = Radison,
                Estadia = estadiaVacacional,
                Email = "guille@suarez.com"
            };

            Reserva reserva = new Reserva
            {
                Codigo = CodigoRandom.GetCodigoRandomUnico(10),
                EstadoReserva = EstadoReserva.Creada,
                InfoReserva = info
            };

            string resultado = reserva.ToString();
            string esperado = "codigo reserva: " + reserva.Codigo + "| Nro Telefono: " + info.Hotel.NroTelefono + " | Info:" + info.Hotel.InfoDeContacto;
            Assert.AreEqual(esperado,resultado);
        }


        [TestMethod]
        [ExpectedException(typeof(ExcepcionAlojamientoInvalido))]
        public void CrearReserva_AlojamientoInExistente() //bug en test cover
        {
            Alojamiento HectorPlace = new Alojamiento
            {
                Descripcion = "Un lugar con ambiente familiar",
                Direccion = "Avenida 123",
                Estrellas = 4.5f,
                InfoDeContacto = "Bienvenido al hotel",
                Nombre = "HectorPlace",
                NroTelefono = "092777555",
                PrecioNoche = 100,
                PuntoTuristico = puntaDelEste,
                SinCapacidad = false
            };

            InfoReserva info = new InfoReserva
            {
                Nombre = "Guillermo",
                Apellido = "Suarez",
                Hotel = HectorPlace,
                Estadia = estadiaVacacional,
                Email = "guille@suarez.com"
            };
            sistema.IncluirPuntoTuristico(puntaDelEste);
            sistema.CrearReserva(info);
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionInfoInvalida))]
        public void InfoNull_Excepcion()
        {
            sistema.CrearReserva(null);
        }


    }
}
