import { Component, OnInit } from '@angular/core';
import { ProductServiceService } from '../Services/product-service.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})
export class ProductsComponent implements OnInit {

  constructor(private productService: ProductServiceService) { }

  products: any = [];

  ngOnInit(): void {
    this.getProducts();
  }

  getProducts() {
    this.productService.getProducts().subscribe((data: []) => {
      this.products = data;
      console.log(this.products);
    });
  }
}
