import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { DatosReserva } from '../datos-reserva/datos-reserva.injectable';

@Component({
  selector: 'reserva',
  templateUrl: './reserva.component.html',
})
export class ReservaComponent implements OnInit {

  nombre_hotel: string;
  cantidad_personas: number;

  reserva: string;

  constructor(private router: ActivatedRoute, private http: HttpClient, private clase_datos: DatosReserva) { }

  ngOnInit(): void {
    this.ocultar_seccion_reserva();
    this.establecer_datos_pagina();
  }

  ocultar_seccion_reserva() {
    document.getElementById("resultado_reserva").style.display = "none";
  }

  mostrar_seccion_reserva() {
    document.getElementById("resultado_reserva").style.display = "block";
  }

  establecer_datos_pagina() {
    this.rellenar_fechas();
    this.nombre_hotel = this.clase_datos.datos.Hotel.Nombre;
    this.cantidad_personas = this.calcular_cantidad_personas(this.clase_datos.datos.Estadia.RangoEdades);
  }

  rellenar_fechas() {
    (<HTMLInputElement>document.getElementById("entrada")).value = this.clase_datos.datos.Estadia.Entrada;
    (<HTMLInputElement>document.getElementById("salida")).value = this.clase_datos.datos.Estadia.Salida;
  }

  calcular_cantidad_personas(edades: any[]) {
    let cantidad = 0;
    for (var i = 0; i < edades.length; i++) {
      cantidad += edades[i];
    }
    return cantidad;
  }

  realizar_reserva() {
    this.rellenar_datos_InfoReserva();
    this.peticion_post_reservar();
    this.mostrar_seccion_reserva();
    this.rellenar_datos_seccion_reserva();
  }

  rellenar_datos_InfoReserva() {
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
  }

  peticion_post_reservar() {
    this.http.post<string>("https://localhost:44336/" + 'Reserva/Reservar', this.InfoReserva).subscribe(result => {
      this.reserva = result;
    });
  }

  rellenar_datos_seccion_reserva() {
    console.log("la reserva es:");
    console.log(this.reserva);
  }

  InfoReserva = {
    "Nombre": "",
    "Apellido": "",
    "Email": "",
    "Estadia": "",
    "Hotel": ""
  }

}
