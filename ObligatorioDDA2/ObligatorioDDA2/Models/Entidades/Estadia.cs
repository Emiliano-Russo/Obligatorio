using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObligatorioDDA2.Models.Logic
{
    public class Estadia
    {
        public DateTime Entrada { get; set; }

        public DateTime Salida { get; set; }

        public FaseEdad[] RangoEdades { get; set; }

    }
}
