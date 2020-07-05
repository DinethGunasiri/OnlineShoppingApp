import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { catchError, map } from 'rxjs/operators';
import { throwError } from 'rxjs';
import { NotificationService } from '../Services/notification-service.service';

@Injectable({
  providedIn: 'root'
})
export class CustomerServiceService {

  private customeruri = 'https://localhost:44371/api/customer';

  constructor(private http: HttpClient) { }

  getCustomers() {
    return this.http.get(`${this.customeruri}`);
  }

  getCustomer(email) {
    return this.http.get(`${this.customeruri}/${email}`);
  }

  postCustomer(email, fullName, birthDate, gender, address, zipCode, telephone, password) {
    const customer = {
      Email: email,
      FullName: fullName,
      BirthDate: birthDate,
      Gender: gender,
      Address: address,
      ZipCode: zipCode,
      Telephone: telephone,
      Password: password
    };
    console.log(customer);
    return this.http.post(`${this.customeruri}`, customer);
  }

  editCustomer(email, fullName, birthDate, gender, address, zipCode, telephone) {
    const customer = {
      FullName: fullName,
      BirthDate: birthDate,
      Gender: gender,
      Address: address,
      ZipCode: zipCode,
      Telephone: telephone
    };
    return this.http.put(`${this.customeruri}/${email}`, customer);
  }

  deleteCustomer(email) {
    return this.http.delete(`${this.customeruri}/${email}`);
  }

  checkCustomer(email) {
    console.log(email);
    return this.http.get(`${this.customeruri}/check/${email}`);
  }

}
