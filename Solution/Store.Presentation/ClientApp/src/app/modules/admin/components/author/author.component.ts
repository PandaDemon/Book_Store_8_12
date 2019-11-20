
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
		
  }

}


