import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'alta-hotel',
  templateUrl: './alta-hotel.component.html',
  styleUrls: ['./alta-hotel.component.css']
})
export class AltaHotelComponent implements OnInit {

  url_base: string;
  SinCapacidad = false;
  puntos_t = [];
  mensaje_srv: string;

  Alojamiento = {
    Nombre: "",
    Estrellas: 0,
    PuntoTuristico: {
      Nombre: "",
      Descripcion: "",
      Region: 0,
      Categoria: [0],
      ImgName:["imagen"],
    },
    Direccion: "",
    PrecioNoche: 1,
    Descripcion: "",
    SinCapacidad: false,
    NroTelefono: "",
    InfoDeContacto:""
  }


  constructor(@Inject('BASE_URL') baseUrl: string, private http: HttpClient) {
    this.url_base = baseUrl;
  }
    ngOnInit(): void {
      this.traer_puntos_turisticos();
    }

  CambiarCapacidad() {
    this.SinCapacidad = !this.SinCapacidad;
    if (this.SinCapacidad) {
      (<HTMLInputElement>document.getElementById("disponible")).style.backgroundColor = "red";
      (<HTMLInputElement>document.getElementById("disponible")).innerHTML = "No disponible";
    } else {
      (<HTMLInputElement>document.getElementById("disponible")).style.backgroundColor = "LawnGreen";
      (<HTMLInputElement>document.getElementById("disponible")).innerHTML = "Disponible";
    }
  }

  registrar_hotel() {
    let nombre = (<HTMLInputElement>document.getElementById("nombre")).value;
    let estrellas = Number((<HTMLInputElement>document.getElementById("estrellas")).value);
    let punto = this.get_punto_turistico((<HTMLInputElement>document.getElementById("punto")).value);
    let direccion = (<HTMLInputElement>document.getElementById("dir")).value;
    let precio_noche = Number((<HTMLInputElement>document.getElementById("precio")).value);
    let descripcion = (<HTMLInputElement>document.getElementById("desc")).value;
    let telefono = (<HTMLInputElement>document.getElementById("tel")).value;
    let info_contacto = (<HTMLInputElement>document.getElementById("contacto")).value;
    

    this.Alojamiento.Nombre = nombre;
    this.Alojamiento.Estrellas = estrellas;
    this.Alojamiento.PuntoTuristico = punto;
    this.Alojamiento.Direccion = direccion;
    this.Alojamiento.PrecioNoche = precio_noche;
    this.Alojamiento.Descripcion = descripcion;
    this.Alojamiento.NroTelefono = telefono;
    this.Alojamiento.InfoDeContacto = info_contacto;

    console.log("Alojamiento a enviar: ");
    console.log(this.Alojamiento);
    
    this.http.post<string>(this.url_base + 'Hospedajes/Alta', this.Alojamiento).subscribe(result => {
      this.mensaje_srv = result;
    });
    
  }


  get_punto_turistico(nombre: string) {
    let retorno = null;
    for (var i = 0; i < this.puntos_t.length; i++) {
      if (this.puntos_t[i] != undefined) {
        if (this.puntos_t[i].nombre == nombre) {
          retorno = this.puntos_t[i];
          break;
        }
      }
    }
    return retorno;
  }
  

  traer_puntos_turisticos() {  
    for (var i = 0; i <= 4; i++) {
      this.http.get<string>(this.url_base + 'PuntosTuristicos/Busqueda?region=' + i).subscribe(result => {
        for (var i = 0; i < result.length; i++) {
          this.puntos_t.push(result[i]);
        }      
      });
    }  
  }



}
