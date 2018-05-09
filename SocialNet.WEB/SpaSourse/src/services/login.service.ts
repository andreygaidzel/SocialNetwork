import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { Injectable } from '@angular/core';
import { Avatar, User } from '../models/dto-models';
import { HttpService } from './http.service';

@Injectable()
export class LoginService
{
    private httpService: HttpService;

    public constructor(httpService: HttpService) {
        this.httpService = httpService;
    }

  public login(email: string, password: string): Observable<number>
  {
    return this.httpService.post<number>('api/account/login', {email: email, password: password});
  }

    public registration(user: User): Observable<boolean>
    {
        return this.httpService.post<boolean>(`api/account/registration/`, user);
    }
}
