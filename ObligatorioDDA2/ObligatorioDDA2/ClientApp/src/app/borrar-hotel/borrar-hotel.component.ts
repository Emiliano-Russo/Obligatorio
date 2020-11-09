import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'borrar-hotel',
  templateUrl: './borrar-hotel.component.html',
})
export class BorrarHotelComponent {

  url_base: string;
  hoteles: string;
  mensaje_server: string;

  constructor(@Inject('BASE_URL') baseUrl: string, private http: HttpClient) {
    this.url_base = baseUrl;
  }

  eliminar() {
    let nombre = (<HTMLInputElement>document.getElementById("hotel")).value;
    this.http.get<string>(this.url_base + 'Hospedajes/Baja?nombreHotel=' + nombre).subscribe(result => {
      console.log(result);
      this.mensaje_server = result;
    });
  }

}
