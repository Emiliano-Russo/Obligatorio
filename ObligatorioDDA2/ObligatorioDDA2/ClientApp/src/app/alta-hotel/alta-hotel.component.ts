import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'alta-hotel',
  templateUrl: './alta-hotel.component.html',
})
export class AltaHotelComponent {

  url_base: string;

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
    PrecioNoche: "",
    Descripcion: "",
    SinCapacidad: false,
    NroTelefono: "",
    InfoContacto:""
  }


  constructor(@Inject('BASE_URL') baseUrl: string, private http: HttpClient) {
    this.url_base = baseUrl;
  }



}
