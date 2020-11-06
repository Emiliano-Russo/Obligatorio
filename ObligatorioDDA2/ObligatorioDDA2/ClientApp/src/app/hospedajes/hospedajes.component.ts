import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'hospedajes',
  templateUrl: './hospedajes.component.html',
})
export class HospedajesComponent implements OnInit {

  nombrePunto: string;
  personas: number[] = [0, 0, 0, 0];
  hoteles: string;

  constructor(private router: ActivatedRoute, private http: HttpClient) {
  }


  ngOnInit() {
    this.router.paramMap.
      subscribe(params => {
        this.nombrePunto = params.get("nombre");
        console.log("Punto: " + this.nombrePunto);
      });
    this.alojamiento.Punto.Nombre = this.nombrePunto;
 
  }

  sumarPersona(i: number) {
    console.log("llego el numero: " + i);
    console.log(this.personas == undefined);
    this.personas[i]++;
  }
  quitarPersona(i: number) {
    if (this.personas[i] > 0) {
      this.personas[i]--;
    }
  }

  alojamiento = {
    "Punto": {
      "Nombre": "",
      "Descripcion": "asd",
      "Region": 0,
      "Categoria": [0],
      "ImgName":["zero"]
    },
    "Estadia": {
      "Entrada": "",
      "Salida": "",
      "RangoEdades":[0]
    }
  }

  buscarHospedajes() {
    this.alojamiento.Estadia.Entrada = (<HTMLInputElement>document.getElementById("entrada")).value;
    this.alojamiento.Estadia.Salida = (<HTMLInputElement>document.getElementById("salida")).value;
    this.alojamiento.Estadia.RangoEdades = this.personas;

    this.http.post<string>("https://localhost:44336/" + 'Hospedajes/Busqueda', this.alojamiento).subscribe(data => {
      console.log(data);
      this.hoteles = data;
    })
  }


}
