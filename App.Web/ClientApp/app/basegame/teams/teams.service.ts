import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { ITeam } from './team';
import 'rxjs/add/observable/throw';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/do';

@Injectable()
export class TeamsService {
    private _teamUri = 'localhost:1234/api/teams';

    constructor(private _http: Http) { }

    getTeams(): Observable<ITeam[]> {
        //return [{ "id": 1 }, { "id": 2 }, { "id": 3 }];
        //return this._http.get<ITeam[]>(this._teamUri)
        return this._http.get(this._teamUri)
            .do(data => console.log('All: ' + JSON.stringify(data)));
            //.catch(this.handleError);
    }

    //private handleError(err: HttpErrorResponse) {
    //    console.log(err.message);
    //    return Observable.throw(err.message);
    //}
}