import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'alta-punto',
  templateUrl: './alta-punto.component.html',
  styleUrls: ['./alta-punto.component.css'],
})
export class AltaPuntoComponent {

  url_base: string;
  categorias = [false, false, false, false];
  respuesta: string;

  constructor(@Inject('BASE_URL') baseUrl: string, private http: HttpClient) {
    this.url_base = baseUrl;
  }

  registrar() {
    this.armar_puntoturistico();
    console.log("resultado del armado:");
    console.log(this.punto_turistico);
    this.http.post<string>(this.url_base + 'PuntosTuristicos/Alta', this.punto_turistico).subscribe(data => {
      console.log(data);
      this.respuesta = data;
    })
  }

  armar_puntoturistico() {
    let nombre = (<HTMLInputElement>document.getElementById("nombre")).value;
    let des = (<HTMLInputElement>document.getElementById("descripcion")).value;
    let region =  Number((<HTMLInputElement>document.getElementById("region")).value);
    let categorias = this.parse_categorias();

    this.punto_turistico.Nombre = nombre;
    this.punto_turistico.Descripcion = des;
    this.punto_turistico.Region = region;
    this.punto_turistico.Categoria = categorias;
  }

  parse_categorias() {
    let retorno = [];
    let j = 0;
    for (var i = 0; i < this.categorias.length; i++) {
      if (this.categorias[i]) {
        retorno[j] = i;
        j++;
      }
    }
    return retorno;
  }

  modificar_array_categoria(i: number) {
    this.categorias[i] = !this.categorias[i];
    this.cambiar_color_boton(i);
  }

  cambiar_color_boton(i: number) {
    if (this.categorias[i]) {
      (<HTMLInputElement>document.getElementById("c" + i)).style.backgroundColor = "MediumSpringGreen"
    } else {
      (<HTMLInputElement>document.getElementById("c" + i)).style.backgroundColor = "White";
    }
  }

  punto_turistico = {
    Nombre: "",
    Descripcion: "",
    Region: 0,
    Categoria: [],
    ImgName:["imgname"]
  }

}
