using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObligatorioDDA2.Models.Interfaces
{
    public abstract class Validacion<T>
    {
        protected abstract void NulosVacios(T objeto);

        protected abstract void ObjetosDentro(T objeto);

        protected abstract void Unicidad(T objeto);

        protected abstract void Existencia(T objeto);

        protected abstract void Existencia(string key);


        public virtual void ValidarRegistro(T objeto)
        {
            ValidarSintaxis(objeto);
            Unicidad(objeto);
        }

        public virtual void ValidarSintaxis(T objeto)
        {
            NulosVacios(objeto);
            ObjetosDentro(objeto);
        }

        public virtual void ValidarSintaxisExitencia(T objeto)
        {
            ValidarSintaxis(objeto);
            Existencia(objeto);
        }

        public void ValidarString(string texto, Exception e)
        {
            if (String.IsNullOrEmpty(texto))
                throw e;
        }

        public void ValidarExistencia(string key)
        {
            Existencia(key);
        }
    }
}
