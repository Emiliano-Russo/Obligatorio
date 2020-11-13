import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
@Component({
  selector: 'puntuar',
  templateUrl: './puntuar.component.html',
  styleUrls: ['puntuar.component.css']
})
export class PuntuarComponent {

  url_base: string;
  resultado: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.url_base = baseUrl;
  }

  Puntuacion_Envio = {
    Puntos: 0,
    Comentario: "",
    Codigo: ""
  }

  enviar() {
    this.armar_obj();
    
    this.http.post<string>(this.url_base + 'Hospedajes/Puntuar', this.Puntuacion_Envio).subscribe(result => {
      console.log(result);
      this.resultado = result;
    });
    
  }

  armar_obj() {
    let codigo = (<HTMLInputElement>document.getElementById("codigo")).value;
    let puntaje = Number((<HTMLInputElement>document.getElementById("puntaje")).value);
    let comentario = (<HTMLInputElement>document.getElementById("comentario")).value;

    this.Puntuacion_Envio.Codigo = codigo;
    this.Puntuacion_Envio.Puntos = puntaje;
    this.Puntuacion_Envio.Comentario = comentario;
  }

}
