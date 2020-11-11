using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ObligatorioDDA2.Models;
using ObligatorioDDA2.Models.Logic;

namespace ObligatorioDDA2.Controllers
{

    public class RegionesController : Controller
    {
        [HttpGet]
        public JsonResult Index()
        {
            List<Region> regiones = Sistema.GetInstancia().GetRegiones();
            List<string> retorno = new List<string>();
            foreach (var region in regiones)
                retorno.Add(region.ToString());

            return Json(retorno);
        }

    }
}
