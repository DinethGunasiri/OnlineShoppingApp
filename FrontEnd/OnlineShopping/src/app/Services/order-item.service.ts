import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class OrderItemServiceService {

  // private productItemuri = 'https://localhost:44371/api/items';
  private productItemuri = 'https://localhost:44355/api/items';

  constructor(private http: HttpClient) { }

  // Get all order items
  getOrderItems() {
    return this.http.get(`${this.productItemuri}`);
  }

  // Get order item by id
  getOrderItem(id) {
    return this.http.get(`${this.productItemuri}/${id}`);
  }

  // Save order item to database
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

  // Edit order item
  editOrderItem(itemId, productId, quantity, purchasePrice) {
    const item = {
      ProductId: productId,
      Quantity: quantity,
      PurchasePrice: purchasePrice
    };
    return this.http.put(`${this.productItemuri}/${itemId}`, item);
  }

  // Delete order item
  deleteOrderItem(itemId) {
    return this.http.delete(`${this.productItemuri}/${itemId}`);
  }

  // Send order confirmation to user
  sendEmail(productId) {
    return this.http.get(`${this.productItemuri}/email/${productId}`);
    console.log(productId);
  }
}
