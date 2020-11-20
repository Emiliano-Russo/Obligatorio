using BusinessLogic.Models.Entidades;
using BusinessLogic.Models.Entidades.Repositorio;
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

        bool Existe(Puntuacion_Recibir p);

        bool Login(Admin admin);

        void Incluir(PuntoTuristico punto);

        void Incluir(Alojamiento hotel);

        Reserva Incluir(InfoReserva infoReserva);

        void Incluir(Admin admin);

        void Quitar(Alojamiento hotel);

        void Quitar(Admin admin);

        List<PuntoTuristico> GetPuntos(Region region);

        List<PuntoTuristico> GetPuntos(Region region, Categoria[] categorias);

        List<Hospedaje> GetHospedajes(Estadia estadia, PuntoTuristico punto);

        ConsultaEstado ConsultarReserva(string codigo);

        void ModificarAlojamiento(string codigo, bool disponible);

        void ModificarEstadoReserva(string codigo, EstadoReserva estado);

        List<Reserva> GetReservasValidas(Unidad_ReporteA info);

        List<Alojamiento> GetAlojamientos(PuntoTuristico punto);

        Reserva GetReserva(string codigo);
        void EnviarPuntuacion(Puntuacion p);
        List<Puntuacion_Recibir> GetPuntuaciones(string nombre_alojamiento);
    }
}
