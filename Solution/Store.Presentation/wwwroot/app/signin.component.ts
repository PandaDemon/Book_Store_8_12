import { Component } from '@angular/core';
import { Title } from '@angular/platform-browser';

@Component
    ({
        selector: 'my-signin',
        templateUrl: '/partial/signinComponent'
    })

export class SignInComponent {
    public constructor(private titleService: Title) { }

    angularClientSideData = 'Angular';

    public setTitle(newTitle: string) {
        this.titleService.setTitle(newTitle);
    }
}