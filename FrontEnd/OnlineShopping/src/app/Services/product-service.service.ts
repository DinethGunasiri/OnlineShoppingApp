import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ProductServiceService {

 // private producturi = 'https://localhost:44371/api/product';
 private producturi = 'https://localhost:44355/api/product';
  constructor(private http: HttpClient) { }

  // Get all products
  getProducts() {
   return this.http.get(`${this.producturi}`);
  }

  // Get product by id
  getProductById(id) {
    return this.http.get(`${this.producturi}/${id}`);
  }

  // Get product by name
  getProductByName(name) {
    return this.http.get(`${this.producturi}/name/${name}`);
  }

  // Save product in database
  postProduct(productName, productDescription, currentPrice, category) {
    const product = {
      ProductName: productName,
      ProductDescription: productDescription,
      CurrentPrice: currentPrice,
      Category: category
    };
    return this.http.post(`${this.producturi}`, product);
  }

  // Edit product details
  editProduct(productId, productName, productDescription, currentPrice, category) {
    const product = {
      ProductName: productName,
      ProductDescription: productDescription,
      CurrentPrice: currentPrice,
      Category: category
    };
    return this.http.put(`${this.producturi}/${productId}`, product);
  }

  // Delete product details
  deleteProdcut(productId) {
    return this.http.delete(`${this.producturi}/${productId}`);
  }
}
