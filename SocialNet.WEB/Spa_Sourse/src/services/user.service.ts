import { User } from '../models/dto-models';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { Injectable } from '@angular/core';

@Injectable()
export class UserService
{
  public constructor(private http: HttpClient)
  {
  }

  public list(): Observable<User[]>
  {
    return this.http.get<User[]>('api/user/list');
  }
}
