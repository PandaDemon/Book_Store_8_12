
import { Component, OnInit } from '@angular/core';

import { ProductService } from '../../services/product.service';

import { Options, LabelType } from 'ng5-slider';


@Component({
  templateUrl: './store.component.html',
  styleUrls: ['./store.component.scss']
})

export class StoreComponent implements OnInit {

  //private products: Product[];

  constructor(
    private productService: ProductService
  ) { }

  printingEditions;

  ngOnInit() {
    //this.products = this.productService.findAll();

    this.productService.getAllPrintingEditions().subscribe(
      res => {
        this.printingEditions = res;
      },
      err => {
        console.log(err);
      },
    )
  }

  value: number = 20;
  highValue: number = 850;
  options: Options = {
    floor: 0,
    ceil: 1000
  };
}


