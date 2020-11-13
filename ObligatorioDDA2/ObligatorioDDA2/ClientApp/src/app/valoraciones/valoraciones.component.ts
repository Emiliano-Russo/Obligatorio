import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'valoraciones',
  templateUrl: './valoraciones.component.html',
  styleUrls: ['./valoraciones.component.css']
})
export class ValoracionesComponent implements OnInit {

  url_base: string;
  nombre_hotel: string;
  valoraciones: any;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string, private router: ActivatedRoute) {
    this.url_base = baseUrl;
  }
    ngOnInit(): void {
      this.router.paramMap.
        subscribe(params => {
          this.nombre_hotel = params.get("nombre");
        });
    }

  llenar_valoraciones() {
    this.http.get<string>(this.url_base + 'Hospedajes/GetPuntuaciones' + '?alojamiento=' + this.nombre_hotel).subscribe(result => {
      this.valoraciones = result;
      console.log(this.valoraciones);
    });
  }
}
