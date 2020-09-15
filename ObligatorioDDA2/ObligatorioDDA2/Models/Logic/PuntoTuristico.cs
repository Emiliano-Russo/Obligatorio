using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObligatorioDDA2.Models.Logic
{
    public class PuntoTuristico
    {
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public Region Region { get; set; }

        public Categoria Categoria { get; set; }

        public string[] ImgName { get; set; }
    }
}
