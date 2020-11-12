using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObligatorioDDA2.Models;
using ObligatorioDDA2.Models.Exceptions;
using ObligatorioDDA2.Models.Logic;
using System;
using System.Collections.Generic;
using ObligatorioDDA2.Models.Entidades;
using BusinessLogic.Models.Entidades;
using TestLogic.WebApi;
using Castle.Core.Internal;

namespace TestLogic
{

    public partial class SistemaTest
    {
        [TestMethod]
        public void TestPuntuacion()
        {
            Reg_PuntoAlojamiento();
            Reserva reserva = CrearReserva();
            Puntuacion_Recibir puntuacion = CrearPuntuacion(reserva.Codigo);

            sistema.Puntuar(puntuacion);

            List<Puntuacion_Recibir> lista_punajes = sistema.GetPuntuaciones(OAR.hotel.Nombre);
            Assert.IsTrue(lista_punajes.Count == 1);
            Assert.IsTrue(lista_punajes[0].Puntos == 5);
            Assert.IsTrue(lista_punajes[0].Codigo == reserva.Codigo);
            sistema.BorrarReservas();
        }

        private void Reg_PuntoAlojamiento()
        {
            sistema.IncluirPuntoTuristico(OAR.puntaDelEste);
            sistema.IncluirAlojamiento(OAR.hotel);
        }

        private Reserva CrearReserva()
        {
            InfoReserva info = new InfoReserva
            {
                Nombre = "Ismael",
                Apellido = "Rodriguez",
                Email = "example@gmail.com",
                Estadia = OAR.estadiaVacacional,
                Hotel = OAR.hotel
            };

            return sistema.CrearReserva(info);
        }

        private Puntuacion_Recibir CrearPuntuacion(string codigo)
        {
            return new Puntuacion_Recibir
            {
                Codigo = codigo,
                Comentario = "Muy buen hotel!",
                Puntos = 5
            };
        }

        [TestMethod]
        [ExpectedException(typeof(ExcepcionInfoInvalida))]
        public void TestPuntuacion_Excepcion()
        {
            Puntuacion_Recibir puntuacion = new Puntuacion_Recibir
            {
                Codigo = "wlwlwlwlwl",
                Comentario = "Muy buen hotel!",
                Puntos = 4
            };

            sistema.Puntuar(puntuacion);
        }

        [TestMethod]
        public void TestPuntuacion_Varios()
        {
            Reg_PuntoAlojamiento();
            Reserva reserva1 = CrearReserva();
            Reserva reserva2 = CrearReserva();
            Puntuacion_Recibir puntuacion1 = CrearPuntuacion(reserva1.Codigo);
            Puntuacion_Recibir puntuacion2 = CrearPuntuacion(reserva2.Codigo);

            sistema.Puntuar(puntuacion1);
            sistema.Puntuar(puntuacion2);

            List<Puntuacion_Recibir> lista_punajes = sistema.GetPuntuaciones(OAR.hotel.Nombre);
            Assert.IsTrue(lista_punajes.Count == 2);
            Assert.IsTrue(lista_punajes[0].Puntos == 5 && lista_punajes[1].Puntos == 5);
            Assert.IsTrue(lista_punajes.Contains(puntuacion1) && lista_punajes.Contains(puntuacion2));
            sistema.BorrarReservas();
        }

    }
}
