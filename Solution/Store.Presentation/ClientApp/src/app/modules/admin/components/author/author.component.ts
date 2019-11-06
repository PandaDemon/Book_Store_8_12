
import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, Validators } from '@angular/forms';
import { AdminServise } from '../../services/admin.service';

@Component({
	selector: 'app-author',
  templateUrl: './author.component.html',
  styleUrls: ['../../../admin/admin.component.scss']
})

export class AuthorsComponent implements OnInit {

	printingEditionForms: FormArray = this.formBuilder.array([]);
	printingEditions;

	constructor(
		private formBuilder: FormBuilder,
		private adminServise: AdminServise
	) { }

	ngOnInit() {
		this.adminServise.getPrintingEditions().subscribe(
			res => {
				this.printingEditions = res
			},
			err => {
				console.log(err);
			}
		)
    this.addPrintingEditionForm();
  }

  addPrintingEditionForm() {
    this.printingEditionForms.push(this.formBuilder.group({
      Name: ['', Validators.required],
      Price: ['', Validators.required],
      Desc: ['', Validators.required],
      CategoryId: [0, Validators.required],
      AvatarUrl: ['', Validators.required],
      CurrencyId: [0, Validators.required],
      Quantity: ['', Validators.required]
    }));
	}
}


