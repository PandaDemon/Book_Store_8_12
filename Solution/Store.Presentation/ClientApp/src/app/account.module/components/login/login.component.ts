import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
})
export class LoginComponent {
  title: "Login";

  formModel = {
    UserName: '',
    Password: ''
  }

  public constructor(private titleService: Title) { }

  angularClientSideData = 'Angular';

  public setTitle(newTitle: string) {
    this.titleService.setTitle(newTitle);
  }

  ngOnInit() {
  }
}
