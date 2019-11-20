import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

import { AccountService } from '../../services/account.service';

@Component({
  selector: 'app-registration',
	templateUrl: './registration.component.html',
	styleUrls: ['./registration.css']
})
export class RegistrationComponent implements OnInit {

    submitted = false

  public constructor(public accountService: AccountService, private router: Router, private toastr: ToastrService) { }

    ngOnInit() {
      this.submitted = true;
    }

    get f() { return this.accountService.registerForm.controls; }

    onSubmit() {
        if (this.accountService.registerForm.invalid) {
            return;
        }
        else {
            this.accountService.singUp().subscribe(
                (res: any) => {
                    console.log(res.succeeded);
                    if (res.succeeded) {
                        console.log(res.succeeded);
                        this.toastr.success('New user created', 'Registration successful');
                        this.router.navigateByUrl('/user/confirm');
                    }
                    res.errors.forEach(element => {
                        console.log(element);
                        this.toastr.error(element.code, 'registration failed')
                    });
                },
                err => {
                    console.log(err);
                }
            );
        }
    }
}
