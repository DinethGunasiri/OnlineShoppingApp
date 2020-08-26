import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class OrderService {
  // private ordersuri = 'https://localhost:44371/api/order';
  private ordersuri = 'https://localhost:44355/api/order';

  constructor(private http: HttpClient) { }

  // Get all orders
  getOrders() {
    return this.http.get(`${this.ordersuri}`);
  }

  // Get order by id
  getOrdeById(id) {
    return this.http.get(`${this.ordersuri}/${id}`);
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
    return this.http.post(`${this.ordersuri}`, order);
  }
}
