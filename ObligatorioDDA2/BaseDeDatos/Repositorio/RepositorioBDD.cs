using BusinessLogic.Models.Entidades;
using BusinessLogic.Models.Entidades.Repositorio;
using Microsoft.EntityFrameworkCore;
using ObligatorioDDA2.Data;
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

        public RepositorioBDD()
        {
            //EntidadesContext contexto = new EntidadesContext();
        }

        public ConsultaEstado ConsultarReserva(string codigo)
        {
            ConsultaEstado consultaEstado = new ConsultaEstado();
            Reserva reserva = new Reserva();
            using (var context = new EntidadesContext())
            {
                reserva = context.Reservas.Find(codigo);
                context.Entry(reserva).Reference(x => x.InfoReserva).Load();
            }
            if (reserva == null)
                throw new Exception("No existe la reserva");
            consultaEstado.Nombre = reserva.InfoReserva.Nombre;
            consultaEstado.Descripcion = "Estado cambiado por el administrador";
            consultaEstado.Estado = reserva.EstadoReserva;

            return consultaEstado;
        }

     
        public bool Existe(PuntoTuristico punto)
        {
            PuntoTuristico puntoBuscar = new PuntoTuristico();
            using (var context = new EntidadesContext())
            {
                puntoBuscar = context.PuntosTuristicos.Find(punto.Nombre);
            }
            return puntoBuscar != null;
        }

        public bool Existe(Alojamiento hotel)
        {
            Alojamiento alojamiento = new Alojamiento();
            using (var context = new EntidadesContext())
            {
                alojamiento = context.Alojamientos.Find(hotel.Nombre);
            }
            return alojamiento != null;
        }

        public bool Existe(Reserva reserva)
        {
            Reserva reservaBusqueda = new Reserva();
            using (var context = new EntidadesContext())
            {
                reservaBusqueda = context.Reservas.Find(reserva.Codigo);
            }
            return reservaBusqueda != null;
        }



        public bool Existe(Admin admin)
        {
            Admin a = null;
            using (var context = new EntidadesContext())
            {
                a = context.Admins.Find(admin.email);
            }
            return a != null;
        }

        public List<Hospedaje> GetHospedajes(Estadia estadia, PuntoTuristico punto)
        {
            List<Hospedaje> hospedajes = new List<Hospedaje>();
            List<Alojamiento> alojamientos;
            using (var context = new EntidadesContext())
            {
                alojamientos = context.Alojamientos.Where(a => a.PuntoTuristico == punto).ToList();
                foreach (var alojamiento in alojamientos)
                {
                    context.Entry(alojamiento).Reference(x => x.PuntoTuristico).Load();
                }

            }
            if (alojamientos == null)
                return null;
            for (int i = 0; i < alojamientos.Count; i++)
            {
                hospedajes.Add(new Hospedaje(alojamientos[i], estadia));
            }

            return hospedajes;
        }

        public List<Hospedaje> GetHospedajes(PuntoTuristico punto)
        {
            throw new NotImplementedException();
        }

        public List<PuntoTuristico> GetPuntos(Region region)
        {
            List<PuntoTuristico> puntosTuristicos;
            using (var context = new EntidadesContext())
            {
                puntosTuristicos = context.PuntosTuristicos.Where(p => p.Region == region).ToList();
            }
            return puntosTuristicos;
        }

        public List<PuntoTuristico> GetPuntos(Region region, Categoria[] categorias)
        {
            List<PuntoTuristico> listaPuntos = this.GetPuntos(region);
            for (int i = listaPuntos.Count - 1; i >= 0; i--)
            {
                if (categorias.Except(listaPuntos[i].Categoria).Any())
                    listaPuntos.Remove(listaPuntos[i]);
            }

            return listaPuntos;
        }

        public Reserva Incluir(InfoReserva inforeserva)
        {

            Reserva reserva = this.CrearReservaUnica(inforeserva);
            
            using (var context = new EntidadesContext())
            {
                context.PuntosTuristicos.Attach(inforeserva.Hotel.PuntoTuristico);
                context.Alojamientos.Attach(inforeserva.Hotel);
                context.InfoReservas.Add(inforeserva);
                context.Reservas.Add(reserva);
                context.SaveChanges();
            }
            return reserva;
        }

        private Reserva CrearReservaUnica(InfoReserva infoReserva)
        {
            Reserva reserva = new Reserva
            {
                InfoReserva = infoReserva,
                Codigo = CodigoRandom.GetCodigoRandomUnico(10),
                EstadoReserva = EstadoReserva.Creada
            };
            if (this.Existe(reserva))
                return CrearReservaUnica(infoReserva);
            else
                return reserva;
        }

        //Puntuacion

        public bool Existe(Puntuacion_Recibir p)
        {
            bool existe = false;
            using (var context = new EntidadesContext())
            {
                List<Puntuacion> lista =context.Puntuacion.Where(x => x.Reserva.Codigo == p.Codigo).ToList();
                if (lista != null && lista.Count > 0)
                    existe = true;
            }
            return existe;
        }

        public void EnviarPuntuacion(Puntuacion p)
        {
            using (var context = new EntidadesContext())
            {
                context.PuntosTuristicos.Attach(p.Reserva.InfoReserva.Hotel.PuntoTuristico);
                context.Alojamientos.Attach(p.Reserva.InfoReserva.Hotel);
                context.InfoReservas.Attach(p.Reserva.InfoReserva);
                context.Reservas.Attach(p.Reserva);
                context.Puntuacion.Add(p);
                context.SaveChanges();
            }
        }

        public List<Puntuacion_Recibir> GetPuntuaciones(string nombre_alojamiento)
        {
            List<Puntuacion_Recibir> lista_retorno = new List<Puntuacion_Recibir>();
            List<Puntuacion> lista_puntuaciones = null;
            using (var context = new EntidadesContext())
            {
                lista_puntuaciones = context.Puntuacion.
                    Include(x=>x.Reserva).
                    Include(x =>x.Reserva.InfoReserva).
                    Where(x => x.Reserva.InfoReserva.Hotel.Nombre == nombre_alojamiento).ToList();
            }
            return ArmarLista(lista_puntuaciones);
        }
        private List<Puntuacion_Recibir> ArmarLista(List<Puntuacion> lista_puntuaciones)
        {
            if (lista_puntuaciones == null || lista_puntuaciones.Count == 0)
                throw new Exception("Aun no puntuado");

            List<Puntuacion_Recibir> lista_retorno = new List<Puntuacion_Recibir>();
            foreach (var p in lista_puntuaciones)
            {
                Puntuacion_Recibir pun = new Puntuacion_Recibir
                {
                    Codigo = p.Reserva.Codigo,
                    Comentario = p.Comentario,
                    Puntos = p.Puntos,
                    Nombre = p.Reserva.InfoReserva.Nombre,
                    Apellido = p.Reserva.InfoReserva.Apellido
                };
                lista_retorno.Add(pun);
            }

            return lista_retorno;
        }
                

        public Reserva GetReserva(string codigo)
        {
            Reserva reserva = null;
            using (var context = new EntidadesContext())
            {
                List<Reserva> lista = context.Reservas.
                    Include(a=>a.InfoReserva).
                    Include(a=> a.InfoReserva.Estadia).
                    Include(a=> a.InfoReserva.Hotel).
                    Include(a=> a.InfoReserva.Hotel.PuntoTuristico).
                    Where(x => x.Codigo == codigo).ToList();
                reserva = lista[0];                
            }
            return reserva;
        }

        

        public Reserva GetReservas(Hospedaje h)
        {
            throw new NotImplementedException();
        }

        public void Incluir(PuntoTuristico punto)
        {
            using (var context = new EntidadesContext())
            {
                context.PuntosTuristicos.Add(punto);
                context.SaveChanges();
            }
        }

        public void Incluir(Alojamiento hotel)
        {
            using (var context = new EntidadesContext())
            {
                context.PuntosTuristicos.Attach(hotel.PuntoTuristico);
                context.Alojamientos.Add(hotel);
                context.SaveChanges();
            }
        }

        

        public void Incluir(Admin admin)
        {
            using (var context = new EntidadesContext())
            {
                context.Admins.Add(admin);
                context.SaveChanges();
            }
        }

        public bool Login(Admin admin)
        {
            return this.Existe(admin);
        }

        public void ModificarAlojamiento(string nombre, bool disponible)
        {
            Alojamiento alojamiento;
            using (var context = new EntidadesContext())
            {
                alojamiento = context.Alojamientos.Find(nombre);
                alojamiento.SinCapacidad = !disponible;
                context.Alojamientos.Update(alojamiento);
                context.SaveChanges();
            }
        }

        public void ModificarEstadoReserva(string codigo, EstadoReserva estado)
        {
            Reserva reserva;
            using (var context = new EntidadesContext())
            {
                reserva = context.Reservas.Find(codigo);
                reserva.EstadoReserva = estado;
                context.Reservas.Update(reserva);
                context.SaveChanges();
            }
        }

        public void Quitar(Alojamiento hotel)
        {
            using (var context = new EntidadesContext())
            {
                context.Alojamientos.Remove(hotel);
                context.SaveChanges();
            }
        }

        public void Quitar(Admin admin)
        {
            using (var context = new EntidadesContext())
            {
                context.Admins.Remove(admin);
                context.SaveChanges();
            }
        }

        List<Alojamiento> IRepositorio.GetAlojamientos(PuntoTuristico punto)
        {
            List<Alojamiento> lista_alojamiento = new List<Alojamiento>();
            using (var context = new EntidadesContext())
            {
                lista_alojamiento = context.Alojamientos.Where(a => a.PuntoTuristico == punto).ToList();
            }
            return lista_alojamiento;
        }

        List<Reserva> IRepositorio.GetReservasValidas(Unidad_ReporteA info)
        {
            List<Reserva> lista_reservas = new List<Reserva>();
            using (var context = new EntidadesContext())
            {
                lista_reservas = context.Reservas.Where(x =>
                x.InfoReserva.Hotel.Nombre == info.Alojamiento.Nombre
                && x.EstadoReserva != EstadoReserva.Rechazada
            && x.EstadoReserva != EstadoReserva.Expirada
            && x.InfoReserva.Estadia.Entrada < info.Salida
            && x.InfoReserva.Estadia.Salida > info.Ingreso).ToList();
            }
            return lista_reservas;
        }

        
    }
}
