import { User } from '../models/dto-models';
import { HttpClient, HttpParams } from '@angular/common/http';
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

  public getUser(id: number): Observable<User>
  {
    return this.http.get<User>(`api/user/getUser/${id}`);
  }

  public getFriends(id: number): Observable<User[]>
  {
    return this.http.post<User[]>('api/user/getFriends', id);
  }
}
