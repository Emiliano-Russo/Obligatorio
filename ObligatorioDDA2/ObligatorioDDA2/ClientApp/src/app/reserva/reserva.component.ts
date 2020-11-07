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
}
