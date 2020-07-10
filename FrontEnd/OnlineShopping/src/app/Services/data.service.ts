import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';
import { CookieService } from 'ngx-cookie-service';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  isLogged: boolean;
  cartCount: string;

  isLoggedChange: Subject<boolean> = new Subject<boolean>();
  cartCountChange: Subject<string> = new Subject<string>();

  constructor(private cookieService: CookieService) {
  }

  callNavBar() {
    this.isLoggedChange.next(true);
    this.cartCountChange.next(this.cookieService.get('count'));
    console.log(this.cookieService.get('count'));
  }
}
