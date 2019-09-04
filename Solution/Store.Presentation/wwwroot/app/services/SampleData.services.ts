import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { TestData } from '../models/TestData';

@Injectable()
export class SampleDataService {
    private url: string = 'api/';

    constructor(private http: Http) { }

    getSampleData(): Observable<TestData> {
        return this.http.get(this.url + 'sampleData')
            .map((resp: Response) => resp.json())
            .catch(this.handleError);
    }

    private handleError(error: Response | any) {
        let errMsg: string;

        if (error instanceof Response) {
            const body = error.json() || '';
            const err = body.error || JSON.stringify(body);
            errMsg = `${error.status} - ${error.statusText || ''} ${err}`;
        } else {
            errMsg = error.message ? error.message : error.toString();
        }

        console.error(errMsg);

        return Observable.throw(errMsg);
    }
}