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

  public login(name: string, pass: string): Observable<boolean>
  {
    this.loginModel.name = name;
    this.loginModel.pass = pass;

    return this.http.post<boolean>('api/user/login', this.loginModel);
  }
}
