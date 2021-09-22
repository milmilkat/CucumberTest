import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UserInfo } from 'src/models/user-info.models';

@Injectable({
  providedIn: 'root',
})
export class UserInfoService {
  constructor(private http: HttpClient) { }

  endpoint: string = '/userInfo';

  getUserCashInWords(cash: number, fullName?: string): Observable<UserInfo> {
    let httpParams = new HttpParams();
    httpParams = httpParams.set('fullName', fullName);
    return this.http.get<UserInfo>(this.endpoint + '/' + cash, {params: httpParams});
  }
}
