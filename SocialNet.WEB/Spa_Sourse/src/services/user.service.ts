import { User } from '../models/dto-models';
import { Observable } from 'rxjs/Observable';
import { Injectable } from '@angular/core';
import { FriendStatus, UserRelation } from '../models/dto-enums';
import { HttpService } from './http.service';

@Injectable()
export class UserService
{
  private httpService: HttpService;

  public constructor(httpService: HttpService)
  {
    this.httpService = httpService;
  }

  public getUser(userId: number): Observable<User>
  {
    return this.httpService.httpGet<User>(`api/user/getUser/${userId}`);
  }

  public getFriends(userRelation: UserRelation): Observable<User[]>
  {
    return this.httpService.httpGet<User[]>(`api/user/getFriends/${userRelation}`);
  }

  public search(searchWord: string): Observable<User[]>
  {
    return this.httpService.httpGet<User[]>(`api/user/search/${searchWord}`);
  }

  public changeRelation(userId: number, friendStatus: FriendStatus): Observable<User>
  {
    return this.httpService.httpGet<User>(`api/user/changeRelation/${userId}/${friendStatus}`);
  }
}
