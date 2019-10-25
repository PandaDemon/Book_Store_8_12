import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormBuilder, Validators } from '@angular/forms';
import { MustMatch } from './must-match.validator';

@Injectable()
export class AccountService {
  readonly BaseURi = "http://localhost:44350";

  constructor(public formBuilder: FormBuilder, private http: HttpClient) { }

  registerForm = this.formBuilder.group({
    firstName: ['', Validators.required],
    lastName: ['', Validators.required],
    userName: ['', Validators.required],
    email: ['', [Validators.required, Validators.email]],
    password: ['', [Validators.required, Validators.pattern('(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&].{5,}')]],
    confirmPassword: ['', Validators.required]
  },
    {
      validator: MustMatch('password', 'confirmPassword')
    });

  signInForm = this.formBuilder.group({
    email: ['', [Validators.required, Validators.email]],
    password: ['', [Validators.required, Validators.minLength(6)]]
  });

  singUp() {
    console.log('submiting...');

    var body = {
      firstName: this.registerForm.value.firstName,
      lastName: this.registerForm.value.lastName,
      userName: this.registerForm.value.userName,
      email: this.registerForm.value.email,
      password: this.registerForm.value.password,
    };

    return this.http.post('/api/Account/SignUp', body);
  }

  signIn() {

    var formData = {
      email: this.signInForm.value.email,
      password: this.signInForm.value.password
    };

    return this.http.post('/api/Account/SignIn', formData);
  }
}
