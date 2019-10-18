import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormBuilder, Validators, FormGroup } from '@angular/forms';
import { MustMatch } from './must-match.validator';

@Injectable()
export class AccountService {
  formformBuilder: FormBuilder;
  readonly BaseURi = "http://localhost:44350/";

  constructor(private formBuilder: FormBuilder, private http: HttpClient) { }

  registerForm = this.formBuilder.group({
    firstName: ['', Validators.required],
    lastName: ['', Validators.required],
    userName: ['', Validators.required],
    email: ['', [Validators.required, Validators.email]],
    password: ['', [Validators.required, Validators.minLength(6)]],
    confirmPassword: ['', Validators.required]
    },
  {
    validator: MustMatch('password', 'confirmPassword')
  });

  singUp() {
    var body = {
      firstName: this.registerForm.value.firstName,
      lastName: this.registerForm.value.lastName,
      userName: this.registerForm.value.userName,
      email: this.registerForm.value.email,
      password: this.registerForm.value.password,
    };

    return this.http.post(this.BaseURi + '/api/Account/SignUp', body);
  }
}
