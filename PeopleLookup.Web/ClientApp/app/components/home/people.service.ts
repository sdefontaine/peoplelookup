import { Injectable } from "@angular/core";
import { Headers, Http } from "@angular/http";
import "rxjs/add/operator/toPromise";

import { RequestResult } from "../model/request.result";

@Injectable()
export class PeopleService {
    private searchUrl = "/api/Person/Search";


    constructor(private http: Http) {
    }


    public search(name: string): Promise<RequestResult> {
        return this.http.post(this.searchUrl, { Name: name }).toPromise()
            .then(response => {
                let result = response.json() as RequestResult;
                if (result.State == 1) {
                    let json = result.Data as any;
                }
                return result;
            })
            .catch(this.handleError);
    }


    private handleError(error: any): Promise<any> {
        console.error('An error occurred', error);
        return Promise.reject(error.message || error);
    }
    private getData(response: any): Promise<any> {
        return Promise.resolve(response._body);
    }
}