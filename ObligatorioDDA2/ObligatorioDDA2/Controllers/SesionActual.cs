using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObligatorioDDA2.Controllers
{
    public static class SesionActual
    {
        public static ISession Sesion { get; set; }

        public static void ExisteLogin_Ex()
        {
            if (Sesion != null && Sesion.GetString("usuario") != null)
                throw new Exception("Ya existe una sesion");
        }

        public static void NoExsiteLogin_Ex()
        {
            if (Sesion == null || Sesion.GetString("usuario") == null)
                throw new Exception("Acceso Restringido");
        }

    }
}
