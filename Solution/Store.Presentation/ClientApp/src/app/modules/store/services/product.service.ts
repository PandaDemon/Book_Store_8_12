import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Injectable()

export class ProductService {

  readonly BaseURi = "http://localhost:44350/";

  constructor(private http: HttpClient) { }

  getAllPrintingEditions() {
	  var editions = 'api/PrintingStore/GetPrintingEdition';
	  return this.http.get(editions);
  }
}

