using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace ObligatorioDDA2.Models.Logic
{
    public class Alojamiento : IEquatable<Alojamiento>
    {
        public string Nombre { get; set; }

        public float Estrellas { get; set; }

        public PuntoTuristico PuntoTuristico { get; set; }

        public string Direccion { get; set; }

        public float PrecioNoche { get; set; }

        public string Descripcion { get; set; }

        public bool SinCapacidad { get; set; }

        public string NroTelefono { get; set; }

        public string InfoDeContacto { get; set; }

        public bool Equals([AllowNull] Alojamiento other)
        {
            return other.Nombre == this.Nombre;
        }
    }
}
