using BusinessLogic.Models.Entidades;
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
                throw new ObligatorioDDA2.Models.Exceptions.ExcepcionInfoInvalida("No existe la reserva");
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

        public Reserva Incluir(InfoReserva inforeserva)
        {

            Reserva reserva = new Reserva
            {
                InfoReserva = inforeserva,
                Codigo = CodigoRandom.GetCodigoRandomUnico(10),
                EstadoReserva = EstadoReserva.Creada
            };
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

        List<Reserva> IRepositorio.GetReservasValidas(InfoReporte info)
        {
            List<Reserva> lista_reservas = new List<Reserva>();
            using (var context = new EntidadesContext())
            {
                lista_reservas = context.Reservas.Where(x =>
                x.InfoReserva.Hotel.PuntoTuristico.Nombre == info.NombrePunto
                && x.EstadoReserva != EstadoReserva.Rechazada
            && x.EstadoReserva != EstadoReserva.Expirada
            && x.InfoReserva.Estadia.Entrada < info.Final
            && x.InfoReserva.Estadia.Salida > info.Inicio).ToList();
            }
            return lista_reservas;
        }
    }
}
