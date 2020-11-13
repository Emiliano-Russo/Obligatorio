using ObligatorioDDA2.Models.Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.Models.Entidades
{
    public class Puntuacion_Recibir : IEquatable<Puntuacion_Recibir>
    {
        public int Puntos { get; set; }

        public string Comentario { get; set; }

        public string Codigo { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public bool Equals(Puntuacion_Recibir obj)
        {
            return obj != null && obj.Codigo == this.Codigo &&
                obj.Comentario == this.Comentario && obj.Puntos == this.Puntos;
        }
    }
}
