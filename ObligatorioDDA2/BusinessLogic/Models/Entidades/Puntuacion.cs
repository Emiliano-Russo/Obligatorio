using ObligatorioDDA2.Models.Logic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BusinessLogic.Models.Entidades.Repositorio
{
    [Table("Puntuacion")]
    public class Puntuacion
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Key { get; set; }

        public int Puntos { get; set; }

        public string Comentario { get; set; }

        public Reserva Reserva { get; set; }
    }
}
