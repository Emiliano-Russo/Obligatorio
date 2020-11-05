using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ObligatorioDDA2.Models;
using ObligatorioDDA2.Models.Entidades;
using ObligatorioDDA2.Models.Logic;

namespace ObligatorioDDA2.Controllers
{
    public class PuntosTuristicosController : Controller
    {

        [HttpGet]
        public string Index() => "Especificar parametros en url";


        [HttpGet]
        public JsonResult Busqueda(int region, string categorias)
        {
            if (categorias == null)
                return BusquedaPuntosPorRegion(region);
            else
                return BusquedaPuntosPorRegionCategoria(region, categorias);
        }


        [HttpPost]
        public string Alta([FromBody] PuntoTuristico punto)
        {
            try
            {
                SesionActual.NoExsiteLogin_Ex();
                Sistema.GetInstancia().IncluirPuntoTuristico(punto);
            }
            catch (Exception e)
            {
                return e.Message;
            }
            return "Punto incluido exitosamente";
        }

        private JsonResult BusquedaPuntosPorRegion(int region)
        {
            try
            {
                ValidarRegion(region);
                return Json(Sistema.GetInstancia().GetPuntosTuristicos((Region)region));
                //return ArmarListaDePuntosString(Sistema.GetInstancia().GetPuntosTuristicos((Region)region));
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }

        private JsonResult BusquedaPuntosPorRegionCategoria(int region, string categorias)
        {
            try
            {
                ValidarCategorias(categorias);
                ValidarRegion(region);
                return DevolverPuntosString(region, categorias);
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }

        //borrar?
        private JsonResult ArmarListaDePuntosString(List<PuntoTuristico> listaPuntos)
        {
            List<string> puntosString = new List<string>();
            foreach (var punto in listaPuntos)
            {
                puntosString.Add(punto.ToString());
            }
           

            return Json(puntosString);
        }



        private JsonResult DevolverPuntosString(int region, string categorias)
        {
            Categoria[] arrayCategorias = this.GetCategorias(categorias);
            List<PuntoTuristico> listaPuntos = Sistema.GetInstancia().GetPuntosTuristicos((Region)region, arrayCategorias);
            return Json(listaPuntos);
            //return ArmarListaDePuntosString(listaPuntos);
        }

        private void ValidarRegion(int region)
        {
            if (region < 0 || region > GetLargoCategorias())
                throw new Exception("region no valida");
        }

        private int GetLargoCategorias() => Enum.GetNames(typeof(Categoria)).Length;

        private void ValidarCategorias(string categorias)
        {
            if (!categorias.All(char.IsDigit))
                throw new Exception("Solo se admiten numeros");
            int CeroEnAsciiCode = 48;
            foreach (char caracter in categorias)
                if (caracter < CeroEnAsciiCode || caracter > (CeroEnAsciiCode + GetLargoCategorias()))
                    throw new Exception("Categorias no existentes");
        }

        private Categoria[] GetCategorias(string categorias)
        {
            List<Categoria> lista = new List<Categoria>();
            for (int i = 0; i < categorias.Length; i++)
                lista.Add(transofmarChar(categorias[i]));

            return lista.ToArray();
        }

        private Categoria transofmarChar(char caracter)
        {
            int categoria = caracter - '0';
            return (Categoria)categoria;
        }
    }
}
