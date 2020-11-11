using ObligatorioDDA2.Models.Exceptions;
using ObligatorioDDA2.Models.Interfaces;
using ObligatorioDDA2.Models.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObligatorioDDA2.Models.Validadores
{
    public class ValidacionPuntoTuristico : Validacion<PuntoTuristico>
    {
        protected override void NulosVacios(PuntoTuristico puntoTuristico)
        {
            bool esNulloVacio = puntoTuristico == null || (puntoTuristico.Categoria == null ||
                String.IsNullOrEmpty(puntoTuristico.Descripcion) ||
                String.IsNullOrEmpty(puntoTuristico.Nombre));
            if (esNulloVacio)
                throw new ExcepcionPuntoTuristicoInvalido("campos nulos");
          
        }

        protected override void ObjetosDentro(PuntoTuristico puntoTuristico)
        {
            bool largoMenorQueCincoYMayorQueCero = puntoTuristico.Categoria.Length <= Enum.GetNames(typeof(Categoria)).Length && puntoTuristico.Categoria.Length > 0;
            bool categoriasRepetidas = puntoTuristico.Categoria.GroupBy(x => x)
             .Where(g => g.Count() > 1)
             .Select(y => y.Key)
             .ToList().Count > 0;

            if (largoMenorQueCincoYMayorQueCero && !categoriasRepetidas)
                return;
            else
                throw new ExcepcionPuntoTuristicoInvalido("demasiadas/repetidas cateogorias");
        }

        protected override void Unicidad(PuntoTuristico puntoTuristico)
        {
            if (Sistema.GetInstancia().repo.Existe(puntoTuristico))
                throw new ExcepcionPuntoTuristicoInvalido("Ya existe este punto turistico");
        }

        protected override void Existencia(PuntoTuristico puntoTuristico)
        {
            if (!Sistema.GetInstancia().repo.Existe(puntoTuristico))
                throw new ExcepcionPuntoTuristicoInvalido("Punto turistico no existe");
        }

        protected override void Existencia(string key)
        {

        }
    }
}
