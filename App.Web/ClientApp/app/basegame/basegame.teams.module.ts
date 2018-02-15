import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { TeamsListComponent } from './teams/teams-list/teams-list.component';
import { TeamsDetailComponent } from './teams/teams-detail/teams-detail.component';
import { TeamsService } from './teams/teams.service';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        RouterModule.forChild([
            { path: 'basegame/teams', component: TeamsListComponent },
            { path: 'basegame/teams/:id', component: TeamsDetailComponent }
        ])
    ],
    declarations: [
        TeamsListComponent,
        TeamsDetailComponent
    ],
    providers: [TeamsService]
})
export class TeamsModule { }