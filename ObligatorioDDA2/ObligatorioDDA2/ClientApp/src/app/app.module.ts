import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { PuntosComponent } from './puntos/puntos.component';
import { HospedajesComponent } from './hospedajes/hospedajes.component';
import { ReservaComponent } from './reserva/reserva.component';
import { DatosReserva } from './datos-reserva/datos-reserva.injectable';
import { ConsultaReservaComponent } from './consulta-reserva/consulta-reserva.component';
import { LoginComponent } from './login/login.component';
import { DatosLogin } from './datos-login/datos-login.injectable';
import { AdminPanelComponent } from './admin-panel/admin-panel.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    PuntosComponent,
    HospedajesComponent,
    ReservaComponent,
    ConsultaReservaComponent,
    LoginComponent,
    AdminPanelComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'puntos/:id', component: PuntosComponent },
      { path: 'hospedajes/:nombre', component: HospedajesComponent },
      { path: 'reserva', component: ReservaComponent },
      { path: 'consulta', component: ConsultaReservaComponent },
      { path: 'ingresar', component: LoginComponent },
      { path: 'admin_panel', component: AdminPanelComponent }
    ])
  ],
  providers: [DatosReserva, DatosLogin, NavMenuComponent],
  bootstrap: [AppComponent]
})
export class AppModule { }
