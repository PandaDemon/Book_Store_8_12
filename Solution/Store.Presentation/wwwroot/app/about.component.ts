﻿import { Component, OnInit } from '@angular/core';
import { SampleDataService } from './services/SampleData.services';
import { RegistrationData } from './models/RegistrationData';

@Component
    ({
        selector: 'my-about',
        templateUrl: '/partial/aboutComponent'
    })

export class AboutComponent implements OnInit {
    registrationData: RegistrationData = null;
    errorMessage: string;

    constructor(private sampleDataService: SampleDataService) { }

    ngOnInit() {
        this.sampleDataService.getSampleData()
            .subscribe((data: RegistrationData) => this.registrationData = data,
                error => this.errorMessage = <any>error);
    }

    getRegistrationData() {
        this.sampleDataService.getSampleData()
            .subscribe((data: RegistrationData) => this.registrationData = data, error => this.errorMessage = <any>error);
    }

    addRegistrationData(event: Event): void {
        event.preventDefault();

        if (!this.registrationData)
            return;

        this.sampleDataService.addSampleData(this.registrationData)
            .subscribe((data: RegistrationData) => this.registrationData = data, error => this.errorMessage = <any>error);
    }
}