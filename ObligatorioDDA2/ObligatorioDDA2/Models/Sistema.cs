using ObligatorioDDA2.Models.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObligatorioDDA2.Models
{
    public class Sistema
    {
        private static Sistema _instancia;
        private Sistema()
        {
            _instancia = new Sistema();
        }

        public static Sistema GetInstancia()
        {
            return _instancia;
        }

        public List<Region> GetRegiones()
        {
            throw new NotImplementedException();
        }

        public List<PuntoTuristico> GetPuntosTuristicos(Region region)
        {
            throw new NotImplementedException();
        }

        public List<PuntoTuristico> GetPuntosTuristicos(Region region, Categoria categoria)
        {
            throw new NotImplementedException();
        }

        public List<Alojamiento> GetAlojamiento(Estadia estadia, PuntoTuristico puntoTuristico)
        {
            throw new NotImplementedException();
        }

        public Reserva CrearReserva(InfoReserva infoReserva)
        {
            throw new NotImplementedException();
        }

        public EstadoReserva ConsultarReserva (string codigoReserva)
        {
            throw new NotImplementedException();
        }

        public bool ValidacionLogin(string email,string contrasenia)
        {
            throw new NotImplementedException();
        }

        public void IncluirPuntoTuristico(PuntoTuristico puntoTuristico)
        {
            throw new NotImplementedException();
        }

        public void IncluirAlojamiento(Alojamiento alojamiento)
        {
            throw new NotImplementedException();
        }

        public void ModificarAlojamiento(string nombreAlojamiento,Alojamiento alojamiento)
        {
            throw new NotImplementedException();
        }

        public void BorrarAlojamiento(string nombre)
        {
            throw new NotImplementedException();
        }

        public void CambiarEstadoReserva(string codigoReserva,EstadoReserva estadoReserva)
        {
            throw new NotImplementedException();
        }

        public void AgregarAdmin(string email,string contrasenia)
        {
            throw new NotImplementedException();
        }

        public void BorrarAdmin(string email)
        {
            throw new NotImplementedException();
        }
    }
}
