import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { ITeam } from './team';

@Injectable()
export class TeamsService {
  private _teamsUrl = this._apiUrl + 'BaseGame/GetTeams';

  constructor(private _http: HttpClient, @Inject('API_URL') private _apiUrl: string) { }

  getTeams(): Observable<ITeam[]> {
    return this._http.get<ITeam[]>(this._teamsUrl);
  }
}
