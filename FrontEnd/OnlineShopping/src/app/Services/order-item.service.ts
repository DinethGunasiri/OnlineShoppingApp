import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class OrderItemServiceService {

  // private productItemuri = 'https://localhost:44371/api/items';
  private productItemuri = 'https://localhost:44355/api/items';

  constructor(private http: HttpClient) { }

  getOrderItems() {
    return this.http.get(`${this.productItemuri}`);
  }

  getOrderItem(id) {
    return this.http.get(`${this.productItemuri}/${id}`);
  }

  postOrderItem(productId, quantity, purchasePrice, orderId) {
    const item = {
      ProductId: productId,
      Quantity: quantity,
      PurchasePrice: purchasePrice,
      OrderId: orderId
    };
    console.log(item);
    return this.http.post(`${this.productItemuri}`, item);
  }

  editOrderItem(itemId, productId, quantity, purchasePrice) {
    const item = {
      ProductId: productId,
      Quantity: quantity,
      PurchasePrice: purchasePrice
    };
    return this.http.put(`${this.productItemuri}/${itemId}`, item);
  }

  deleteOrderItem(itemId) {
    return this.http.delete(`${this.productItemuri}/${itemId}`);
  }

  sendEmail(productId) {
    return this.http.get(`${this.productItemuri}/email/${productId}`);
    console.log(productId);
  }
}
