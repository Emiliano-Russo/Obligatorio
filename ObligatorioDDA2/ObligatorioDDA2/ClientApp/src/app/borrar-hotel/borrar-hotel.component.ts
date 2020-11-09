import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'borrar-hotel',
  templateUrl: './borrar-hotel.component.html',
})
export class BorrarHotelComponent {

  url_base: string;


  constructor(@Inject('BASE_URL') baseUrl: string, private http: HttpClient) {
    this.url_base = baseUrl;
  }



}
