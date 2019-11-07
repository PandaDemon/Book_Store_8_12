
import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, Validators } from '@angular/forms';
import { AdminServise } from '../../services/admin.service';

@Component({
	selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss']
})

export class UsersComponent implements OnInit {

	printingEditionForms: FormArray = this.formBuilder.array([]);
	printingEditions;

	constructor(
		private formBuilder: FormBuilder,
		private adminServise: AdminServise
	) { }

	ngOnInit() {
		
  }

  
}


