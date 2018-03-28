import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { Injectable } from '@angular/core';
import { Login, User } from '../models/dto-models';

@Injectable()
export class LoginService
{
  public loginModel = new Login();
  public constructor(private http: HttpClient)
  {
  }

  public login(login: string, password: string): Observable<number>
  {
    this.loginModel.login = login;
    this.loginModel.password = password;

    return this.http.post<number>('api/account/login', this.loginModel);
  }
}
