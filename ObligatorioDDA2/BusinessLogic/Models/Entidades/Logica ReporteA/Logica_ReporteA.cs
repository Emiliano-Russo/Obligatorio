using ObligatorioDDA2.Models;
using ObligatorioDDA2.Models.Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Models.Entidades.Logica_ReporteA
{
    internal class Logica_ReporteA
    {
        public List<Hotel_CantReservas> GetReporteA(InfoReporte info)
        {
            List<Hotel_CantReservas> lista_retorno = new List<Hotel_CantReservas>();
            PuntoTuristico punto = new PuntoTuristico
            {
                Nombre = info.NombrePunto
            };
            List<Alojamiento> lista_alojamientos = Sistema.GetInstancia().repo.GetAlojamientos(punto);
            foreach (var alojamiento in lista_alojamientos)
            {
                Hotel_CantReservas hc = new Hotel_CantReservas
                {
                    CantidadReservas = Sistema.GetInstancia().repo.GetReservasValidas(info).Count,
                    Hotel = alojamiento.Nombre
                };
                if (hc.CantidadReservas > 0)
                    lista_retorno.Add(hc);
            }
            return lista_retorno;
        }

    }
}
