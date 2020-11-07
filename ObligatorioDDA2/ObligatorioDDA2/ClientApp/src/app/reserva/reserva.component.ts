import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { DatosReserva } from '../datos-reserva/datos-reserva.injectable';

@Component({
  selector: 'reserva',
  templateUrl: './reserva.component.html',
})
export class ReservaComponent implements OnInit {

  entrada = "";
  salida = "";
  nombre_hotel: string;
  cantidad_personas: number;

  constructor(private router: ActivatedRoute, private http: HttpClient, private clase_datos: DatosReserva) {
  }
  ngOnInit(): void {
    console.log(this.clase_datos.datos);
    this.entrada = this.clase_datos.datos.Estadia.Entrada;
    this.salida = this.clase_datos.datos.Estadia.Salida;
    (<HTMLInputElement>document.getElementById("entrada")).value = this.entrada;
    (<HTMLInputElement>document.getElementById("salida")).value = this.salida;
    this.nombre_hotel = this.clase_datos.datos.Hotel.Nombre;
    this.cantidad_personas = this.calcular_cantidad(this.clase_datos.datos.Estadia.RangoEdades);
  }

  calcular_cantidad(edades: any[]) {
    let cantidad = 0;
    for (var i = 0; i < edades.length; i++) {
      cantidad += edades[i];
    }
    return cantidad;
  }

  InfoReserva = {
    "Nombre": "",
    "Apellido": "",
    "Email": "",
    "Estadia": "",
    "Hotel":""
  }

  realizar_reserva() {
    let estadia_obj = this.clase_datos.datos.Estadia;
    let hotel_obj = this.clase_datos.datos.Hotel;
    let nombre_persona = (<HTMLInputElement>document.getElementById("nombre")).value;
    let apellido_persona = (<HTMLInputElement>document.getElementById("apellido")).value;
    let email_persona = (<HTMLInputElement>document.getElementById("email")).value;

    this.InfoReserva.Nombre = nombre_persona;
    this.InfoReserva.Apellido = apellido_persona;
    this.InfoReserva.Email = email_persona;
    this.InfoReserva.Estadia = estadia_obj;
    this.InfoReserva.Hotel = hotel_obj;

    console.log("------------");
    console.log("info reserva");
    console.log(this.InfoReserva);
    console.log("------------");

    this.http.post<string>("https://localhost:44336/" + 'Reserva/Reservar', this.InfoReserva).subscribe(data => {
      console.log(data);
    })
  }
}
