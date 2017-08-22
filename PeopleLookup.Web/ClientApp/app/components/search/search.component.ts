import { Component, OnInit, Inject } from '@angular/core';
import { Router } from '@angular/router';

import { PeopleService } from "../services/people.service";
import { Person } from "../model/person";

@Component({
    selector: 'search',
    template: require('./search.component.html'),
    styleUrls: ['./search.component.css']
})
export class SearchComponent {
    private Name: string;
    private slow: boolean;
    public CurrentCount;
    private hideElement: boolean = false;
    private peopleService: PeopleService;
    public people: Person[];
    public searched: boolean = false;

    constructor( @Inject(PeopleService) peopleServiceFactory: any) {
        this.peopleService = peopleServiceFactory();
    }

    submit() {
        this.people = null;
        this.searched = true;
        if (this.Name) {
            this.searched = false;
            this.hideElement = true;
            var delay = 0;
            if (this.slow) { delay = 5000 };
            setTimeout(() => this.search(), delay);
        }
        
        
    }
    search() {
        this.peopleService.search(this.Name)
            .then(result => {
                if (result.State == 1) {
                    this.hideElement = false;
                    this.people = result.Data as Person[];
                }
                else {
                    alert(result.Msg);
                }
            })
    }

}