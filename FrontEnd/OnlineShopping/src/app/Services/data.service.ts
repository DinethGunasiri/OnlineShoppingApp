import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  isLogged: boolean;

  isLoggedChange: Subject<boolean> = new Subject<boolean>();

  constructor() {
  }
  
  callNavBar() {
    this.isLoggedChange.next(true);
  }
}
