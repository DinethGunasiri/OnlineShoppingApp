import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import { CookieService } from 'ngx-cookie-service';
import { ProductServiceService } from '../Services/product-service.service';
import { MatTableDataSource } from '@angular/material/table';
import { DataService } from '../Services/data.service';

@Component({
  selector: 'app-shopping-cart',
  templateUrl: './shopping-cart.component.html',
  styleUrls: ['./shopping-cart.component.scss']
})

export class ShoppingCartComponent implements OnInit {

  firstFormGroup: FormGroup;
  secondFormGroup: FormGroup;
  Ids: any = [];
  products: any = [];
  x: number;
  quantity: number;
  total: number;
  priceArray: any = [];
  price: number;
  indexNo: any;
  count = 0;
  dataSource: any;
  displayedColumns: string[] = ['productName', 'currentPrice', 'quantity', 'totalPrice'];

  constructor(private cookieService: CookieService,
              private productService: ProductServiceService,
              private formBuilder: FormBuilder,
              private dataService: DataService) { }


  ngOnInit(): void {

    this.firstFormGroup = this.formBuilder.group({
      firstCtrl: ['', Validators.required]
    });
    this.secondFormGroup = this.formBuilder.group({
      secondCtrl: ['', Validators.required]
    });

    this.quantity = 1;

    this.getProduct();
  }

  getProduct() {
    this.Ids.push(this.cookieService.get('cart'));
    this.Ids = (this.Ids.toString().split(','));

    for ( this.x = 0; this.x < this.Ids.length; this.x ++) {
      this.productService.getProductById(this.Ids[this.x]).subscribe((data: any []) => {
        this.products.push(data);
        this.priceArray.push(data['currentPrice']);
        this.dataSource = new MatTableDataSource(this.products);
        this.getTotalCost();
      });
    }
  }

  getTotalCost() {
   this.total = this.products.map(t => t.currentPrice).reduce((acc, value) => acc + value, 0);
  // console.log(this.products.map((item) => item.currentPrice).length);
  // console.log(this.priceArray);
  }

  getQuantity(e, price, i) {
    this.quantity = e.target.value;
    this.price = price * e.target.value;

    if (this.price == 0) {
        this.price = price;

        // Remove Row from table
        this.dataSource.data.splice(i, 1);
        this.dataSource._updateChangeSubscription();

        // Remove value from priceArray
        this.priceArray.splice(i, 1);
        this.Ids.splice(i, 1);
        this.cookieService.delete('cart');
        this.cookieService.set('cart', this.Ids);

        // Reduce Shopping cart product count
        this.count = Number(this.cookieService.get('count'));
        this.count = this.count - 1;
        this.cookieService.set('count', this.count.toString());
        this.dataService.callNavBar();


    }

    if ((this.price) < this.priceArray[i]) {
      if (e.target.value != -1) {
        this.priceArray[i] = ((this.price));
        this.total = (this.total) - (this.price);
      }
    }
    else {
      this.priceArray[i] = ((price * e.target.value));
      this.total = (this.total - price) + (price * e.target.value);
    }
   
    this.indexNo = i;
  }
}
