import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  constructor(private http: HttpClient) { }

  // Get all orders
  getOrders() {
    return this.http.get(`${environment.url}/order`);
  }

  // Get order by id
  getOrdeById(id) {
    return this.http.get(`${environment.url}/order/${id}`);
  }

  // Save order in database
  postOrder(Date, address, email, total, paymentType) {
    const order = {
      orderDate: Date,
      ShippingAddress: address,
      CustomerId: email,
      TotalPrice: total,
      PaymentType: paymentType
    };
    return this.http.post(`${environment.url}/order`, order);
  }
}
