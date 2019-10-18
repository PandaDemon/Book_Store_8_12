import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Title } from '@angular/platform-browser';
import { AccountService } from '../../services/account.service';
//import { UserService } from './services/user.service';

//import { MustMatch } from './must-match.validator';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
})
export class RegistrationComponent implements OnInit {


  submitted = false

  constructor( private titleService: Title, private accountService: AccountService) { }

  angularClientSideData = 'Angular';

  public setTitle(newTitle: string) {
    this.titleService.setTitle(newTitle);
  }

  ngOnInit() {
    
    //  this.formBuilder.group({
    //  firstName: ['', Validators.required],
    //  lastName: ['', Validators.required],
    //  userName: ['', Validators.required],
    //  email: ['', [Validators.required, Validators.email]],
    //  password: ['', [Validators.required, Validators.minLength(6)]],
    //  confirmPassword: ['', Validators.required]
    //},
    //  {
    //    validator: MustMatch('password', 'confirmPassword')
    //  });
  }

  get f() { return this.accountService.registerForm.controls; }

  onSubmit() {
    console.log('ssssssssssssss')
    this.accountService.singUp();
    this.submitted = true;

    
    
    //if (this.accountService.registerForm.invalid) {
    //  return;
    //}
    ////this.accountService.singUp();
    //alert('SUCCESS!! :-)\n\n' + JSON.stringify(this.accountService.registerForm.value))
  }
}
