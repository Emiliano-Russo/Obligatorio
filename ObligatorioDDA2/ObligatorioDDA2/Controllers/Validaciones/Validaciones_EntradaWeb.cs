using ObligatorioDDA2.Models.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers.Validaciones
{
    public static class Validaciones_EntradaWeb
    {
        public static void ValidarRegion(int region)
        {
            if (region < 0 || region > GetLargoCategorias())
                throw new Exception("region no valida");
        }

        public static void EsNulo_Ex(object objeto)
        {
            if (objeto == null)
                throw new Exception("Valores nulos");
        }

        private static int GetLargoCategorias() => Enum.GetNames(typeof(Categoria)).Length;

        public static void ValidarCategorias(string categorias)
        {
            if (!categorias.All(char.IsDigit))
                throw new Exception("Solo se admiten numeros");
            int CeroEnAsciiCode = 48;
            foreach (char caracter in categorias)
                if (caracter < CeroEnAsciiCode || caracter > (CeroEnAsciiCode + GetLargoCategorias()))
                    throw new Exception("Categorias no existentes");
        }

    }
}
