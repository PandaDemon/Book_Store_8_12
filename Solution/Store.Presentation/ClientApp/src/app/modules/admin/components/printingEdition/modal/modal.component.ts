
import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, Validators } from '@angular/forms';
import { AdminServise } from '../../../services/admin.service';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
	selector: 'app-createmodal',
  templateUrl: './modal.component.html',
	styleUrls: ['../../../../admin/modal.component.scss']
})

export class ModalComponent {

	constructor(
		//private formBuilder: FormBuilder,
		//private adminServise: AdminServise,
		private modalService: NgbModal
	) {
	}
	open(content) {
		this.modalService.open(content);
	}
}


