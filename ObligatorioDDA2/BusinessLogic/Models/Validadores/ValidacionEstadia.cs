using ObligatorioDDA2.Models.Exceptions;
using ObligatorioDDA2.Models.Interfaces;
using ObligatorioDDA2.Models.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObligatorioDDA2.Models.Validadores
{
    public class ValidacionEstadia : Validacion<Estadia>
    {
        protected override void Existencia(Estadia objeto)
        {
            //no hay
        }

        protected override void Existencia(string key)
        {
            //no hay
        }

        protected override void NulosVacios(Estadia estadia)
        {
            bool estadiaCorrecta = estadia != null
                && estadia.Entrada < estadia.Salida
                && estadia.Entrada >= DateTime.Now
                && estadia.RangoEdades != null
                && estadia.RangoEdades.Length > 0;
            if (!estadiaCorrecta)
                throw new ExcepcionEstadiaInvalido("La estadia es incorrecta");
        }

        protected override void ObjetosDentro(Estadia objeto)
        {
            foreach (var edad in objeto.RangoEdades)
            {
                if ((int)edad < 0 || (int)edad > 3)
                    throw new ExcepcionEstadiaInvalido("Rango de edades invalidas");
            }
        }

        protected override void Unicidad(Estadia objeto)
        {
            //sin unicidad
        }
    }
}
