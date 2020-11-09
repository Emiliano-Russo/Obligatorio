import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'modificar-reserva',
  templateUrl: './modificar-reserva.component.html',
})
export class ModificarReservaComponent {

  url_base: string;


  constructor(@Inject('BASE_URL') baseUrl: string, private http: HttpClient) {
    this.url_base = baseUrl;
  }



}
