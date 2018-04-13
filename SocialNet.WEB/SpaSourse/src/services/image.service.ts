import {Injectable} from '@angular/core';
import {HttpService} from './http.service';
import {Observable} from 'rxjs/Observable';
import { Avatar } from '../models/dto-models';

@Injectable()
export class ImageService {
  private httpService: HttpService;

  public constructor(httpService: HttpService) {
    this.httpService = httpService;
  }

  public addAvatar(file: FormData): Observable<Avatar>
  {
    return this.httpService.post<Avatar>(`api/image/addavatar/`, file);
  }
}
