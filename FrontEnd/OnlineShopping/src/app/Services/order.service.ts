import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  private ordersuri = 'https://localhost:44371/api/order';

  constructor(private http: HttpClient) { }

  getOrders() {
    return this.http.get(`${this.ordersuri}`);
  }

  getOrdeById(id) {
    return this.http.get(`${this.ordersuri}/${id}`);
  }

  postOrder(Date, address, email) {
    const order = {
      orderDate: Date,
      ShippingAddress: address,
      CustomerId: email
    };
    // console.log(order);
    return this.http.post(`${this.ordersuri}`, order);
  }
}
