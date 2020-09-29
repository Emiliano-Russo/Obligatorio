using ObligatorioDDA2.Models.Exceptions;
using ObligatorioDDA2.Models.Interfaces;
using ObligatorioDDA2.Models.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObligatorioDDA2.Models.Validadores
{
    public class ValidacionAdmin : Validacion<Admin>
    {
        protected override void Existencia(Admin admin)
        {
            Sistema.GetInstancia().repo.Existe(admin);
        }

        protected override void Existencia(string key)
        {
           bool existe= Sistema.GetInstancia().repo.Existe(new Admin { email = key });
            if (!existe)
                throw new ExcepcionLogin("No existe: " + key + " en el sistema");
        }

        protected override void NulosVacios(Admin objeto)
        {
            bool valido = !String.IsNullOrEmpty(objeto.email) &&
                !String.IsNullOrEmpty(objeto.contrasenia);
            if (!valido)
                throw new ExcepcionLogin("Campos de login nulos o vacios");

        }

        protected override void ObjetosDentro(Admin admin)
        {
           //sin objetos dentro por validar
        }

        protected override void Unicidad(Admin admin)
        {
            bool adminExiste = Sistema.GetInstancia().repo.Existe(admin);
            if (adminExiste)
                throw new ExcepcionLogin("El admin ya existe");
        }
    }
}
