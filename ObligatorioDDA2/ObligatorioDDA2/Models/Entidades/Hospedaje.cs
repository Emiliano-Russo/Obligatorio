using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObligatorioDDA2.Models.Logic
{
    //objeto que se manda como retorno hacia la pagina
    public class Hospedaje
    {

        public Alojamiento Alojamiento { get; set; }

        public decimal PrecioTotal { get; set; }
    }
}
