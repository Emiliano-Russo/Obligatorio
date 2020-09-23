using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObligatorioDDA2.Models.Logic
{
    public class InfoReserva
    {
        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string Email { get; set; }

        public Estadia Estadia { get; set; }

        public Alojamiento Hotel { get; set; }
    }
}
