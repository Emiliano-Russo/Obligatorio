using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace ObligatorioDDA2.Models.Logic
{
    [Table("Reserva")]
    public class Reserva : IEquatable<Reserva>
    {
        public InfoReserva InfoReserva { get; set; }

        [Key]
        public string Codigo { get; set; }

        public EstadoReserva EstadoReserva { get; set; }

        public bool Equals([AllowNull] Reserva other)
        {
            return other.Codigo == this.Codigo;
        }

        public override string ToString()
        {
            return "codigo reserva: " + Codigo + "| Nro Telefono: "+InfoReserva.Hotel.NroTelefono+" | Info:"+InfoReserva.Hotel.InfoDeContacto;
        }
    }
}
