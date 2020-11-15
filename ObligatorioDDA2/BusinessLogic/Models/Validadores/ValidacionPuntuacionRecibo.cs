using BusinessLogic.Models.Entidades;
using ObligatorioDDA2.Models;
using ObligatorioDDA2.Models.Exceptions;
using ObligatorioDDA2.Models.Interfaces;
using ObligatorioDDA2.Models.Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Models.Validadores
{
    public class ValidacionPuntuacionRecibo : Validacion<Puntuacion_Recibir>
    {
        protected override void Existencia(Puntuacion_Recibir objeto)
        {
            throw new NotImplementedException();
        }

        protected override void Existencia(string key)
        {
            Reserva reserva = new Reserva { Codigo = key };
            if (!Sistema.GetInstancia().repo.Existe(reserva))
                throw new ExcepcionInfoInvalida("La reserva no existe");
        }

        protected override void NulosVacios(Puntuacion_Recibir objeto)
        {
            if (objeto.Codigo == null && objeto.Puntos >= 1 && objeto.Puntos <= 5)
                throw new Exception("Campos nulos!");
        }

        protected override void ObjetosDentro(Puntuacion_Recibir objeto)
        {
            return;
        }

        protected override void Unicidad(Puntuacion_Recibir objeto)
        {
            if (Sistema.GetInstancia().repo.Existe(objeto))
                throw new Exception("Ya existe un puntaje para esta reserva");
        }
    }
}
