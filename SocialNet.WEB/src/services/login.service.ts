import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { Injectable } from '@angular/core';

@Injectable()
export class LoginService
{
  public constructor(private http: HttpClient)
  {
  }

  public login(email: string, password: string): Observable<number>
  {
    return this.http.post<number>('api/account/login', {email: email, password: password});
  }
}
