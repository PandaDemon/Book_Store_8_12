
import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, Validators } from '@angular/forms';
import { AdminServise } from '../../services/admin.service';
import { ModalComponent } from './modal/modal.component'

@Component({
	selector: 'app-edition',
	templateUrl: './printingEdition.component.html',
	template: 'app-createmodal',
  styleUrls: ['../../../admin/admin.component.scss']
})

export class PrintingEditionComponent implements OnInit {

	private page: number = 0;
	private printEditions: Array<any>;
	private pages: Array<number>;

	printingEditionForms: FormArray = this.formBuilder.array([]);
	printingEditions;

	constructor(
		private formBuilder: FormBuilder,
		private adminServise: AdminServise
	) { }

	ngOnInit() {
		this.getAllPrintingEditionForm();
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
	getAllPrintingEditionForm() {
		this.adminServise.getPrintingEditions(this.page).subscribe(
			res => {
				this.printingEditions = res;
				this.pages = Array(res['totalPages']);
			},
			err => {
				console.log(err);
			}
		)
		this.addPrintingEditionForm();
	}

	updatePrintingEditionForm() { }

	deletePrintingEditionForm() { }

}


