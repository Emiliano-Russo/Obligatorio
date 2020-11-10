import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'modificar-hotel',
  templateUrl: './modificar-hotel.component.html',
})
export class ModificarHotelComponent {

  url_base: string;
  mensaje_server: string;

  constructor(@Inject('BASE_URL') baseUrl: string, private http: HttpClient) {
    this.url_base = baseUrl;
  }


  enviar() {
    let nombre = (<HTMLInputElement>document.getElementById("hotel")).value;
    let disp = ((<HTMLInputElement>document.getElementById("disponibilidad")).value) == "true";
    let argumentos = "?nombre=" + nombre + "&disponibilidad=" + disp;
    console.log("argumentos: " + argumentos);
    this.http.get<string>(this.url_base + 'Hospedajes/Modificar' + argumentos).subscribe(result => {
      this.mensaje_server = result;
    });

  }

}
