using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace ObligatorioDDA2.Models.Logic
{
    public class PuntoTuristico : IEquatable<PuntoTuristico>
    {
        [Key]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public Region Region { get; set; }

        [NotMapped]
        public Categoria[] Categoria 
        {

            get
            {
                if (!String.IsNullOrEmpty(CategoriasInterno_no_usar))
                    return Array.ConvertAll(CategoriasInterno_no_usar.Split(';'), ToCategorias);
                else
                    return null;
            }
            set
            {
                if (value != null)
                    CategoriasInterno_no_usar = string.Join(";", value.Select(p => p.ToString()));
                else
                    CategoriasInterno_no_usar = null;
            }
        }
      
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string CategoriasInterno_no_usar { get; set; }

        [NotMapped]
        public string[] ImgName
        {
            get
            {
                if (!String.IsNullOrEmpty(ImgNameInterno_no_usar))
                    return ImgNameInterno_no_usar.Split(';');
                else
                    return null;
            }
            set
            {
                if (value != null)
                    ImgNameInterno_no_usar = string.Join(";", value.Select(p => p.ToString()));
                else
                    ImgNameInterno_no_usar = null;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ImgNameInterno_no_usar { get; set; }
      
        private Categoria ToCategorias(string entrada)
        {
            if (Enum.TryParse(entrada, out Categoria categoria))
                return categoria;
            throw new ArgumentException($"Entrada '{entrada}' no puede ser parsed a ToFaseEdad", nameof(entrada));
        }



        public bool Equals(PuntoTuristico other)
        {
            return (other != null && Nombre == other.Nombre);
        }

        public override string ToString()
        {
            string categorias = "";
            foreach (var item in Categoria)
                categorias += item.ToString() + "/ ";
            return Nombre + ": " + Descripcion + " | Region: " + Region + " | Categorias: "+ categorias;
        }
    }
}
