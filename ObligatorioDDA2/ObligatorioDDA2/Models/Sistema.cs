using ObligatorioDDA2.Models.Exceptions;
using ObligatorioDDA2.Models.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObligatorioDDA2.Models
{
    public class Sistema
    {
        private readonly static Sistema _instancia = new Sistema();

        List<PuntoTuristico> listaPuntosTuristicos = new List<PuntoTuristico>();
        List<Alojamiento> listAlojamientos = new List<Alojamiento>();
        List<Admin> listaAdmins = new List<Admin>();
        List<Reserva> listaReserva = new List<Reserva>();

        public bool BaseDeDatos { get; set; }
        private Sistema()
        {

        }

        public static Sistema GetInstancia()
        {
            return _instancia;
        }

        public List<Region> GetRegiones()
        {
            return Enum.GetValues(typeof(Region)).Cast<Region>().ToList();
        }

        public List<PuntoTuristico> GetPuntosTuristicos(Region region)
        {
            return listaPuntosTuristicos.FindAll(x => x.Region == region);
        }

        public List<PuntoTuristico> GetPuntosTuristicos(Region region, Categoria[] categoria)
        {
            List<PuntoTuristico> listaPuntos = GetPuntosTuristicos(region);

            for (int i = listaPuntos.Count - 1; i >= 0; i--)
            {
                if (categoria.Except(listaPuntos[i].Categoria).Any())
                    listaPuntos.Remove(listaPuntos[i]);
            }

            return listaPuntos;
        }

        public List<Alojamiento> GetAlojamiento(Estadia estadia, PuntoTuristico puntoTuristico)
        {
            CheckEstadia(estadia);
            CheckPuntoTuristico(puntoTuristico);
            List<Alojamiento> listaRetorno = new List<Alojamiento>();

            foreach (var hotel in this.listAlojamientos)
            {
                if (hotel.PuntoTuristico.Equals(puntoTuristico) && hotel.SinCapacidad == false)
                    listaRetorno.Add(hotel);
            }

            return listaRetorno;
        }

        private void CheckEstadia(Estadia estadia)
        {

            bool estadiaCorrecta = estadia != null 
                && estadia.Entrada < estadia.Salida
                && estadia.Entrada >= DateTime.Now
                && estadia.RangoEdades.Length > 0;
            if (!estadiaCorrecta)
                throw new ExcepcionEstadiaInvalido("La estadia es incorrecta");
        }

        public Reserva CrearReserva(InfoReserva infoReserva)
        {           
            CheckInfoReserva(infoReserva);        
            Reserva r = new Reserva
            {
                InfoReserva = infoReserva,
                Codigo = "ALEATORIO",
                Descripcion = "Contactenos al 092777444",
                EstadoReserva = EstadoReserva.Creada
            };
            listaReserva.Add(r);
            return r;
        }

        private void CheckInfoReserva(InfoReserva info)
        {
            if (info == null)
                throw new ExcepcionInfoInvalida("informacion de reserva nula");
            CheckAlojamiento(info.Hotel);
            bool infoInvalida = String.IsNullOrEmpty(info.Nombre) ||
                String.IsNullOrEmpty(info.Apellido) ||
                String.IsNullOrEmpty(info.Email);
            if (infoInvalida)
                throw new ExcepcionInfoInvalida("info invalida");
            CheckEstadia(info.Estadia);
        }

        public EstadoReserva ConsultarReserva(string codigoReserva)
        {
            Reserva r = this.listaReserva.Find(x => x.Codigo == codigoReserva);
            if (r == null)
            throw new ExcepcionInfoInvalida("el codigo no existe");

            return r.EstadoReserva;
        }

        public bool ValidacionLogin(string email, string contrasenia)
        {
            Admin a = listaAdmins.Find(x => x.email == email);
            return a != null && a.contrasenia == contrasenia;
        }

        public void IncluirPuntoTuristico(PuntoTuristico puntoTuristico)
        {
            CheckPuntoTuristico(puntoTuristico);
            listaPuntosTuristicos.Add(puntoTuristico);
        }

        private void CheckPuntoTuristico(PuntoTuristico puntoTuristico)
        {
            bool esNulloVacio = puntoTuristico == null || (puntoTuristico.Categoria == null ||
                String.IsNullOrEmpty(puntoTuristico.Descripcion) ||
                String.IsNullOrEmpty(puntoTuristico.Nombre));
            if (esNulloVacio)
                throw new ExcepcionPuntoTuristicoInvalido("campos nulos");
            bool largoMenorQueCincoYMayorQueCero = puntoTuristico.Categoria.Length <= Enum.GetNames(typeof(Categoria)).Length && puntoTuristico.Categoria.Length >0;
            bool categoriasRepetidas = puntoTuristico.Categoria.GroupBy(x => x)
             .Where(g => g.Count() > 1)
             .Select(y => y.Key)
             .ToList().Count > 0;

            if (largoMenorQueCincoYMayorQueCero && !categoriasRepetidas)
                return;
            else
                throw new ExcepcionPuntoTuristicoInvalido("demasiadas/repetidas cateogorias");
        }

        public void IncluirAlojamiento(Alojamiento alojamiento)
        {
            CheckAlojamiento(alojamiento);
            CheckPuntoTuristico(alojamiento.PuntoTuristico);
            ExisteAlojamiento(alojamiento);
            
            this.listAlojamientos.Add(alojamiento);
        }

        private void CheckAlojamiento(Alojamiento alojamiento)
        {
            bool alojamientoInvalido = String.IsNullOrEmpty(alojamiento.Nombre) ||
               String.IsNullOrEmpty(alojamiento.InfoDeContacto) ||
               String.IsNullOrEmpty(alojamiento.NroTelefono) ||
               alojamiento.PrecioNoche <= 0 ||
                String.IsNullOrEmpty(alojamiento.Descripcion) ||
                 String.IsNullOrEmpty(alojamiento.Direccion) ||
                 alojamiento.Estrellas <= 0 ||
                 alojamiento.Estrellas >= 6;
                
            if (alojamientoInvalido)
                throw new ExcepcionAlojamientoInvalido("Objeto Invalido");
        }

        private void ExisteAlojamiento(Alojamiento alojamiento)
        {
            bool yaExiste = this.listAlojamientos.Contains(alojamiento);
            if (yaExiste)
                throw new ExcepcionAlojamientoInvalido("Alojamiento ya registrado");
        }

        public void ModificarAlojamiento(string nombreAlojamiento, bool disponibilidad)
        {
            if (String.IsNullOrEmpty(nombreAlojamiento))
            throw new ExcepcionAlojamientoInvalido("Nombre null");
            bool Existe= this.listAlojamientos.Contains(new Alojamiento { Nombre = nombreAlojamiento });
            if (!Existe)
                throw new ExcepcionAlojamientoInvalido("Ya existe el alojamiento");
            Alojamiento a = listAlojamientos.Find(x => x.Nombre == nombreAlojamiento);
            a.SinCapacidad = disponibilidad;
            BorrarAlojamiento(nombreAlojamiento);
            IncluirAlojamiento(a);
        }

        public void BorrarAlojamiento(string nombre)
        {
            if (String.IsNullOrEmpty(nombre))
                throw new ExcepcionAlojamientoInvalido("nombre invalido");

            Alojamiento a = new Alojamiento
            {
                Nombre = nombre
            };
            if (!this.listAlojamientos.Contains(a))
                throw new ExcepcionAlojamientoInvalido("No existe el alojamiento");
            this.listAlojamientos.Remove(a);
        }

        public void CambiarEstadoReserva(string codigoReserva, EstadoReserva estadoReserva)
        {
            if (!listaReserva.Contains(new Reserva
            {
                Codigo = codigoReserva
            }))
                throw new ExcepcionInfoInvalida("La reserva no existe");

            Reserva r = listaReserva.Find(x => x.Codigo == codigoReserva);
            listaReserva.Remove(new Reserva
            {
                Codigo = codigoReserva
            });
            r.EstadoReserva = estadoReserva;
            listaReserva.Add(r);
        }

        public void AgregarAdmin(string email, string contrasenia)
        {
            if (ExisteAdmin(email))
                throw new ExcepcionLogin("Admin ya existente");
            else if (String.IsNullOrEmpty(email) || String.IsNullOrEmpty(contrasenia))
                throw new ExcepcionLogin("Campos de login vacios o nulos");

            listaAdmins.Add(new Admin
            {
                email = email,
                contrasenia = contrasenia
            });
        }

        public bool ExisteAdmin(string email)
        {
            return listaAdmins.Contains(new Admin
            {
                email = email
            });
        }

        public void BorrarAdmin(string email)
        {
            listaAdmins.Remove(new Admin
            {
                email = email
            });
        }
        //metodos utiles para unittest
        public void BorrarPuntosTuristicos()
        {
            listaPuntosTuristicos = new List<PuntoTuristico>();
        }

        public void BorrarAlojamientos()
        {
            this.listAlojamientos = new List<Alojamiento>();
        }

        public void BorrarReservas()
        {
            this.listaReserva = new List<Reserva>();
        }
    }
}
