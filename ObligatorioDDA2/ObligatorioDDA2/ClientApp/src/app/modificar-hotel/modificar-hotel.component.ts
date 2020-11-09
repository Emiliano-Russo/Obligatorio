import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'modificar-hotel',
  templateUrl: './modificar-hotel.component.html',
})
export class ModificarHotelComponent {

  url_base: string;


  constructor(@Inject('BASE_URL') baseUrl: string, private http: HttpClient) {
    this.url_base = baseUrl;
  }



}
