
import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, Validators } from '@angular/forms';

@Component({
	selector: 'admin-edition',
  templateUrl: './printingEdition.component.html',
  styleUrls: ['./printingEdition.component.scss']
})

export class PrintingEditionComponent /*implements OnInit */{

  //printingEditionForms : FormArray = this.formBuilder.array([]);

  constructor(/*private formBuilder: FormBuilder*/) { }

  //ngOnInit() {
  //  this.addPrintingEditionForm();
  //};

  //addPrintingEditionForm() {
  //  this.printingEditionForms.push(this.formBuilder.group({
  //    Name: ['', Validators.required],
  //    Price: ['', Validators.required],
  //    Desc: ['', Validators.required],
  //    CategoryId: [0, Validators.required],
  //    AvatarUrl: ['', Validators.required],
  //    CurrencyId: [0, Validators.required],
  //    Quantity: ['', Validators.required]
  //  }));
  //}
}


