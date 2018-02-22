import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { IImport } from './import';

@Injectable()
export class ImportService {
  private _importUrl = this._apiUrl + 'BaseGame/Import';

  constructor(private _http: HttpClient, @Inject('API_URL') private _apiUrl: string) { }

  import(data: IImport): Observable<IImport> {
    return this._http.post<IImport>(this._importUrl, data);
  }
}
