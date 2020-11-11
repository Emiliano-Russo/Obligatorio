import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'modificar-reserva',
  templateUrl: './modificar-reserva.component.html',
})
export class ModificarReservaComponent {

  url_base: string;
  mensaje_server: string;

  constructor(@Inject('BASE_URL') baseUrl: string, private http: HttpClient) {
    this.url_base = baseUrl;
  }


  enviar() {
    let codigo = (<HTMLInputElement>document.getElementById("codigo")).value;
    let estado = Number((<HTMLInputElement>document.getElementById("estado")).value);
    let argumentos = "?codigo=" + codigo + "&estado="+estado;
    this.http.get<string>(this.url_base + 'Reserva/CambiarEstado' + argumentos).subscribe(result => {
      console.log(result);
      this.mensaje_server = result;
    });

  }
}
