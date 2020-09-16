import { Component, OnInit } from '@angular/core';
import { ChartOptions, ChartType, ChartDataSets, Chart } from 'chart.js';
import { Label } from 'ng2-charts';
import { OrderService } from '../Services/order.service';
import { OrderItemServiceService } from '../Services/order-item.service';
import { ProductServiceService } from '../Services/product-service.service';

@Component({
  selector: 'app-chart',
  templateUrl: './chart.component.html',
  styleUrls: ['./chart.component.scss']
})
export class ChartComponent implements OnInit {

  orders: any = [];
  countArr: any = [];
  cat1Arr: any = [];
  cat2Arr: any = [];
  cat3Arr: any = [];
  cat4Arr: any = [];
  cat5Arr: any = [];
  cat6Arr: any = [];
  cat7Arr: any = [];

  cat1Count = 0;
  cat2Count = 0;
  cat3Count = 0;
  cat4Count = 0;
  cat5Count = 0;
  cat6Count = 0;
  cat7Count = 0;

  count = 0;
  x: number;
  date: any = [];
  items: any = [];
  category: any = [];
  
  barChartOptions: ChartOptions = {
    responsive: true,
  };
  barChartLabels: Label[];
  barChartType: ChartType;
  barChartLegend = true;
  barChartPlugins = [];
  barchart: any = [];

  barChartData: ChartDataSets[];

  constructor(private orderService: OrderService,
              private itemService: OrderItemServiceService,
              private productService: ProductServiceService) { }

  ngOnInit(): void {
     this.orderService.getOrders().subscribe((data = []) => {
      this.orders = data;

      for (this.x = 0; this.x < 12; this.x++) {
        this.cat1Arr[this.x] = 0;
        this.cat2Arr[this.x] = 0;
        this.cat3Arr[this.x] = 0;
        this.cat4Arr[this.x] = 0;
        this.cat5Arr[this.x] = 0;
        this.cat6Arr[this.x] = 0;
        this.cat7Arr[this.x] = 0;
      }

      for (this.x = 0; this.x < this.orders.length; this.x++) {
        this.getItems(this.orders[this.x].orderId, this.orders[this.x].orderDate);
      }
     });

     this.itemService.getOrderItems().subscribe((data) => {
       this.items = data;

     });
  }

  getItems(orderId, orderDate) {
    this.itemService.getOrderItems().subscribe((data) => {
      this.items = data;
      
      for (this.x = 0; this.x < this.items.length; this.x++) {
        if (this.items[this.x].orderId == orderId) {
          this.getCategory(orderId, this.items[this.x].productId, this.items[this.x], orderDate.substring(5, 7));
        }
      }
     });
  }

  getCategory(orderId, products, items, orderDate) {
  
  this.productService.getProductById(products).subscribe((data) => {

    console.log(orderId, orderDate, data['categoryId']);

    if (orderDate == '01') {
      if (data['categoryId'] == 1) {
        this.cat1Arr[0] += 1;
      }
      else if (data['categoryId'] == 2) {
        this.cat2Arr[0] += 1;
      }
      else if (data['categoryId'] == 3) {
        this.cat3Arr[0] += 1;
      }
      else if (data['categoryId'] == 4) {
        this.cat4Arr[0] += 1;
      }
      else if (data['categoryId'] == 5) {
        this.cat5Arr[0] += 1;
      }
      else if (data['categoryId'] == 6) {
        this.cat6Arr[0] += 1;
      }
    }

    if (orderDate == '02') {
      if (data['categoryId'] == 1) {
        this.cat1Arr[1] += 1;
      }
      else if (data['categoryId'] == 2) {
        this.cat2Arr[1] += 1;
      }
      else if (data['categoryId'] == 3) {
        this.cat3Arr[1] += 1;
      }
      else if (data['categoryId'] == 4) {
        this.cat4Arr[1] += 1;
      }
      else if (data['categoryId'] == 5) {
        this.cat5Arr[1] += 1;
      }
      else if (data['categoryId'] == 6) {
        this.cat6Arr[1] += 1;
      }
    }

    if (orderDate == '03') {
      if (data['categoryId'] == 1) {
        this.cat1Arr[2] += 1;
      }
      else if (data['categoryId'] == 2) {
        this.cat2Arr[2] += 1;
      }
      else if (data['categoryId'] == 3) {
        this.cat3Arr[2] += 1;
      }
      else if (data['categoryId'] == 4) {
        this.cat4Arr[2] += 1;
      }
      else if (data['categoryId'] == 5) {
        this.cat5Arr[2] += 1;
      }
      else if (data['categoryId'] == 6) {
        this.cat6Arr[2] += 1;
      }
    }

    if (orderDate == '04') {
      if (data['categoryId'] == 1) {
        this.cat1Arr[3] += 1;
      }
      else if (data['categoryId'] == 2) {
        this.cat2Arr[3] += 1;
      }
      else if (data['categoryId'] == 3) {
        this.cat3Arr[3] += 1;
      }
      else if (data['categoryId'] == 4) {
        this.cat4Arr[3] += 1;
      }
      else if (data['categoryId'] == 5) {
        this.cat5Arr[3] += 1;
      }
      else if (data['categoryId'] == 6) {
        this.cat6Arr[3] += 1;
      }
    }
    
    if (orderDate == '05') {
      if (data['categoryId'] == 1) {
        this.cat1Arr[4] += 1;
      }
      else if (data['categoryId'] == 2) {
        this.cat2Arr[4] += 1;
      }
      else if (data['categoryId'] == 3) {
        this.cat3Arr[4] += 1;
      }
      else if (data['categoryId'] == 4) {
        this.cat4Arr[4] += 1;
      }
      else if (data['categoryId'] == 5) {
        this.cat5Arr[4] += 1;
      }
      else if (data['categoryId'] == 6) {
        this.cat6Arr[4] += 1;
      }
    }

    if (orderDate == '06') {
      if (data['categoryId'] == 1) {
        this.cat1Arr[5] += 1;
      }
      else if (data['categoryId'] == 2) {
        this.cat2Arr[5] += 1;
      }
      else if (data['categoryId'] == 3) {
        this.cat3Arr[5] += 1;
      }
      else if (data['categoryId'] == 4) {
        this.cat4Arr[5] += 1;
      }
      else if (data['categoryId'] == 5) {
        this.cat5Arr[5] += 1;
      }
      else if (data['categoryId'] == 6) {
        this.cat6Arr[5] += 1;
      }
    }

    if (orderDate == '07') {
      if (data['categoryId'] == 1) {
        this.cat1Arr[6] += 1;
      }
      else if (data['categoryId'] == 2) {
        this.cat2Arr[6] += 1;
      }
      else if (data['categoryId'] == 3) {
        this.cat3Arr[6] += 1;
      }
      else if (data['categoryId'] == 4) {
        this.cat4Arr[6] += 1;
      }
      else if (data['categoryId'] == 5) {
        this.cat5Arr[6] += 1;
      }
      else if (data['categoryId'] == 6) {
        this.cat6Arr[6] += 1;
      }
    }

    if (orderDate == '08') {
      if (data['categoryId'] == 1) {
        this.cat1Arr[7] += 1;
      }
      else if (data['categoryId'] == 2) {
        this.cat2Arr[7] += 1;
      }
      else if (data['categoryId'] == 3) {
        this.cat3Arr[7] += 1;
      }
      else if (data['categoryId'] == 4) {
        this.cat4Arr[7] += 1;
      }
      else if (data['categoryId'] == 5) {
        this.cat5Arr[7] += 1;
      }
      else if (data['categoryId'] == 6) {
        this.cat6Arr[7] += 1;
      }
    }

    if (orderDate == '09') {
      if (data['categoryId'] == 1) {
        this.cat1Arr[8] += 1;
      }
      else if (data['categoryId'] == 2) {
        this.cat2Arr[8] += 1;
      }
      else if (data['categoryId'] == 3) {
        this.cat3Arr[8] += 1;
      }
      else if (data['categoryId'] == 4) {
        this.cat4Arr[8] += 1;
      }
      else if (data['categoryId'] == 5) {
        this.cat5Arr[8] += 1;
      }
      else if (data['categoryId'] == 6) {
        this.cat6Arr[8] += 1;
      }
    }

    if (orderDate == '10') {
      if (data['categoryId'] == 1) {
        this.cat1Arr[9] += 1;
      }
      else if (data['categoryId'] == 2) {
        this.cat2Arr[9] += 1;
      }
      else if (data['categoryId'] == 3) {
        this.cat3Arr[9] += 1;
      }
      else if (data['categoryId'] == 4) {
        this.cat4Arr[9] += 1;
      }
      else if (data['categoryId'] == 5) {
        this.cat5Arr[9] += 1;
      }
      else if (data['categoryId'] == 6) {
        this.cat6Arr[9] += 1;
      }
    }

    if (orderDate == '11') {
      if (data['categoryId'] == 1) {
        this.cat1Arr[10] += 1;
      }
      else if (data['categoryId'] == 2) {
        this.cat2Arr[10] += 1;
      }
      else if (data['categoryId'] == 3) {
        this.cat3Arr[10] += 1;
      }
      else if (data['categoryId'] == 4) {
        this.cat4Arr[10] += 1;
      }
      else if (data['categoryId'] == 5) {
        this.cat5Arr[10] += 1;
      }
      else if (data['categoryId'] == 6) {
        this.cat6Arr[10] += 1;
      }
    }

    if (orderDate == '12') {
      if (data['categoryId'] == 1) {
        this.cat1Arr[11] += 1;
      }
      else if (data['categoryId'] == 2) {
        this.cat2Arr[11] += 1;
      }
      else if (data['categoryId'] == 3) {
        this.cat3Arr[11] += 1;
      }
      else if (data['categoryId'] == 4) {
        this.cat4Arr[11] += 1;
      }
      else if (data['categoryId'] == 5) {
        this.cat5Arr[11] += 1;
      }
      else if (data['categoryId'] == 6) {
        this.cat6Arr[11] += 1;
      }
    }

    this.createChart(this.cat1Arr, this.cat2Arr, this.cat3Arr, this.cat4Arr, this.cat5Arr, this.cat6Arr, this.cat7Arr);

  });

  }

  createChart(cat1Arr, cat2Arr, cat3Arr, cat4Arr, cat5Arr, cat6Arr, cat7Arr) {
   
    this.barchart = new Chart('canvas1', {
      type: 'bar',
      data: {
        labels: ['January', 'Febrary', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'Octomber', 'November', 'December'],
        datasets: [
          {
            data: cat1Arr,
            borderColor: '#3cba9f',
            backgroundColor: [
              '#3cb371',
              '#0000FF',
              '#9966FF',
              '#4C4CFF',
              '#00FFFF',
              '#f990a7',
              '#aad2ed',
              '#FF00FF',
              'Blue',
              'Red',
              'Blue'
            ],
            fill: true,
            label: 'Grocery'
          },
          {
            data: cat2Arr,
            borderColor: 'Red',
            backgroundColor: 'blue',
            fill: true,
            label: 'Beverages'
          },
          {
            data: cat3Arr,
            borderColor: 'Red',
            backgroundColor: 'yellow',
            fill: true,
            label: 'Pharmacy'
          },
          {
            data: cat4Arr,
            borderColor: 'Red',
            backgroundColor: 'green',
            fill: true,
            label: 'Meat'
          },
          {
            data: cat5Arr,
            borderColor: 'Red',
            backgroundColor: 'red',
            fill: true,
            label: 'Fish'
          },
          {
            data: cat6Arr,
            borderColor: 'Red',
            backgroundColor: 'pink',
            fill: true,
            label: 'Fruits'
          },
          {
            data: cat7Arr,
            borderColor: 'Red',
            backgroundColor: 'black',
            fill: true,
            label: 'Vegitables'
          }
        ]
      },
      options: {
        legend: {
          display: false
        },
        scales: {
          xAxes: [{
            display: true
          }],
          yAxes: [{
            display: true,
            scaleLabel: {
              display: true,
              labelString: 'Product Count category vice'
            }
          }],
        }
      }
    });
  }
}
