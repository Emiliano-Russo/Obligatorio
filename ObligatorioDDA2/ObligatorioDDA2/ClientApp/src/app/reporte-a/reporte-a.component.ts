import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './reporte-a.component.html',
  styleUrls:['./reporte-a.component.css'],
})
export class ReporteAComponent {

  url: string;
  reportes: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.url = baseUrl;
  }

  InfoReporte = {
    NombrePunto: "",
    Inicio: "",
    Final:""
  }

  buscar() {
    var nombre = (<HTMLInputElement>document.getElementById("punto")).value;
    var ingreso = (<HTMLInputElement>document.getElementById("entrada")).value;
    var salida = (<HTMLInputElement>document.getElementById("salida")).value;

    this.InfoReporte.NombrePunto = nombre;
    this.InfoReporte.Inicio = ingreso;
    this.InfoReporte.Final = salida;

    this.http.post<string>(this.url + 'Reserva/ReporteA', this.InfoReporte).subscribe(data => {
      console.log(data);
      this.reportes = data;
    });
  }
}


