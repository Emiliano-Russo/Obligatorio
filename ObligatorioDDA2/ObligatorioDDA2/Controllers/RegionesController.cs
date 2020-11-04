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
        public string Index()
        {
            List<Region> regiones = Sistema.GetInstancia().GetRegiones();
            string retorno = "";
            foreach (var region in regiones)           
                retorno += region.ToString()+ " / ";
            
            return retorno;
        }

        [HttpGet]
        public JsonResult Hola()
        {
            return Json(Sistema.GetInstancia().GetRegiones());
        }

        

        
    }
}
