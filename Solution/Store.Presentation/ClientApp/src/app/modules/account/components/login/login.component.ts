import { Component, OnInit } from '@angular/core';
import { AccountService } from '../../services/account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
})
export class LoginComponent implements OnInit{

  submitted = false
  toastr: any;
  router: any;

  public constructor( public accountService: AccountService ) { }

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
