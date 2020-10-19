import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ProductServiceService {



  constructor(private http: HttpClient) { }

  // Get all products
  getProducts() {
   return this.http.get(`${environment.url}/product`);
  }

  // Get product by id
  getProductById(id) {
    return this.http.get(`${environment.url}/product/${id}`);
  }

  // Get product by name
  getProductByName(name) {
    return this.http.get(`${environment.url}/product/name/${name}`);
  }

  // Save product in database
  postProduct(productName, productDescription, currentPrice, category) {
    const product = {
      ProductName: productName,
      ProductDescription: productDescription,
      CurrentPrice: currentPrice,
      Category: category
    };
    return this.http.post(`${environment.url}/product`, product);
  }

  // Edit product details
  editProduct(productId, productName, productDescription, currentPrice, category) {
    const product = {
      ProductName: productName,
      ProductDescription: productDescription,
      CurrentPrice: currentPrice,
      Category: category
    };
    return this.http.put(`${environment.url}/product/${productId}`, product);
  }

  // Delete product details
  deleteProdcut(productId) {
    return this.http.delete(`${environment.url}/product/${productId}`);
  }
}
