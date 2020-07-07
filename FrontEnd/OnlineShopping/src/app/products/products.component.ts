import { Component, OnInit, Input } from '@angular/core';
import { ProductServiceService } from '../Services/product-service.service';


@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})


export class ProductsComponent implements OnInit {

  constructor(private productService: ProductServiceService) { }


  products: any = [];
  productId: any;
  productName: any;
  productDescription: any;
  price: number;
  i: number;

  images: any = [
    {url: '../../assets/banana.jpg'},
    {url: '../../assets/orange.jpg'},
    {url: '../../assets/mango.jpg'},
    {url: '../../assets/chicken.png'},
    {url: '../../assets/pork.jpg'},
    {url: '../../assets/prons.jpg'},
    {url: '../../assets/tikiri_mari.jpg'},
    {url: '../../assets/lemon puff.jpg'},
    {url: '../../assets/coca cola.jpg'},
    {url: '../../assets/sprite.jpg'},
    {url: '../../assets/fanta.jpg'},
    {url: '../../assets/cabbage.jpg'},
    {url: '../../assets/carrots.jpg'}
  ];

  ngOnInit(): void {
    this.getProducts();
  }

  getProducts() {
    this.productService.getProducts().subscribe((data: string []) => {
      this.products = data;
      console.log(this.products);
      console.log(this.images[0]);
    });
  }
}
