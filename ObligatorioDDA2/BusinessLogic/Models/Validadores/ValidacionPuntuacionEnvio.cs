using BusinessLogic.Models.Entidades;
using ObligatorioDDA2.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Models.Validadores
{
    public class ValidacionPuntuacionEnvio : Validacion<Puntuacion_Recibir>
    {
        protected override void Existencia(Puntuacion_Recibir objeto)
        {
            throw new NotImplementedException();
        }

        protected override void Existencia(string key)
        {
            throw new NotImplementedException();
        }

        protected override void NulosVacios(Puntuacion_Recibir objeto)
        {
            throw new NotImplementedException();
        }

        protected override void ObjetosDentro(Puntuacion_Recibir objeto)
        {
            throw new NotImplementedException();
        }

        protected override void Unicidad(Puntuacion_Recibir objeto)
        {
            throw new NotImplementedException();
        }
    }
}
