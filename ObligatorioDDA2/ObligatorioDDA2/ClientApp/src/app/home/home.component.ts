import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls:['./home.component.css'],
})
export class HomeComponent {

  regiones: string;
  url: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.http.get<String>(baseUrl + 'Regiones').subscribe(result => {
      this.regiones = result.toString();
    });
  }


}


