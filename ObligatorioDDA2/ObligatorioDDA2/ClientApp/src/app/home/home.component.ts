import { Component, Inject } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { environment } from "src/environments/environment.prod";

@Component({
  selector: "app-home",
  templateUrl: "./home.component.html",
  styleUrls: ["./home.component.css"],
})
export class HomeComponent {
  url: string;
  regiones = {
    0: "",
    1: "",
    2: "",
    3: "",
    4: "",
    5: "",
  };

  constructor(private http: HttpClient, @Inject("BASE_URL") baseUrl: string) {
    console.log(baseUrl);
    this.http
      .get<string>(baseUrl + "Regiones")
      .subscribe((result) => {
        this.asignar_regiones(result);
      },err=> console.log('HTTP Error', err));
    // this.http
    //   .get<string>("http://localhost:5000/Regiones")
    //   .subscribe((result) => {
    //     this.asignar_regiones(result);
    //   });
  }

  asignar_regiones(objeto: any) {
    this.regiones[0] = objeto[0].replace("_", " ");
    this.regiones[1] = objeto[1].replace("_", " ");
    this.regiones[2] = objeto[2].replace("_", " ");
    this.regiones[3] = objeto[3].replace("_", " ");
    this.regiones[4] = objeto[4].replace("_", " ");
  }
}
