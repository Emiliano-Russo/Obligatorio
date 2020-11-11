using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObligatorioDDA2.Models.Exceptions
{
    public class ExcepcionPuntoTuristicoInvalido : Exception
    {
        public ExcepcionPuntoTuristicoInvalido(string error):base(error)
        {

        }
    }
}
