using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace ObligatorioDDA2.Models.Logic
{
    [Table("Alojamiento")]
    public class Alojamiento : IEquatable<Alojamiento>
    {
        [Key]
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

        public override string ToString()
        {
            return this.Nombre + "| Descripcion: " + this.Descripcion +" | Punto Turistico: "+this.PuntoTuristico.Nombre
                + " | Direccion: " + this.Direccion + "| Estrellas: " + this.Estrellas
                + " | Precio Noche " + this.PrecioNoche + " $ | ";
        }
    }
}
