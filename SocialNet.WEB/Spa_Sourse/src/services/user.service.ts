import { User } from '../models/dto-models';
import { Observable } from 'rxjs/Observable';
import { Injectable } from '@angular/core';
import { FriendStatus, UserRelationType } from '../models/dto-enums';
import { HttpService } from './http.service';

@Injectable()
export class UserService
{
  private httpService: HttpService;

  public constructor(httpService: HttpService)
  {
    this.httpService = httpService;
  }

  public list(): Observable<User[]>
  {
    return this.httpService.httpGet<User[]>('api/user/list');
  }

  public getUser(userId: number): Observable<User>
  {
    return this.httpService.httpGet<User>(`api/user/getUser/${userId}`);
  }
/************************************************************************/
  public getFriends(type: UserRelationType): Observable<User[]>
  {
    return this.httpService.httpGet<User[]>(`api/user/getFriends/${type}`);
  }

  public search(searchWord: string): Observable<User[]>
  {
    return this.httpService.httpGet<User[]>(`api/user/search/${searchWord}`);
  }

  public changeRelation(friendId: number, status: FriendStatus): Observable<User>
  {
    return this.httpService.httpGet<User>(`api/user/changeRelation/${friendId}/${status}`);
  }
}
