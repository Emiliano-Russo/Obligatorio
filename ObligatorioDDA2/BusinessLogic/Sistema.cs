using BusinessLogic.Models.Entidades;
using BusinessLogic.Models.Entidades.Logica_ReporteA;
using ObligatorioDDA2.Models.Entidades.Repositorio;
using ObligatorioDDA2.Models.Exceptions;
using ObligatorioDDA2.Models.Interfaces;
using ObligatorioDDA2.Models.Logic;
using ObligatorioDDA2.Models.Validadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ObligatorioDDA2.Models
{
    public class Sistema
    {
        private readonly static Sistema _instancia = new Sistema();
        internal Validacion<Admin> validacionAdmin { get; }
        internal Validacion<PuntoTuristico> validacionPuntoTursitico { get; }
        internal Validacion<Estadia> validacionEstadia { get; }
        internal Validacion<Alojamiento> validacionAlojamiento { get; }
        internal Validacion<InfoReserva> validacionInfoReserva { get; }

        internal IRepositorio repo;

        private bool conBDD;
        public bool BaseDeDatos
        {
            get
            {
                return conBDD;
            }
            set
            {
                if (value == conBDD)
                    return;
                conBDD = value;

                if (value == false)
                    repo = new RepositorioRAM();
                else
                    repo = new RepositorioBDD();
            }
        }

        private Sistema()
        {
            repo = new RepositorioBDD();
            validacionAdmin = new ValidacionAdmin();
            validacionEstadia = new ValidacionEstadia();
            validacionInfoReserva = new ValidacionInfoReserva();
            validacionPuntoTursitico = new ValidacionPuntoTuristico();
            validacionAlojamiento = new ValidacionAlojamiento();
        }

        public static Sistema GetInstancia() => _instancia;

        public List<Region> GetRegiones() => Enum.GetValues(typeof(Region)).Cast<Region>().ToList();

        public List<PuntoTuristico> GetPuntosTuristicos(Region region) => repo.GetPuntos(region);

        public List<PuntoTuristico> GetPuntosTuristicos(Region region, Categoria[] categorias) => repo.GetPuntos(region, categorias);

        public List<Hospedaje> GetHospedajes(Estadia estadia, PuntoTuristico puntoTuristico)
        {
            validacionEstadia.ValidarSintaxis(estadia);
            validacionPuntoTursitico.ValidarSintaxisExitencia(puntoTuristico);
            return repo.GetHospedajes(estadia, puntoTuristico);
        }

        public Reserva CrearReserva(InfoReserva infoReserva)
        {
            validacionInfoReserva.ValidarRegistro(infoReserva);
            return repo.Incluir(infoReserva);
        }

        public ConsultaEstado ConsultarReserva(string codigoReserva)
        {
            validacionInfoReserva.ValidarExistencia(codigoReserva);
            return repo.ConsultarReserva(codigoReserva);
        }

        public bool ValidacionLogin(Admin admin) => repo.Login(admin);

        public void IncluirPuntoTuristico(PuntoTuristico puntoTuristico)
        {
            validacionPuntoTursitico.ValidarRegistro(puntoTuristico);
            repo.Incluir(puntoTuristico);
        }


        public void IncluirAlojamiento(Alojamiento alojamiento)
        {
            validacionAlojamiento.ValidarRegistro(alojamiento);
            repo.Incluir(alojamiento);
        }


        public void ModificarAlojamiento(string nombreAlojamiento, bool disponibilidad)
        {
            validacionAlojamiento.ValidarExistencia(nombreAlojamiento);
            repo.ModificarAlojamiento(nombreAlojamiento, disponibilidad);
        }

        public void BorrarAlojamiento(string nombre)
        {
            validacionAlojamiento.ValidarString(nombre, new ExcepcionAlojamientoInvalido("No existe " + nombre));
            validacionAlojamiento.ValidarExistencia(nombre);
            Alojamiento hotel = new Alojamiento { Nombre = nombre };
            repo.Quitar(hotel);
        }

        public void CambiarEstadoReserva(string codigoReserva, EstadoReserva estadoReserva)
        {
            validacionInfoReserva.ValidarString(codigoReserva, new ExcepcionInfoInvalida("El codigo es nulo o vacio"));
            validacionInfoReserva.ValidarExistencia(codigoReserva);
            repo.ModificarEstadoReserva(codigoReserva, estadoReserva);
        }

        public void AgregarAdmin(Admin admin)
        {
            validacionAdmin.ValidarRegistro(admin);
            repo.Incluir(admin);
        }

        public bool ExisteAdmin(Admin admin)
        {
            try
            {
                validacionAdmin.ValidarSintaxisExitencia(admin);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public void BorrarAdmin(Admin admin)
        {
            validacionAdmin.ValidarExistencia(admin.email);
            repo.Quitar(admin);
        }

        public List<Hotel_CantReservas> ReporteA(InfoReporte info)
        {
            Logica_ReporteA logica = new Logica_ReporteA();
            return logica.GetReporteA(info);           
        }



        //metodos utiles para unittest
        public void BorrarPuntosTuristicos() => ResetearRepositorioRam();
        public void BorrarAlojamientos() => ResetearRepositorioRam();
        public void BorrarReservas() => ResetearRepositorioRam();
        private void ResetearRepositorioRam() => repo = new RepositorioRAM();
    }
}
