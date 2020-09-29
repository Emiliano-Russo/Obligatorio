using ObligatorioDDA2.Models.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObligatorioDDA2.Models.Interfaces
{
    public interface IRepositorio
    {
        bool Existe(PuntoTuristico punto);

        bool Existe(Alojamiento hotel);

        bool Existe(Reserva reserva);

        bool Existe(Admin admin);

        bool Login(Admin admin);

        void Incluir(PuntoTuristico punto);

        void Incluir(Alojamiento hotel);

        Reserva Incluir(InfoReserva reserva);

        void Incluir(Admin reserva);

        void Quitar(PuntoTuristico reserva);

        void Quitar(Alojamiento reserva);

        void Quitar(Reserva reserva);

        void Quitar(Admin reserva);

        List<PuntoTuristico> GetPuntos(Region region);

        List<PuntoTuristico> GetPuntos(Region region, Categoria[] categorias);

        List<Hospedaje> GetHospedajes(Estadia estadia, PuntoTuristico punto);

        bool ExisteReserva(string codigo);
        ConsultaEstado ConsultarReserva(string codigo);

        void ModificarAlojamiento(string codigo, bool disponible);

        Reserva GetReserva(string codigo);

        void ModificarEstadoReserva(string codigo, EstadoReserva estado);
    }
}
