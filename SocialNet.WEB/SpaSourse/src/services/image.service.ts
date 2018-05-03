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

  public addAvatar(image: HTMLCanvasElement): Observable<Avatar>
  {
      const img = '8';

    return this.httpService.post<Avatar>(`api/image/addavatar/`, {avatar: image, icon: img});
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
