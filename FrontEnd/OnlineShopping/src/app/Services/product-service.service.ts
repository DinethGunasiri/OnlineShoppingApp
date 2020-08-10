import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ProductServiceService {

 // private producturi = 'https://localhost:44371/api/product';
 private producturi = 'https://localhost:44355/api/product';
  constructor(private http: HttpClient) { }

  getProducts() {
   return this.http.get(`${this.producturi}`);
  }

  getProductById(id) {
    return this.http.get(`${this.producturi}/${id}`);
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
    return this.http.post(`${this.producturi}`, product);
  }

  editProduct(productId, productName, productDescription, currentPrice, category) {
    const product = {
      ProductName: productName,
      ProductDescription: productDescription,
      CurrentPrice: currentPrice,
      Category: category
    };
    return this.http.put(`${this.producturi}/${productId}`, product);
  }

  deleteProdcut(productId) {
    return this.http.delete(`${this.producturi}/${productId}`);
  }
}
