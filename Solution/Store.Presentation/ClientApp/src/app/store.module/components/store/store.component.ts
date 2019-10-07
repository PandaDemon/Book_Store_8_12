
import { Component, OnInit } from '@angular/core';

import { Product } from '../../entity/product.entity';
import { ProductService } from '../../services/product.service';

@Component({
  templateUrl: './store.component.html'
})

export class StoreComponent implements OnInit {

  private products: Product[];

  constructor(
    private productService: ProductService
  ) { }

  ngOnInit() {
    this.products = this.productService.findAll();
  }
}


