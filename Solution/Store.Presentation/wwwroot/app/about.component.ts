import { Component, OnInit } from '@angular/core';
import { SampleDataService } from './services/SampleData.services';
import { TestData } from './models/TestData';

@Component
    ({
        selector: 'my-about',
        templateUrl: '/partial/aboutComponent'
    })

export class AboutComponent implements OnInit {
    testData: TestData = null;
    errorMessage: string;

    constructor(private sampleDataService: SampleDataService) { }

    ngOnInit() {
        this.sampleDataService.getSampleData()
            .subscribe((data: TestData) => this.testData = data,
                error => this.errorMessage = <any>error);
    }
}