import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Title } from '@angular/platform-browser';
//import { UserService } from './services/user.service';

import { MustMatch } from './must-match.validator';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
})
export class RegistrationComponent implements OnInit{

  formModel = {
    UserName: '',
    Password: ''
  }

  registerForm: FormGroup;
  submitted = false;

  constructor(/*public service: UserService,*/ private formBuilder: FormBuilder, private titleService: Title) { }

  angularClientSideData = 'Angular';

  public setTitle(newTitle: string) {
    this.titleService.setTitle(newTitle);
  }

  ngOnInit() {
      this.registerForm = this.formBuilder.group({
          firstName: ['', Validators.required],
          lastName: ['', Validators.required],
          email: ['', [Validators.required, Validators.email]],
          password: ['', [Validators.required, Validators.minLength(6)]],
          confirmPassword: ['', Validators.required]
      },
      {
        validator: MustMatch('password', 'confirmPassword')
      });
  }

  get f() { return this.registerForm.controls; }

  onSubmit() {
    this.submitted = true;

    if (this.registerForm.invalid) {
      return;
    }

    alert('SUCCESS!! :-)\n\n' + JSON.stringify(this.registerForm.value))

    //this.service.register().subscribe(
    //    (res: any) => {
    //        console.log(res.succeeded);
    //        if (res.succeeded) {
    //            console.log(res.succeeded);
    //            this.toastr.success('New user created', 'Registration successful');
    //            this.router.navigateByUrl('/user/confirm');

    //        } else {
    //            res.errors.forEach(element => {
    //                console.log(element);
    //                this.toastr.error(element.code, 'registration failed')


    //            });
    //        }
    //    },
    //    err => {
    //        console.log(err);
    //    }
    //);
  }
}
