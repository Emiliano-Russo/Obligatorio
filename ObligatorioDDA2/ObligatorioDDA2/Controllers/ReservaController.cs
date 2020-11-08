﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ObligatorioDDA2.Models;
using ObligatorioDDA2.Models.Entidades;
using ObligatorioDDA2.Models.Logic;

namespace ObligatorioDDA2.Controllers
{
    public class ReservaController : Controller
    {
        public string Index()
        {
            return "Por favor ingrese los datos";
        }

        [HttpPost]
        public JsonResult Reservar([FromBody] InfoReserva info)
        {
            Reserva res;
            try
            {
                res = Sistema.GetInstancia().CrearReserva(info);
            }
            catch (Exception e)
            {
                return Json(e.Message);
            };
            return Json(res);
        }

        [HttpGet]
        public string CambiarEstado(string codigo, int estado)
        {
            try
            {
                SesionActual.NoExsiteLogin_Ex();
                Sistema.GetInstancia().CambiarEstadoReserva(codigo, (EstadoReserva)estado);
            }
            catch (Exception e)
            {
                return e.Message;
            }
            return "Estado modificado con exito";
        }

        [HttpGet]
        public JsonResult Estado(string codigo)
        {
            try
            {
                return Json(Sistema.GetInstancia().ConsultarReserva(codigo));
            }
            catch (Exception e)
            {
                return Json(e.Message);
            }
        }
    }
}
