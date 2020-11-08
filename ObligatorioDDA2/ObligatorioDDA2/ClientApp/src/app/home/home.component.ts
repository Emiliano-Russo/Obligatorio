import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls:['./home.component.css'],
})
export class HomeComponent {

  url: string;
  regiones = {
    0: "",
    1: "",
    2: "",
    3: "",
    4: "",
    5:"",
  }

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http.get<string>(baseUrl + 'Regiones').subscribe(result => {
      this.asignar_regiones(result);
    });
  }

  asignar_regiones(objeto: any) {
    this.regiones[0] = objeto[0];
    this.regiones[1] = objeto[1];
    this.regiones[2] = objeto[2];
    this.regiones[3] = objeto[3];
    this.regiones[4] = objeto[4];
  }

}


