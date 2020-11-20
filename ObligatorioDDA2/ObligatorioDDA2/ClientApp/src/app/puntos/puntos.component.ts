import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router'
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'puntos',
  templateUrl: './puntos.component.html',
  styleUrls: ['./puntos.component.css','./multicolors.component.css'],
})
export class PuntosComponent implements OnInit {

  region_n: string;
  region_show: string;
  puntos: string;
  filtros = [false, false, false, false];

  constructor(private router: ActivatedRoute, private http: HttpClient, private ruta: Router) {
  }
   
  ngOnInit() {
    this.router.paramMap.
      subscribe(params => {
        console.log(params);
        this.region_n = params.get("id");
        this.region_show = this.parse_id_region(this.region_n);
      });  

    this.http.get<string>("https://localhost:44336/" + 'PuntosTuristicos/Busqueda?region=' + this.region_n).subscribe(result => {
      console.log(result);
      this.puntos = result;
    });
  }

  parse_id_region(id: string) {
    switch (id) {
      case "0":
        return "Metropolitana";
        break;
      case "1":
        return "Centro Sur";
      case "2":
        return "Este";
        break;
      case "3":
        return "Litoral Norte";
        break;
      case "4":
        return "Corredor Pajaros Pintados";
        break;
      default:
        return id;
    }
  }

  buscarRegionesCategoria() {
    let urlfinal = "https://localhost:44336/" + 'PuntosTuristicos/Busqueda?region=' + this.region_n + '&categorias=' + this.parseCategorias();
    console.log("url final: " + urlfinal);
    this.http.get<string>(urlfinal).subscribe(result => {
      console.log(result);
      this.puntos = result;
    });
  }


  filtrar(i: number) {
    this.filtros[i] = !this.filtros[i];
    this.cambiarColorBoton(i.toString());
    this.buscarRegionesCategoria();
  }

  cambiarColorBoton(i: string) {
    if (this.filtros[i]) {
      document.getElementById(i).style.color = "Gold";
    } else {
      document.getElementById(i).style.color = "white";
    }
  }

  parseCategorias() {
    var categoriasTotal = "";
    for (var i = 0; i < this.filtros.length; i++) {
      if (this.filtros[i]) {
        categoriasTotal += i;
      }
    }
    return categoriasTotal;
  }

  irAHospedajes(nombre: string) {
    this.ruta.navigate(['/hospedajes', nombre]);
  }

}
