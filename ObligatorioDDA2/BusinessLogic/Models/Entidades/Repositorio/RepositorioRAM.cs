using BusinessLogic.Models.Entidades;
using BusinessLogic.Models.Entidades.Repositorio;
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
        private List<Puntuacion> listaPuntuaciones = new List<Puntuacion>();

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

        public List<Reserva> GetReservasValidas(Unidad_ReporteA info)
        {
            return this.listaReserva.FindAll(x =>
                x.InfoReserva.Hotel.Nombre == info.Alojamiento.Nombre
                && x.EstadoReserva != EstadoReserva.Rechazada
            && x.EstadoReserva != EstadoReserva.Expirada
            && x.InfoReserva.Estadia.Entrada < info.Salida
            && x.InfoReserva.Estadia.Salida > info.Ingreso);
        }

        public List<Alojamiento> GetAlojamientos(PuntoTuristico punto)
        {
            return this.listAlojamientos.FindAll(x => x.PuntoTuristico.Nombre == punto.Nombre);
        }

        public Reserva GetReserva(string codigo)
        {
            return this.listaReserva.Find(r => r.Codigo == codigo);
        }

        public void EnviarPuntuacion(Puntuacion p)
        {
            this.listaPuntuaciones.Add(p);
        }

        public List<Puntuacion_Recibir> GetPuntuaciones(string nombre_alojamiento)
        {
            List<Puntuacion> lista_puntuaciones  = this.listaPuntuaciones.FindAll(x => x.Reserva.InfoReserva.Hotel.Nombre == nombre_alojamiento);
            ListaVaciaONull_Excepcion(lista_puntuaciones);
            return Parse_Puntuacion(lista_puntuaciones);
        }

        private void ListaVaciaONull_Excepcion(List<Puntuacion> lista)
        {
            if (lista == null || lista.Count == 0)
                throw new Exception("No existen punutaciones para este hotel");
        }

        private List<Puntuacion_Recibir> Parse_Puntuacion(List<Puntuacion> lista_puntuaciones)
        {
            List<Puntuacion_Recibir> lista_retorno = new List<Puntuacion_Recibir>();
            foreach (var p in lista_puntuaciones)
            {
                Puntuacion_Recibir pun = new Puntuacion_Recibir
                {
                    Codigo = p.Reserva.Codigo,
                    Comentario = p.Comentario,
                    Puntos = p.Puntos
                };
                lista_retorno.Add(pun);
            }
            return lista_retorno;
        }
    }
}
