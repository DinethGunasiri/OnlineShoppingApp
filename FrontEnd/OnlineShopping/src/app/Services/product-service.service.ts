import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ProductServiceService {

  private producturi = 'https://localhost:44371/api/product';

  constructor(private http: HttpClient) { }

  getProducts() {
   return this.http.get(`${this.producturi}/all`);
  }

  getProductById(id) {
    return this.http.get(`${this.producturi}/id/${id}`);
  }

  getProductByName(name) {
    return this.http.get(`${this.producturi}/name/${name}`);
  }

  postProduct(productName, productDescription, currentPrice, category) {
    const product = {
      ProductName: productName,
      ProductDescription: productDescription,
      CurrentPrice: currentPrice,
      Category: category
    };
    return this.http.post(`${this.producturi}/new`, product);
  }

  editProduct(productId, productName, productDescription, currentPrice, category) {
    const product = {
      ProductName: productName,
      ProductDescription: productDescription,
      CurrentPrice: currentPrice,
      Category: category
    };
    return this.http.put(`${this.producturi}/edit/${productId}`, product);
  }

  deleteProdcut(productId) {
    return this.http.delete(`${this.producturi}/delete/${productId}`);
  }
}