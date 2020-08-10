import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { catchError, map } from 'rxjs/operators';
import { throwError } from 'rxjs';
import { NotificationService } from '../Services/notification-service.service';
import { stat } from 'fs';

@Injectable({
  providedIn: 'root'
})
export class CustomerServiceService {

 // private customeruri = 'https://localhost:44371/api/customer';

 private customeruri = 'https://localhost:44355/api/customer';

  constructor(private http: HttpClient) { }

  getCustomers() {
    return this.http.get(`${this.customeruri}`);
  }

  getCustomer(email) {
    return this.http.get(`${this.customeruri}/${email}`);
  }

  postCustomer(email, fName, lName, birthDate, gender, address, street, city, state, zipCode, telephone, password) {
    const customer = {
      Email: email,
      fName: fName,
      lName: lName,
      BirthDate: birthDate,
      Gender: gender,
      Address: address,
      StreetName: street,
      City: city,
      State: state,
      ZipCode: zipCode,
      Telephone: telephone,
      Password: password
    };
    console.log(customer);
    return this.http.post(`${this.customeruri}`, customer);
  }

  editCustomer(email, fName, lName, birthDate, gender, address, street, city, state, zipCode, telephone) {
    const customer = {
      fName: fName,
      lName: lName,
      BirthDate: birthDate,
      Gender: gender,
      Address: address,
      StreetName: street,
      City: city,
      State: state,
      ZipCode: zipCode,
      Telephone: telephone
    };
    return this.http.put(`${this.customeruri}/${email}`, customer);
  }

  deleteCustomer(email) {
    return this.http.delete(`${this.customeruri}/${email}`);
  }
/*
  checkCustomer(email) {
    console.log(email);
    return this.http.get(`${this.customeruri}/check/${email}`);
  }
*/
}
