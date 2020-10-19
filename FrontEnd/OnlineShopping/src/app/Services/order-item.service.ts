import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class OrderItemServiceService {

  // private productItemuri = 'https://localhost:44355/api/items';

  private productItemuri = 'http://onlineshopping.com:90/api/items';

  constructor(private http: HttpClient) { }

  // Get all order items
  getOrderItems() {
    return this.http.get(`${environment.url}/items`);
  }

  // Get order item by id
  getOrderItem(id) {
    return this.http.get(`${environment.url}/items/${id}`);
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
    return this.http.post(`${environment.url}/items`, item);
  }

  // Edit order item
  editOrderItem(itemId, productId, quantity, purchasePrice) {
    const item = {
      ProductId: productId,
      Quantity: quantity,
      PurchasePrice: purchasePrice
    };
    return this.http.put(`${environment.url}/items/${itemId}`, item);
  }

  // Delete order item
  deleteOrderItem(itemId) {
    return this.http.delete(`${environment.url}/items/${itemId}`);
  }

  // Send order confirmation to user
  sendEmail(productId) {
    return this.http.get(`${environment.url}/items/email/${productId}`);
  }
}
