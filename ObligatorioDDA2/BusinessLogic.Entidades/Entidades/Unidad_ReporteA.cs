using ObligatorioDDA2.Models.Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Models.Entidades
{
    public class Unidad_ReporteA
    {
        public DateTime Ingreso { get; set; }

        public DateTime Salida { get; set; }

        public Alojamiento Alojamiento { get; set; }
    }
}
