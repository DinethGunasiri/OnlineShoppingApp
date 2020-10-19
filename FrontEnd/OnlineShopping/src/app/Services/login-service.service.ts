import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class LoginServiceService {

  constructor(private http: HttpClient) { }

  loginCustomer(email, password) {
    const login = {
      Email: email,
      Password: password
    };
    return this.http.post(`${environment.url}/login`, login);
  }
}
