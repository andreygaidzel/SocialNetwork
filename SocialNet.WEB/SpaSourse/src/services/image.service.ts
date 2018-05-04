import {Injectable} from '@angular/core';
import {HttpService} from './http.service';
import {Observable} from 'rxjs/Observable';
import { Avatar } from '../models/dto-models';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class ImageService {
  private httpService: HttpService;

  public constructor(httpService: HttpService, private http: HttpClient) {
    this.httpService = httpService;
  }

  public addAvatar(avatar: HTMLCanvasElement, icon: HTMLCanvasElement): Observable<Avatar>
  {
    return this.httpService.post<Avatar>(`api/image/addavatar/`, {avatar: avatar, icon: icon});
  }

    public removeAvatar(): Observable<Avatar>
    {
        return this.httpService.get<Avatar>(`api/image/removeavatar/`);
    }

    public getAvatars(userId: number): Observable<Avatar[]>
    {
        return this.httpService.get<Avatar[]>(`api/image/getavatars/${userId}`);
    }
}
