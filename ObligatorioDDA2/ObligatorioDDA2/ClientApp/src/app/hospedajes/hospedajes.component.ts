import { Component, OnInit, Inject } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { DatosReserva } from '../datos-reserva/datos-reserva.injectable';


@Component({
  selector: 'hospedajes',
  templateUrl: './hospedajes.component.html',
  styleUrls: ['./hospedajes.component.css'],
})
export class HospedajesComponent implements OnInit {

  nombrePunto: string;
  personas: number[] = [0, 0, 0, 0];
  hoteles: string;
  url_base: string;

  constructor(@Inject('BASE_URL') baseUrl: string, private router: ActivatedRoute, private http: HttpClient, private clase_datos: DatosReserva, private ruta: Router) {
    this.url_base = baseUrl;
  }

  ngOnInit() {
    this.router.paramMap.
      subscribe(params => {
        this.nombrePunto = params.get("nombre");
      });
    this.alojamiento.Punto.Nombre = this.nombrePunto;

  }

  sumarPersona(i: number) {
    this.personas[i]++;
  }
  quitarPersona(i: number) {
    if (this.personas[i] > 0) {
      this.personas[i]--;
    }
  }

  alojamiento = {
    "Punto": {
      "Nombre": "",
      "Descripcion": "asd",
      "Region": 0,
      "Categoria": [0],
      "ImgName": ["zero"]
    },
    "Estadia": {
      "Entrada": "",
      "Salida": "",
      "RangoEdades": [0]
    }
  }

  estadia_hotel =
    {
      "Estadia": {
        "Entrada": "",
        "Salida": "",
        "RangoEdades": []
      },
      "Hotel": {
        "Nombre": "",
        "Estrellas": 4,
        "PuntoTuristico": {
          "Nombre": "",
          "Descripcion": "",
          "Region": 0,
          "Categoria": [0],
          "ImgName": [""]
        },
        "Direccion": "",
        "PrecioNoche": 1,
        "Descripcion": "",
        "SinCapacidad": false,
        "NroTelefono": "",
        "InfoDeContacto": ""
      }
    }


  buscarHospedajes() {
    this.alojamiento.Estadia.Entrada = (<HTMLInputElement>document.getElementById("entrada")).value;
    this.alojamiento.Estadia.Salida = (<HTMLInputElement>document.getElementById("salida")).value;
    this.alojamiento.Estadia.RangoEdades = this.personas;

    this.http.post<string>(this.url_base + 'Hospedajes/Busqueda', this.alojamiento).toPromise().then(
      res => {
        this.hoteles = res;
      }).then(
        res => {
          this.incluir_puntajes(this.hoteles);
        });

  }
 

  incluir_puntajes(alojamientos: any) {
    
    for (var i = 0; i < alojamientos.length; i++) {
      this.colocar_puntaje(alojamientos[i]);
    }
  }

  colocar_puntaje(hotel: object) {
    this.http.get<string>(this.url_base + 'Hospedajes/PuntuacionFinal' + "?alojamiento=" + hotel.alojamiento.nombre).subscribe(result => {
      hotel.puntaje = result;
    });
  }

  reservar(hotel: any) {
    this.estadia_hotel.Estadia = this.alojamiento.Estadia;
    this.estadia_hotel.Hotel = hotel;
    this.clase_datos.datos = this.estadia_hotel;
    this.ruta.navigate(['/reserva']);
  }


}
