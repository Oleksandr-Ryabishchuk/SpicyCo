import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {

  constructor(private http: HttpClient) { }
  product: any;
  // tslint:disable-next-line: typedef
  ngOnInit() {
    this.getProducts();
  }
  // tslint:disable-next-line: typedef
  getProducts() {
    this.http.get('http://localhost:5000/api/products').subscribe(resp => {
      this.product = resp;
    },
    error => {
      console.log(error);
    });
  }

}
