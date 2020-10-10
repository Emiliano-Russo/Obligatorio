using ObligatorioDDA2.Models.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObligatorioDDA2.Controllers.EntidadesAlRecibir
{
    public class Estancia
    {
        public PuntoTuristico Punto { get; set; }

        public Estadia Estadia { get; set; }
    }
}
