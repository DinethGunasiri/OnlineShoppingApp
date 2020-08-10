import { Component, OnInit } from '@angular/core';
import { OrderService } from '../Services/order.service';
import { CookieService } from 'ngx-cookie-service';
import { OrderItemServiceService } from '../Services/order-item.service';
import { ProductServiceService } from '../Services/product-service.service';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-order-history',
  templateUrl: './order-history.component.html',
  styleUrls: ['./order-history.component.scss']
})
export class OrderHistoryComponent implements OnInit {

  customerEmail: any;
  customerName: any;
  ordres: any = [];
  orderItems: any = [];
  orderIds: any = [];
  dataSourceItems: any = [];
  products: any = [];
  x: number;
  y: number;
  index = -1;
  dataSource: any = [];
  dataSource2: any = [];
  panelOpenState = false;
  
  displayedColumns : string[] = ['productname', 'quantity', 'price'];

  constructor(private orderService: OrderService,
              private cookieSrvice: CookieService,
              private itemService: OrderItemServiceService,
              private productService: ProductServiceService) {
    this.customerEmail = this.cookieSrvice.get('Email');
    this.customerName = this.cookieSrvice.get('fullName');
   }

  ngOnInit(): void {
    this.getOrders();
  }

  getOrders() {
    this.orderService.getOrders().subscribe((data: any[]) => {
     // console.log(data);
      for (this.x = 0; this.x < data.length; this.x++) {
        if (data[this.x]['customerId'] == this.customerEmail) {
          this.ordres.push(data[this.x]);
        }
      }
    });
  }

  getOrderItems(id) {
    this.itemService.getOrderItems().subscribe((data: []) => {  
      for (this.x = 0; this.x < data.length; this.x++) {
        if (data[this.x]['orderId'] == id) {
          this.index = this.index + 1;
         // this.orderItems.push(data[this.x]);
          this.getProducts(data[this.x]['productId'], data[this.x], this.index);
        }
      }
    });
  }

  getProducts(productId, orderItems, index) {
    this.products = [];
    this.dataSource = [];
    this.orderItems = [];
    this.productService.getProductById(productId).subscribe((data: []) => {
   // console.log(data['productName']);
    this.products.push(data['productName']);
    this.orderItems.push(orderItems);

    this.dataSource = new MatTableDataSource(this.orderItems);
    });
    
  }

}
