import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { TeamsListComponent } from './teams/teams-list/teams-list.component';
import { TeamsDetailComponent } from './teams/teams-detail/teams-detail.component';
import { TeamsService } from './teams/teams.service';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations'; // TODO: Progress/Telerik
import { ButtonsModule } from '@progress/kendo-angular-buttons';                // TODO: Progress/Telerik
import { GridModule } from '@progress/kendo-angular-grid';                      // TODO: Progress/Telerik

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    RouterModule.forChild([
      { path: 'basegame/teams', component: TeamsListComponent },
      { path: 'basegame/teams/:id', component: TeamsDetailComponent }
    ]),

    GridModule,
    BrowserAnimationsModule, // TODO: Progress/Telerik
    ButtonsModule            // TODO: Progress/Telerik
  ],
  declarations: [
    TeamsListComponent,
    TeamsDetailComponent
  ],
  providers: [TeamsService]
})
export class TeamsModule { }
