  import { Component, OnInit } from '@angular/core';
  import { Product } from './models/product';
  import { ProductService } from './services/product.service';

  @Component({
    selector: 'app-root',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css'],
    standalone : true
  })
  export class AppComponent implements OnInit {
    title = 'AngularFrontEnd';
    products: Product[] = [];

    constructor(private productService: ProductService) {}

    ngOnInit(): void {
      this.products = this.productService.getProducts();
      console.log(this.products);
    }
  }
