import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms'; // TODO: can be removed, as used in child modules
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { TeamsModule } from './basegame/basegame.teams.module';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule, // TODO: can be removed, as to be used in child modules
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent }, // TODO: change to default component
            { path: 'counter', component: CounterComponent }, // TODO: remove
            { path: 'fetch-data', component: FetchDataComponent }, // TODO: remove
            { path: '**', redirectTo: 'home' }
        ]),
        TeamsModule//,
        //AppRoutingModule // Retain as final route, as Angular registers routes based on the order of modules specified here
    ]
})
export class AppModuleShared {
}