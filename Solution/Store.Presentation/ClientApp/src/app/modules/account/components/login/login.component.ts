import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import { AccountService } from '../../services/account.service';
import { ToastrService } from 'ngx-toastr';

@Component({
	selector: 'app-login',
	templateUrl: './login.component.html',
	styleUrls: ['./login.css']
})
export class LoginComponent implements OnInit {

	submitted = false

	public constructor(private accountService: AccountService, private router: Router, private toastr: ToastrService) { }

	ngOnInit() {
		this.submitted = true;
	}

	get f() { return this.accountService.signInForm.controls; }

	onSubmit() {
		if (this.accountService.signInForm.invalid) {
			return;
		}
		else {
			this.accountService.signIn().subscribe(
				(res: any) => {
					localStorage.setItem('token', res.token);
					this.toastr.success('success');
					//this.router.navigateByUrl('/about-us');
				},
				err => {
					if (err.status == 400) {
						this.toastr.error('Invorrect user name or password.', 'Authentication failed.');
					} else {
						console.log(err);
					}
				}
			);
		}
	}
}
