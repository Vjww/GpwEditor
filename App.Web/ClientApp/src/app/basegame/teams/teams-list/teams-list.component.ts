import { Component, OnInit } from '@angular/core';
import { TeamsService } from './../teams.service';
import { ITeam } from './../team';

@Component({
    selector: 'app-teams-list', // TODO: line can be removed as is a nested component???
    templateUrl: './teams-list.component.html',
    styleUrls: ['./teams-list.component.css']
})
export class TeamsListComponent implements OnInit {
    private _teams: ITeam[];
    private _errorMessage: string;

    constructor(private _service: TeamsService) { }

    ngOnInit() {
        this._service.getTeams()
            .subscribe(data => this._teams = data,
            error => this._errorMessage = error);
    }
}
