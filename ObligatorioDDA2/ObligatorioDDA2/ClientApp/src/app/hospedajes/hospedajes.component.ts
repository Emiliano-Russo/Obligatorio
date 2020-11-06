import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'hospedajes',
  templateUrl: './hospedajes.component.html',
})
export class HospedajesComponent implements OnInit {



  constructor(private router: ActivatedRoute, private http: HttpClient) {
  }


  ngOnInit() {
    this.router.paramMap.
      subscribe(params => {
        console.log(params);
      });
  }

}
