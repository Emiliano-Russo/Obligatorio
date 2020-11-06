using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ObligatorioDDA2.Controllers.EntidadesAlRecibir;
using ObligatorioDDA2.Models;
using ObligatorioDDA2.Models.Entidades;
using ObligatorioDDA2.Models.Logic;

namespace ObligatorioDDA2.Controllers
{
    public class HospedajesController : Controller
    {
        [HttpGet]
        public string Index()
        {
            return "faltan parametros";
        }

        [HttpPost]
        public JsonResult Busqueda([FromBody] Estancia e)
        {
            try
            {
                if (e == null)
                    throw  new Exception("Campos nulos");
                List<Hospedaje> hospedajes = Sistema.GetInstancia().GetHospedajes(e.Estadia, e.Punto);
                return Json(hospedajes);
                //return String.Concat(hospedajes.Select(h => h.ToString() + "\n"));
            }
            catch (Exception error)
            {
                return Json(error.Message);
            }
        }

        [HttpPost]
        public string Alta([FromBody]Alojamiento alojamiento)
        {
            try
            {
                SesionActual.NoExsiteLogin_Ex();
                Sistema.GetInstancia().IncluirAlojamiento(alojamiento);
            }
            catch (Exception e)
            {
                return e.Message;
            }

            return "Alojamiento registado";
        }

        [HttpPost]
        public string Baja([FromBody]Alojamiento alojamiento)
        {
            try
            {
                SesionActual.NoExsiteLogin_Ex();
                Sistema.GetInstancia().BorrarAlojamiento(alojamiento.Nombre);
            }
            catch (Exception e)
            {
                return e.Message;
            }

            return "Alojamiento borrado con exito";
        }

        [HttpGet]
        public string Modificar(string nombre,bool disponibilidad)
        {
            try
            {
                SesionActual.NoExsiteLogin_Ex();
                Sistema.GetInstancia().ModificarAlojamiento(nombre, disponibilidad);
            }
            catch (Exception e)
            {
                return e.Message;
            }

            return "Alojamiento modificado con exito";
        }




    }
}
