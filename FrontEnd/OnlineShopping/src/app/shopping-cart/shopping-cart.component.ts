import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import { CookieService } from 'ngx-cookie-service';
import { ProductServiceService } from '../Services/product-service.service';
import { MatTableDataSource } from '@angular/material/table';
import { DataService } from '../Services/data.service';
import { Router } from '@angular/router';
import { CustomerServiceService } from '../Services/customer-service.service';
import { OrderItemServiceService } from '../Services/order-item.service';
import { OrderService } from '../Services/order.service';
import { NotificationService } from '../Services/notification-service.service';

@Component({
  selector: 'app-shopping-cart',
  templateUrl: './shopping-cart.component.html',
  styleUrls: ['./shopping-cart.component.scss']
})

export class ShoppingCartComponent implements OnInit {

  firstFormGroup: FormGroup;
  secondFormGroup: FormGroup;
  shippingForm: FormGroup;
  Ids: any = [];
  products: any = [];
  x: number;
  quantity = 1;
  total: number;
  priceArray: any = [];
  price: number;
  indexNo: any;
  count = 0;
  userEmail: any;
  dataSource: any;
  checkOutQuantity: any = [];
  displayedColumns: string[] = ['productName', 'currentPrice', 'quantity', 'totalPrice', 'action'];
  fName: any;
  lName: any;
  address: any;
  street: any;
  city: any;
  state: any;
  postalCode: any;
  customerDetails: any;
  fullAddress: any;
  currentDate: any;
  date: any;
  month: any;
  year: any;
  orderComplete = 'false';
  methodType = 'false';
  paymentMethod: any;
  cardNumber: number;
  expireDate: any;
  cvn: number;


  constructor(private cookieService: CookieService,
              private productService: ProductServiceService,
              private formBuilder: FormBuilder,
              private dataService: DataService,
              private router: Router,
              private customerService: CustomerServiceService,
              private itemService: OrderItemServiceService,
              private orderService: OrderService,
              private notification: NotificationService) {
                this.shippingForm = formBuilder.group({
                  fName: ['', Validators.required],
                  lName: ['', Validators.required],
                  address: ['', Validators.required],
                  street: ['', Validators.required],
                  city: ['', Validators.required],
                  state: ['', Validators.required],
                  postalCode: ['', Validators.required],
                  paymentMethod: ['', Validators.required],
                  cardNumber: ['', Validators.required],
                  expireDate: ['', Validators.required],
                  cvn: ['', Validators.required]
                });
              }


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
      //  console.log(data['currentPrice'] - (data['currentPrice'] * data['discount']) / 100);
      //  this.priceArray.push(data['currentPrice']);
        this.priceArray.push(data['currentPrice'] - (data['currentPrice'] * data['discount']) / 100);
        this.checkOutQuantity.push(1);
        this.dataSource = new MatTableDataSource(this.products);
        this.getTotalCost();
      });
    }
  }

  getTotalCost() {
   this.total = this.products.map(t => t.currentPrice - (t.currentPrice * t.discount) / 100).reduce((acc, value) => acc + value, 0);
  }

  getQuantity(e, price, i, discount) {
    this.quantity = e.target.value;
    this.price = (price - (price * discount) / 100 ) * e.target.value;

    console.log(this.price);

    if (this.price == 0) {
        this.price = price - (price * discount) / 100;

        // Remove Row from table
        this.dataSource.data.splice(i, 1);
        this.dataSource._updateChangeSubscription();

        // Remove value from priceArray
        this.priceArray.splice(i, 1);
        this.Ids.splice(i, 1);
        this.checkOutQuantity.splice(i, 1);
        this.cookieService.delete('cart');
        this.cookieService.set('cart', this.Ids);

        // Reduce Shopping cart product count
        this.count = Number(this.cookieService.get('count'));
        this.count = this.count - 1;
        this.cookieService.set('count', this.count.toString());
        this.dataService.callNavBar();


    }

    //  quantity reduced price calculation
    if ((this.price) < this.priceArray[i]) {
      if (e.target.value != -1) {
        this.priceArray[i] = ((this.price));
        this.total = (this.total) - (this.price);
        console.log(this.price);
      }
    }
    else { // quantity add price calculation and discounts
      this.priceArray[i] = ((price - ((price * discount) / 100)) * e.target.value);
      this.total = (this.total - (price - (price * discount) / 100)) + ((price - (price * discount) / 100) * e.target.value);
      console.log((price - ((price * discount) / 100)) * e.target.value);
    }
    this.indexNo = i;
    this.checkOutQuantity[i] = Number(this.quantity);
  }

  getCustomer() { // if user not logged in send back to login page
    this.userEmail = this.cookieService.get('Email');
    if (!this.userEmail) {
      this.router.navigate(['login']);
    }
    else { // if user logged in get user details
      this.customerService.getCustomer(this.userEmail).subscribe((data) => {
        console.log(data);
        this.shippingForm.get('fName').setValue(data['fName']);
        this.shippingForm.get('lName').setValue(data['lName']);
        this.shippingForm.get('address').setValue(data['address']);
        this.shippingForm.get('street').setValue(data['streetName']);
        this.shippingForm.get('city').setValue(data['city']);
        this.shippingForm.get('state').setValue(data['state']);
        this.shippingForm.get('postalCode').setValue(data['zipCode']);
      });
    }
  }

  clickCheckOut() {
    this.getCustomer();
  }

  // save order in database
  clickComplete() {

      this.fName = this.shippingForm.get('fName').value;
      this.lName =  this.shippingForm.get('lName').value;
      this.address = this.shippingForm.get('address').value;
      this.street = this.shippingForm.get('street').value;
      this.city = this.shippingForm.get('city').value;
      this.state = this.shippingForm.get('state').value;
      this.postalCode = this.shippingForm.get('postalCode').value;
  
      // get today's date
      this.currentDate = new Date();
      this.date = String(this.currentDate.getDate()).padStart(2, '0');
      this.month = String(this.currentDate.getMonth() + 1).padStart(2, '0'); //January is 0!
      this.year = this.currentDate.getFullYear();
  
      this.currentDate = (this.year + '-' + this.month + '-' + this.date).toString();

      // user's full address
      this.fullAddress = this.address + ', ' + this.street + ', ' + this.city + ', ' + this.state;
      
      // save order in database
      this.orderService.postOrder(this.currentDate, this.fullAddress, this.userEmail, this.total, this.paymentMethod).subscribe((data) => {
        // send order id to get order items
        this.postOrderItems(data['orderId']);
      });
    
  }

  // get order items in order
  postOrderItems(orderId: any) {
      console.log(orderId);
      for (this.x = 0; this.x < this.products.length; this.x++) {
        // save order items in database
       this.itemService.postOrderItem(this.products[this.x].productId, this.checkOutQuantity[this.x],
          this.products[this.x].currentPrice - ((this.products[this.x].currentPrice * this.products[this.x].discount) / 100 ),
           orderId).subscribe((data) => {
            this.orderComplete = 'true';
            // remove items in cart
            this.cookieService.delete('cart');
            // make cart count to 0
            this.cookieService.delete('count');

            // call navigation bar component
            this.dataService.callNavBar();
        });
    } // send order confirmation email to user
      this.itemService.sendEmail(orderId).subscribe((data2) => {});
  }

  // remove item from cart
  clickRemoveButton(e, price, i, discount) {
    
     this.total = this.total - (price - (price * discount) / 100 );
     // Remove Row from table
     this.dataSource.data.splice(i, 1);
     this.dataSource._updateChangeSubscription();

     // Remove value from priceArray
     this.priceArray.splice(i, 1);
     this.Ids.splice(i, 1);
     this.checkOutQuantity.splice(i, 1);
     this.cookieService.delete('cart');
     this.cookieService.set('cart', this.Ids);

     // Reduce Shopping cart product count
     this.count = Number(this.cookieService.get('count'));
     this.count = this.count - 1;
     this.cookieService.set('count', this.count.toString());

     // call navigation bar component
     this.dataService.callNavBar();
  }

  // get payment method
  setPaymentMathod(method) {
    this.paymentMethod = method;
    this.methodType = 'true';
  }
}
