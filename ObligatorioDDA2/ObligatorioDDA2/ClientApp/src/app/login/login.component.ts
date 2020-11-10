import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { NavMenuComponent } from '../nav-menu/nav-menu.component';

@Component({
  selector: 'login',
  templateUrl: './login.component.html',
})
export class LoginComponent {

  url_base: string;
  cabecera: NavMenuComponent;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string, private ruta: Router, header: NavMenuComponent) {
    this.url_base = baseUrl;
    this.cabecera = header;
  }

  ingresar() {
    var usuario = (<HTMLInputElement>document.getElementById("usuario")).value;
    var contra = (<HTMLInputElement>document.getElementById("contraseña")).value;
    this.login(usuario, contra);
  }

  login(usuario: string, contra: string) {
    let resultado_login = "";
    var argumentos = "?email=" + usuario + "&contra=" + contra;
    this.http.get<string>(this.url_base + 'Login/Ingresar' + argumentos).subscribe(result => {
      resultado_login = result;
      console.log(resultado_login);
      if (resultado_login == "Login Exitoso!") {
        this.activar_interfaz_sesion();
        this.redireccionar();
      }
    });
    
  }
  redireccionar() {
    this.ruta.navigate(['/']);
  }

  activar_interfaz_sesion() {
    console.log("activamos la interfaz sesion");
    this.cabecera.activar_interfaz_sesion();
  }


}
