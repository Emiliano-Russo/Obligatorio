using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ObligatorioDDA2.Models;
using ObligatorioDDA2.Models.Entidades;
using ObligatorioDDA2.Models.Logic;
using WebApi.Controllers.Validaciones;

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
        public JsonResult Alta([FromBody] PuntoTuristico punto)
        {
            try
            {
                SesionActual.NoExsiteLogin_Ex();
                Sistema.GetInstancia().IncluirPuntoTuristico(punto);
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
            return Json("Punto incluido exitosamente");
        }

        private JsonResult BusquedaPuntosPorRegion(int region)
        {
            try
            {
                Validaciones_EntradaWeb.ValidarRegion(region);
                return Json(Sistema.GetInstancia().GetPuntosTuristicos((Region)region));
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
                Validaciones_EntradaWeb.ValidarCategorias(categorias);
                Validaciones_EntradaWeb.ValidarRegion(region);
                return DevolverPuntosJson(region, categorias);
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }


        private JsonResult DevolverPuntosJson(int region, string categorias)
        {
            Categoria[] arrayCategorias = this.GetCategorias(categorias);
            List<PuntoTuristico> listaPuntos = Sistema.GetInstancia().GetPuntosTuristicos((Region)region, arrayCategorias);
            return Json(listaPuntos);
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
