import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Product } from '../entity/product.entity';

@Injectable()
export class ProductService {

  readonly BaseURi = "http://localhost:44350";
  constructor(private http: HttpClient) {}

  //private products: Product[];

  //constructor() {
  //  this.products = [
  //    { id: '01', img: '../../assets/images/book.png', author: 'name 1', description:'asdasd', price: 100 },
  //    { id: '02', img: '../../assets/images/book.png', author: 'name 2', description: 'asdasd', price: 200 },
  //    { id: '03', img: '../../assets/images/book.png', author: 'name 3', description: 'asdasd', price: 300 },
  //    { id: '03', img: '../../assets/images/book.png', author: 'name 3', description: 'asdasd', price: 500 },
  //    { id: '03', img: '../../assets/images/book.png', author: 'name 3', description: 'asdasd', price: 900 }
  //  ];
  //}

  //findAll(): Product[] {
  //  return this.products;
  //}

  //find(id: string): Product {
  //  return this.products[this.getSelectedIndex(id)];
  //}

  //private getSelectedIndex(id: string) {
  //  for (var i = 0; i < this.products.length; i++) {
  //    if (this.products[i].id == id) {
  //      return i;
  //    }
  //  }
  //  return -1;
  //}

  getAllPrintingEditions() {
    return this.http.get(this.BaseURi + '/printStore/GetAllAuthorsInPrintingEditions');
  }

}

