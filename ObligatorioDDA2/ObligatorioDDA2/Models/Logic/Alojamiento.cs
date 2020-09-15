using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObligatorioDDA2.Models.Logic
{
    public class Alojamiento
    {
        public string Nombre { get; set; }

        public decimal Estrellas { get; set; }

        public PuntoTuristico PuntoTuristico { get; set; }

        public string Direccion { get; set; }

        public decimal PrecioNoche { get; set; }

        public string Descripcion { get; set; }

        public bool SinCapacidad { get; set; }

        public string NroTelefono { get; set; }

        public string InfoDeContacto { get; set; }

    }
}
