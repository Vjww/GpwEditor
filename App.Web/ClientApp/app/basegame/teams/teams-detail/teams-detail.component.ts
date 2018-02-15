import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
    selector: 'basegame-teams-detail', // TODO: line can be removed as is a nested component???
    templateUrl: './teams-detail.component.html',
    styleUrls: ['./teams-detail.component.css']
})
export class TeamsDetailComponent implements OnInit, OnDestroy {
    private _id: number;
    private _sub: any;

    constructor(private _route: ActivatedRoute) { }

    //ngOnInit(): void {
    //    const id = +this._route.snapshot.paramMap.get('id');
    //    console.log(+this._id);
    //}

    ngOnInit() {
        this._sub = this._route.params.subscribe(params => {
            this._id = +params['id'];
        });
    }

    ngOnDestroy() {
        this._sub.unsubscribe();
    }
}