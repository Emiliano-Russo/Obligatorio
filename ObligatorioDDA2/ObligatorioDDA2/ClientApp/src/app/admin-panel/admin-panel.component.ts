import { Component, Inject } from '@angular/core';


@Component({
  selector: 'admin',
  templateUrl: './admin-panel.component.html',
})
export class AdminPanelComponent {

  url_base: string;

  constructor( @Inject('BASE_URL') baseUrl: string) {
    this.url_base = baseUrl;
  }

}
