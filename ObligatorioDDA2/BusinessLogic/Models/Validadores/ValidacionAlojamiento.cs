using ObligatorioDDA2.Models.Exceptions;
using ObligatorioDDA2.Models.Interfaces;
using ObligatorioDDA2.Models.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObligatorioDDA2.Models.Validadores
{
    public class ValidacionAlojamiento : Validacion<Alojamiento>
    {
        protected override void Existencia(Alojamiento alojamiento)
        {
            if (!Sistema.GetInstancia().repo.Existe(alojamiento))
                throw new ExcepcionAlojamientoInvalido("El alojamiento no existe");
        }

        protected override void Existencia(string key)
        {
            if (!Sistema.GetInstancia().repo.Existe(new Alojamiento { Nombre = key }))
                throw new ExcepcionAlojamientoInvalido("No existe el alojamiento: " + key);
        }

        protected override void NulosVacios(Alojamiento alojamiento)
        {
            bool alojamientoInvalido = String.IsNullOrEmpty(alojamiento.Nombre) ||
              String.IsNullOrEmpty(alojamiento.InfoDeContacto) ||
              String.IsNullOrEmpty(alojamiento.NroTelefono) ||
              alojamiento.PrecioNoche <= 0 ||
               String.IsNullOrEmpty(alojamiento.Descripcion) ||
                String.IsNullOrEmpty(alojamiento.Direccion) ||
                alojamiento.Estrellas <= 0 ||
                alojamiento.Estrellas >= 6;

            if (alojamientoInvalido)
                throw new ExcepcionAlojamientoInvalido("Objeto Invalido");
        }

        protected override void ObjetosDentro(Alojamiento alojamiento)
        {
            Sistema.GetInstancia().validacionPuntoTursitico.ValidarSintaxisExitencia(alojamiento.PuntoTuristico);
        }

        protected override void Unicidad(Alojamiento alojamiento)
        {
            if (Sistema.GetInstancia().repo.Existe(alojamiento))
                throw new ExcepcionAlojamientoInvalido("El alojamiento ya existe");
        }
    }
}
