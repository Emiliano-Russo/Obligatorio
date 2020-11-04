import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {

  regiones: String;
  url: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    console.log("Se entra al constructor de HomeComponent");
    this.url = baseUrl;
  }

  ObtenerRegiones() {
    console.log("Metodo Obtener Regiones");
    this.http.get<String>(this.url + 'Regiones/Hola').subscribe(result => {
      console.log("El resultado fue: " + result);
      this.regiones = result;
    });
  }



}



