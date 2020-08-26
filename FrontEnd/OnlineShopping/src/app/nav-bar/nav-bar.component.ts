import { Component, OnInit, ViewChild } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { DataService } from '../Services/data.service';
import { NotificationService } from '../Services/notification-service.service';
import { Router } from '@angular/router';

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
              private dataService: DataService,
              private router: Router) {
                this.dataService.isLoggedChange.subscribe(value => {
                  if (value == true) {
                    this.ngOnInit();
                  }
                });

                this.dataService.cartCountChange.subscribe(value => {
                  this.count = Number(value);

                  if (this.count != null) {
                    this.ngOnInit();
                  }
                });
              }

  ngOnInit(): void {
    this.onChekingLoggin();
  }

  // check user log in or not
  onChekingLoggin() {
    if (this.cookieService.get('Loged') == 'true') {
      this.isLogged = true;
      // show user name in welcome message in navigation bar
      this.fullName = this.cookieService.get('fullName');
      if (this.cookieService.get('count') == null) {
        this.count = this.count;
      }
      else { // shopping cart count
        this.count = Number(this.cookieService.get('count'));
      }
    }
    else { // if user is not logged in
      this.isLogged = false;
      if (this.cookieService.get('count') == null) {
        this.count = this.count;
      }
      else {
        this.count = Number(this.cookieService.get('count'));
      }
    }
  }

  // delete cookies when user log out
  onLogout() {
     this.cookieService.delete('Token');
     this.cookieService.delete('fullName');
     this.cookieService.delete('Loged');
     this.cookieService.delete('Email');
     this.isLogged = false;
     this.notifyService.showSuccess('Logged out successfully', 'Log out');
  }

  // pop error when lick on empty shopping cart
  clickShoppingCart() {
    console.log(this.count);
    if (this.count == 0) { 
      this.notifyService.showWarning('Shopping cart is empty!', 'Shopping Cart');
    }
    else {
      this.router.navigate(['/cart']);
    }
  }

}
