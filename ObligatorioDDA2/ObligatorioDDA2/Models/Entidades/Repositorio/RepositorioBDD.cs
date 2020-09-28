using ObligatorioDDA2.Models.Interfaces;
using ObligatorioDDA2.Models.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObligatorioDDA2.Models.Entidades.Repositorio
{
    public class RepositorioBDD : IRepositorio
    {
        public ConsultaEstado ConsultarReserva(string codigo)
        {
            throw new NotImplementedException();
        }

        public bool Existe(PuntoTuristico punto)
        {
            throw new NotImplementedException();
        }

        public bool Existe(Alojamiento hotel)
        {
            throw new NotImplementedException();
        }

        public bool Existe(Reserva reserva)
        {
            throw new NotImplementedException();
        }

        public bool Existe(Admin admin)
        {
            throw new NotImplementedException();
        }

        public bool ExisteReserva(string codigo)
        {
            throw new NotImplementedException();
        }

        public List<Hospedaje> GetHospedajes(Estadia estadia, PuntoTuristico punto)
        {
            throw new NotImplementedException();
        }

        public List<PuntoTuristico> GetPuntos(Region region)
        {
            throw new NotImplementedException();
        }

        public List<PuntoTuristico> GetPuntos(Region region, Categoria[] categorias)
        {
            throw new NotImplementedException();
        }

        public Reserva GetReserva(string codigo)
        {
            throw new NotImplementedException();
        }

        public void Incluir(PuntoTuristico punto)
        {
            throw new NotImplementedException();
        }

        public void Incluir(Alojamiento hotel)
        {
            throw new NotImplementedException();
        }

        public Reserva Incluir(InfoReserva reserva)
        {
            throw new NotImplementedException();
        }

        public void Incluir(Admin reserva)
        {
            throw new NotImplementedException();
        }

        public bool Login(Admin admin)
        {
            throw new NotImplementedException();
        }

        public void ModificarAlojamiento(string codigo, bool disponible)
        {
            throw new NotImplementedException();
        }

        public void ModificarEstadoReserva(string codigo, EstadoReserva estado)
        {
            throw new NotImplementedException();
        }

        public void Quitar(PuntoTuristico reserva)
        {
            throw new NotImplementedException();
        }

        public void Quitar(Alojamiento reserva)
        {
            throw new NotImplementedException();
        }

        public void Quitar(Reserva reserva)
        {
            throw new NotImplementedException();
        }

        public void Quitar(Admin reserva)
        {
            throw new NotImplementedException();
        }
    }
}
