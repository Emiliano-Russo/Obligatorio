using ObligatorioDDA2.Models.Exceptions;
using ObligatorioDDA2.Models.Interfaces;
using ObligatorioDDA2.Models.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObligatorioDDA2.Models.Validadores
{
    public class ValidacionInfoReserva : Validacion<InfoReserva>
    {
        protected override void Existencia(InfoReserva info)
        {
           //no hay
        }

        protected override void Existencia(string key)
        {
            if (!Sistema.GetInstancia().repo.Existe(new Reserva { Codigo = key }))
                throw new ExcepcionInfoInvalida("No existe " + key + " en nuestro sistema");
        }

        protected override void NulosVacios(InfoReserva info)
        {
            if (info == null)
                throw new ExcepcionInfoInvalida("informacion de reserva nula");

            bool infoInvalida = String.IsNullOrEmpty(info.Nombre) ||
               String.IsNullOrEmpty(info.Apellido) ||
               String.IsNullOrEmpty(info.Email);
            if (infoInvalida)
                throw new ExcepcionInfoInvalida("info invalida");
        }

        protected override void ObjetosDentro(InfoReserva info)
        {           
            Sistema.GetInstancia().validacionEstadia.ValidarSintaxis(info.Estadia);
            Sistema.GetInstancia().validacionAlojamiento.ValidarSintaxisExitencia(info.Hotel);
        }

        protected override void Unicidad(InfoReserva info)
        {
            //no hay
        }
    }
}
