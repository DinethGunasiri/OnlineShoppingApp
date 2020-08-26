import { Component, OnInit, Input } from '@angular/core';
import { ProductServiceService } from '../Services/product-service.service';
import { CookieService } from 'ngx-cookie-service';
import { DataService } from '../Services/data.service';


@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.scss']
})


export class ProductsComponent implements OnInit {

  constructor(private productService: ProductServiceService,
              private cookieService: CookieService,
              private dataSevice: DataService) { }


  products: any = [];
  productId: any;
  productName: any;
  productDescription: any;
  price: number;
  count = 0;
  cart: any = [];

 // Image urls
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

  // Get products
  getProducts() {
    this.productService.getProducts().subscribe((data: string []) => {
      this.products = data;
    });
  }

  // Add item to cart
  addToCart(id) {

    if (!this.cookieService.get('cart')) {
      this.cart.push(id);
    }
    else {
      this.cart = [];
      this.cart.push(this.cookieService.get('cart'));
      this.cookieService.delete('cart');
      this.cart.push(id);
    }
   
    this.cookieService.set('cart', this.cart);

    if (!this.cookieService.get('count')) {
      this.count = this.count + 1;
    }
    else {
      this.count = Number(this.cookieService.get('count')) ;
      this.count = this.count + 1;
    }

    // add count to cookie
    this.cookieService.set('count', this.count.toString());

    // call nav bar component
    this.dataSevice.callNavBar();
  }
}
