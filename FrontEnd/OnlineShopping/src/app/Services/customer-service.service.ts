import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CustomerServiceService {


  constructor(private http: HttpClient) { }

  // Get all customers
  getCustomers() {
    return this.http.get(`${environment.url}/customer`);
  }

  // Get customer by email
  getCustomer(email) {
    return this.http.get(`${environment.url}/customer/${email}`);
  }

  // Save customer to database
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
    return this.http.post(`${environment.url}/customer`, customer);
  }

  // Edit customer details
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
    return this.http.put(`${environment.url}/customer/${email}`, customer);
  }

  // Delete customer
  deleteCustomer(email) {
    return this.http.delete(`${environment.url}/customer/${email}`);
  }
}
