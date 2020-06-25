import { Component, OnInit, ViewChild } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { DataService } from '../Services/data.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent implements OnInit {
  isLogged: boolean;
  fullName: any;

  constructor(private cookieService: CookieService,
              private dataService: DataService) {
                this.dataService.isLoggedChange.subscribe(value => {
                  if (value == true) {
                    this.ngOnInit();
                  }
                });
              }

  ngOnInit(): void {
  // this.cookieService.deleteAll();
   this.onChekingLoggin();
  }

  onChekingLoggin() {
    if (this.cookieService.get('Loged') == 'true') {
      this.isLogged = true;
      this.fullName = this.cookieService.get('fullName');
  }
  else {
    this.isLogged = false;
  }
  }

}
