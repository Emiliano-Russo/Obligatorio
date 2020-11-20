import { Component, OnInit } from '@angular/core';
import { DatosLogin } from '../datos-login/datos-login.injectable';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {
  isExpanded = false;

  constructor(private datos_login: DatosLogin) {
    
  }
    ngOnInit(): void {
      this.desactivar_interfaz_sesion();
    }

  

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  activar_interfaz_sesion() {
    (<HTMLInputElement>document.getElementById("admin")).style.display = "block";
    (<HTMLInputElement>document.getElementById("login")).style.display = "none";
  }

  desactivar_interfaz_sesion() {
    (<HTMLInputElement>document.getElementById("admin")).style.display = "none";
    (<HTMLInputElement>document.getElementById("login")).style.display = "block";
  }
}
