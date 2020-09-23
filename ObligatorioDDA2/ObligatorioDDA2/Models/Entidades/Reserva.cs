using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace ObligatorioDDA2.Models.Logic
{
    public class Reserva : IEquatable<Reserva>
    {
        public InfoReserva InfoReserva { get; set; }

        public string Codigo { get; set; }

        public EstadoReserva EstadoReserva { get; set; }

        public string Descripcion { get; set; }

        public bool Equals([AllowNull] Reserva other)
        {
            return other.Codigo == this.Codigo;
        }
    }
}
