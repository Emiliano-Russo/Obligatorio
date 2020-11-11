using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ObligatorioDDA2.Models;
using ObligatorioDDA2.Models.Exceptions;
using ObligatorioDDA2.Models.Logic;

namespace ObligatorioDDA2.Controllers
{
    public class LoginController : Controller
    {
        public JsonResult Index()
        {
            return Json("Pagina Login");
        }
        [HttpGet]
        public JsonResult Ingresar(string email, string contra)
        {
            try
            {
                SesionActual.ExisteLogin_Ex();
                if (!Sistema.GetInstancia().ValidacionLogin(new Admin { email = email, contrasenia = contra }))
                    throw new ExcepcionLogin("Credenciales no validas");
                HttpContext.Session.SetString("usuario", email);
                SesionActual.Sesion = HttpContext.Session;
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }

            return Json("Login Exitoso!");
        }

    }
}
