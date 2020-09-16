using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObligatorioDDA2.Models.Exceptions
{
    public class ExcepcionAlojamientoInvalido : Exception
    {
        public ExcepcionAlojamientoInvalido(string error) : base("falta rellenar el/los campo/s: " + error)
        {

        }
    }
}
