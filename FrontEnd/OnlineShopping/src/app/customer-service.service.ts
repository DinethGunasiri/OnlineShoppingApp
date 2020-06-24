import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CustomerServiceService {

  private customeruri = 'https://localhost:44371/api/customer';

  constructor(private http: HttpClient) { }

  getCustomers() {
    return this.http.get(`${this.customeruri}/all`);
  }

  getCustomer(email) {
    return this.http.get(`${this.customeruri}/email/${email}`);
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
    return this.http.post(`${this.customeruri}/new`, customer);
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
    return this.http.put(`${this.customeruri}/edit/${email}`, customer);
  }

  deleteCustomer(email) {
    return this.http.delete(`${this.customeruri}/delete/${email}`);
  }

}
