import { Injectable } from '@angular/core';
import { Product } from '../models/product';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor() { }

  public getProducts() : Product[]{
    let product = new Product();
    product.id = 1;
    product.name = "AngularTeszt";
    product.price = 13;

    return [product];
  }
}
