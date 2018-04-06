import { User } from '../models/dto-models';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { Injectable } from '@angular/core';
import { FriendStatus, UserRelationType } from '../models/dto-enums';

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

  public getUser(myId: number, userId: number): Observable<User>
  {
    return this.http.get<User>(`api/user/getUser/${myId}/${userId}`);
  }
/************************************************************************/
  public getFriends(id: number, type: UserRelationType): Observable<User[]>
  {
    return this.http.get<User[]>(`api/user/getFriends/${id}/${type}`);
  }

  public search(searchWord: string): Observable<User[]>
  {
    return this.http.get<User[]>(`api/user/search/${searchWord}`);
  }

  public changeRelation(friendId: number, myId: number, status: FriendStatus): Observable<User>
  {
    return this.http.get<User>(`api/user/changeRelation/${friendId}/${myId}/${status}`);
  }
}
