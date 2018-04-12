import {Injectable} from '@angular/core';
import {HttpService} from './http.service';
import {Observable} from 'rxjs/Observable';

@Injectable()
export class ImageService {
  private httpService: HttpService;

  public constructor(httpService: HttpService) {
    this.httpService = httpService;
  }

  public addAvatar(file: FormData): Observable<string>
  {
    return this.httpService.post<string>(`api/image/addavatar/`, file);
  }
}
