import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class OrderItemServiceService {

  private productItemuri = 'http://localhost:44371/api/items';

  constructor(private http: HttpClient) { }

  getOrderItems() {
    return this.http.get(`${this.productItemuri}/all`);
  }

  getOrderItem(id) {
    return this.http.get(`${this.productItemuri}/id/${id}`);
  }

  postOrderItem(productId, quantity, purchasePrice) {
    const item = {
      ProductId: productId,
      Quantity: quantity,
      PurchasePrice: purchasePrice
    };
    return this.http.post(`${this.productItemuri}/new/`, item);
  }

  editOrderItem(itemId, productId, quantity, purchasePrice) {
    const item = {
      ProductId: productId,
      Quantity: quantity,
      PurchasePrice: purchasePrice
    };
    return this.http.put(`${this.productItemuri}/edit/${itemId}`, item);
  }

  deleteOrderItem(itemId) {
    return this.http.delete(`${this.productItemuri}/delete/${itemId}`);
  }
}
