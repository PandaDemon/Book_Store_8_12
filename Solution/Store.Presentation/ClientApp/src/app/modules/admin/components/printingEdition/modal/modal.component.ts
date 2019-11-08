
import { Component } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { FormArray, FormBuilder, Validators } from '@angular/forms';

@Component({
	selector: 'app-createmodal',
  templateUrl: './modal.component.html',
	styleUrls: ['../../../../admin/modal.component.scss']
})

export class ModalComponent {
	printingEditionForms: FormArray = this.formBuilder.array([]);

	constructor(
		private modalService: NgbModal,
		private formBuilder: FormBuilder,
	) {
	}
	public open(content) {
		this.modalService.open(content);
	}

	ngOnInit() {
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


