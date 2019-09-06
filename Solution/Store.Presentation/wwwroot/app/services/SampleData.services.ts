import { Injectable } from '@angular/core';
import { Http, Response, Headers } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { TestData } from '../models/TestData';

@Injectable()
export class SampleDataService {
    private url: string = 'api/sampleData';

    constructor(private http: Http) { }

    getSampleData(): Observable<TestData> {
        return this.http.get(this.url)
            .map((resp: Response) => resp.json())
            .catch(this.handleError);
    }

    addSampleData(testData: TestData): Observable<TestData> {
        let headers = new Headers(
            {
                'Content-Type': 'application/json'
            });

        return this.http
            .post(this.url, JSON.stringify(testData), { headers: headers })
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