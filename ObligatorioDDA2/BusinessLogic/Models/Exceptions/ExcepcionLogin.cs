using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObligatorioDDA2.Models.Exceptions
{
    public class ExcepcionLogin : Exception
    {
        public ExcepcionLogin(string error) : base(error)
        {

        }
    }
}
