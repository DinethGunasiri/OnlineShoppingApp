import { Component, OnInit, ViewChild } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { DataService } from '../Services/data.service';
import { NotificationService } from '../Services/notification-service.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent implements OnInit {
  isLogged: boolean;
  fullName: any;
  count = 0;

  constructor(private cookieService: CookieService,
              private notifyService: NotificationService,
              private dataService: DataService) {
                this.dataService.isLoggedChange.subscribe(value => {
                  if (value == true) {
                    this.ngOnInit();
                  }
                });

                this.dataService.cartCountChange.subscribe(value => {
                 // console.log(value);
                  this.count = Number(value);

                  if (this.count != null) {
                    this.ngOnInit();
                  }
                });
              }

  ngOnInit(): void {
   // console.log(this.isLogged);
   // console.log(this.count);
    this.onChekingLoggin();
  }

  onChekingLoggin() {
    if (this.cookieService.get('Loged') == 'true') {
      this.isLogged = true;
      this.fullName = this.cookieService.get('fullName');
      if (this.cookieService.get('count') == null) {
        this.count = this.count;
      }
      else {
        this.count = Number(this.cookieService.get('count'));
      }
    }
    else {
      this.isLogged = false;
      if (this.cookieService.get('count') == null) {
        this.count = this.count;
      }
      else {
        this.count = Number(this.cookieService.get('count'));
      }
    }
  }

  onLogout() {
     this.cookieService.delete('Token');
     this.cookieService.delete('fullName');
     this.cookieService.delete('Loged');
     this.isLogged = false;
   // this.cookieService.deleteAll();
    // this.isLogged = false;
     console.log(this.isLogged);
     this.notifyService.showSuccess('Logged out successfully', 'Log out');
   // this.ngOnInit();
  }

}
