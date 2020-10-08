using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace ObligatorioDDA2.Models.Logic
{
    //objeto que se manda como retorno hacia la pagina
    public class Hospedaje : IEquatable<Hospedaje>
    {
        public Alojamiento Alojamiento { get; set; }

        public float PrecioTotal { get; set; }

        public Hospedaje(Alojamiento a,Estadia e)
        {
            PrecioTotal = CalcularPrecioTotal(a.PrecioNoche, e);
            Alojamiento = a;
        }

        private float CalcularPrecioTotal(float precioNoche, Estadia estadia)
        {
            float precioTotal = 0;
            TimeSpan tiempo = estadia.Salida - estadia.Entrada;
            int cantidadAdultos = Array.FindAll(estadia.RangoEdades, x => x == FaseEdad.Adulto).Length;
            int cantidadNinios = Array.FindAll(estadia.RangoEdades, x => x == FaseEdad.Ninio).Length;
            int cantidadBebes = Array.FindAll(estadia.RangoEdades, x => x == FaseEdad.Bebe).Length;

            precioTotal += cantidadAdultos * precioNoche * (float)tiempo.TotalDays;
            precioTotal += cantidadNinios * precioNoche * (float)tiempo.TotalDays * 0.5f;
            precioTotal += cantidadBebes * precioNoche * (float)tiempo.TotalDays * 0.25f;

            return precioTotal;
        }

        public override string ToString()
        {
            return this.Alojamiento.ToString()  + "Precio total: "+ this.PrecioTotal + " $";
        }

        public bool Equals([AllowNull] Hospedaje other)
        {
            return other.Alojamiento.Equals(this.Alojamiento) && other.PrecioTotal == this.PrecioTotal;
        }
    }
}
