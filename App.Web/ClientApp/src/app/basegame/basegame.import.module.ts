import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { ImportComponent } from './import/import/import.component';
import { ImportService } from './import/import.service';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    RouterModule.forChild([
      { path: 'basegame/import', component: ImportComponent }
    ])
  ],
  declarations: [
    ImportComponent
  ],
  providers: [ImportService]
})
export class ImportModule { }
