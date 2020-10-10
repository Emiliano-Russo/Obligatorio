using ObligatorioDDA2.Models.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObligatorioDDA2.Models
{
    public class ConsultaEstado
    {
        public EstadoReserva Estado { get; set; }

        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public override string ToString()
        {
            return "Nombre: "+Nombre+" | Estado: "+ Estado + " | Descripcion: "+Descripcion;
        }
    }
}
