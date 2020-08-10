import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class LoginServiceService {

  //  private loginuri = 'https://localhost:44371/api/login';
  private loginuri = 'https://localhost:44355/api/login';

  constructor(private http: HttpClient) { }

  loginCustomer(email, password) {
    const login = {
      Email: email,
      Password: password
    };
    return this.http.post(`${this.loginuri}`, login);
  }
}
