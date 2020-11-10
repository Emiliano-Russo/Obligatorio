import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'consulta-reserva',
  templateUrl: './consulta-reserva.component.html',
})
export class ConsultaReservaComponent {

  url_base: string;
  consulta = {
    nombre: "",
    descripcion:"",
    estado:""
  }

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.url_base = baseUrl;
  }



  ver_estado_reserva() {
    let codigo = (<HTMLInputElement>document.getElementById("codigo")).value;
    this.http.get<string>(this.url_base + "Reserva/Estado?codigo=" + codigo).subscribe(result => {
      this.asignar_a_consulta(result);
    });
  }

  asignar_a_consulta(objeto: any) {
    this.consulta.nombre = objeto.nombre;
    this.consulta.descripcion = objeto.descripcion;
    this.consulta.estado = this.parse_estado(objeto.estado);
  }

  parse_estado(estado:number) {
    switch (estado) {
      case 0: {
        return "Creada";
        break;
      }
      case 1: {
       return "Pendiente Pago";
        break;
      }
      case 2: {
        return "Aceptada";
        break;
      }
      case 3: {
        return "Rechazada";
        break;
      }
      case 4: {
        return "Expirada";
        break;
      }
    }
  }
}
