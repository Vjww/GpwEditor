import { Component, OnInit } from '@angular/core';
import { ImportService } from './../import.service';
import { IImport } from './../import';

@Component({
  selector: 'app-import',
  templateUrl: './import.component.html',
  styleUrls: ['./import.component.css']
})
export class ImportComponent implements OnInit {
  private _any: any[];
  private _errorMessage: string;

  constructor(private _service: ImportService) { }

  ngOnInit() {
    const data: IImport = { "filePath": "MyFilePath" };
    this._service.import(data)
      .subscribe();
  }
}
