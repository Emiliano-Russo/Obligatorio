﻿using ObligatorioDDA2.Models;
using ObligatorioDDA2.Models.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogic.Models.Entidades.Logica_ReporteA
{
    internal class Logica_ReporteA
    {
        public List<Hotel_CantReservas> GetReporteA(InfoReporte info)
        {
            PuntoTuristico punto = new PuntoTuristico
            {
                Nombre = info.NombrePunto
            };
            List<Alojamiento> lista_alojamientos = Sistema.GetInstancia().repo.GetAlojamientos(punto);
            return Analizar_alojamientos(lista_alojamientos,info);
        }

        private List<Hotel_CantReservas> Analizar_alojamientos(List<Alojamiento> lista_alojamientos, InfoReporte info)
        {
            List<Hotel_CantReservas> lista_retorno = new List<Hotel_CantReservas>();
            foreach (var alojamiento in lista_alojamientos)
            {
                Unidad_ReporteA unidad = new Unidad_ReporteA
                {
                    Ingreso = info.Inicio,
                    Salida = info.Final,
                    Alojamiento = alojamiento
                };
                Hotel_CantReservas hc = new Hotel_CantReservas
                {
                    CantidadReservas = Sistema.GetInstancia().repo.GetReservasValidas(unidad).Count,
                    Hotel = alojamiento.Nombre
                };
                if (hc.CantidadReservas > 0)
                    lista_retorno.Add(hc);
            }
            lista_retorno = lista_retorno.OrderByDescending(x => x.CantidadReservas).ToList();
            return lista_retorno;
        }

    }
}
