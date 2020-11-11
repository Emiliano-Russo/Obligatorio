using BusinessLogic.Models.Entidades;
using ObligatorioDDA2.Models.Exceptions;
using ObligatorioDDA2.Models.Interfaces;
using ObligatorioDDA2.Models.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObligatorioDDA2.Models.Entidades.Repositorio
{
    public class RepositorioRAM : IRepositorio
    {
        private List<PuntoTuristico> listaPuntosTuristicos = new List<PuntoTuristico>();
        private List<Alojamiento> listAlojamientos = new List<Alojamiento>();
        private List<Admin> listaAdmins = new List<Admin>();
        private List<Reserva> listaReserva = new List<Reserva>();

        public bool Existe(PuntoTuristico punto) => listaPuntosTuristicos.Contains(punto);

        public bool Existe(Alojamiento hotel) => listAlojamientos.Contains(hotel);

        public bool Existe(Reserva reserva) => listaReserva.Contains(reserva);

        public bool Existe(Admin admin) => listaAdmins.Contains(admin);

        public bool Login(Admin admin) => listaAdmins.Find(x => x.email == admin.email && x.contrasenia == admin.contrasenia) != null;

        public void Incluir(PuntoTuristico punto) => listaPuntosTuristicos.Add(punto);

        public void Incluir(Alojamiento hotel) => listAlojamientos.Add(hotel);

        public Reserva Incluir(InfoReserva info)
        {
            Reserva reserva = new Reserva
            {
                InfoReserva = info,
                EstadoReserva = EstadoReserva.Creada,
                Codigo = CodigoRandom.GetCodigoRandomUnico(10)
            };
            listaReserva.Add(reserva);
            return reserva;
        }

        public void Incluir(Admin admin) => listaAdmins.Add(admin);

        public void Quitar(Alojamiento hotel) => listAlojamientos.Remove(hotel);

        public void Quitar(Admin admin) => listaAdmins.Remove(admin);

        public List<PuntoTuristico> GetPuntos(Region region) => listaPuntosTuristicos.FindAll(x => x.Region == region);

        public List<PuntoTuristico> GetPuntos(Region region, Categoria[] categorias)
        {
            List<PuntoTuristico> listaPuntos = GetPuntos(region);

            for (int i = listaPuntos.Count - 1; i >= 0; i--)
            {
                if (categorias.Except(listaPuntos[i].Categoria).Any())
                    listaPuntos.Remove(listaPuntos[i]);
            }

            return listaPuntos;
        }

        public List<Hospedaje> GetHospedajes(Estadia estadia, PuntoTuristico punto)
        {
            List<Hospedaje> listaRetorno = new List<Hospedaje>();
            Hospedaje hospedaje;

            foreach (var hotel in this.listAlojamientos)
            {
                if (hotel.PuntoTuristico.Equals(punto) && hotel.SinCapacidad == false)
                {
                    hospedaje = new Hospedaje(hotel, estadia);
                    listaRetorno.Add(hospedaje);
                }
            }
           
            return listaRetorno;
        }

        public ConsultaEstado ConsultarReserva(string codigo)
        {            
            Reserva r = listaReserva.Find(x => x.Codigo == codigo);
            ConsultaEstado ce = new ConsultaEstado
            {
                Nombre = r.InfoReserva.Nombre,
                Estado = r.EstadoReserva,
                Descripcion = "Codigo reservado por mail: " + r.InfoReserva.Email
            };
            return ce;
        }


        public void ModificarAlojamiento(string nombreAlojamiento, bool disponibilidad)
        {
            Alojamiento a = listAlojamientos.Find(x => x.Nombre == nombreAlojamiento);
            Quitar(a);
            a.SinCapacidad = disponibilidad;            
            Incluir(a);
        }


        public void ModificarEstadoReserva(string codigoReserva, EstadoReserva estadoReserva)
        {
            Reserva r = listaReserva.Find(x => x.Codigo == codigoReserva);
            listaReserva.Remove(new Reserva
            {
                Codigo = codigoReserva
            });
            r.EstadoReserva = estadoReserva;
            listaReserva.Add(r);
        }

        public List<Reserva> GetReservasValidas(InfoReporte info)
        {
            return this.listaReserva.FindAll(x => x.InfoReserva.Hotel.PuntoTuristico.Nombre == info.NombrePunto &&
            x.EstadoReserva != EstadoReserva.Rechazada
            && x.EstadoReserva != EstadoReserva.Expirada
            && x.InfoReserva.Estadia.Entrada < info.Final 
            && x.InfoReserva.Estadia.Salida > info.Inicio);
        }

        public List<Alojamiento> GetAlojamientos(PuntoTuristico punto)
        {
            return this.listAlojamientos.FindAll(x => x.PuntoTuristico.Nombre == punto.Nombre);
        }
    }
}
