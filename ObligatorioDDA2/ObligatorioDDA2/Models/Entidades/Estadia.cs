using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ObligatorioDDA2.Models.Logic
{
    [Table("Estadia")]
    public class Estadia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Key { get; set; }

        public DateTime Entrada { get; set; }

        public DateTime Salida { get; set; }

        [NotMapped]
        public FaseEdad[] RangoEdades 
        
        {
            get
            {
                if (!String.IsNullOrEmpty(this.RangoEdadInterno_no_usar))
                    return Array.ConvertAll(RangoEdadInterno_no_usar.Split(';'), ToFaseEdad);
                else
                    return null;
            }
            set
            {
                RangoEdadInterno_no_usar = string.Join(";", value.Select(p => p.ToString()));
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public string RangoEdadInterno_no_usar { get; set; }

        private FaseEdad ToFaseEdad(string entrada)
        {
            if (Enum.TryParse(entrada, out FaseEdad faseEdad))
                return faseEdad;
            throw new ArgumentException($"Entrada '{entrada}' no puede ser parsed a ToFaseEdad", nameof(entrada));
        }

    }
}
