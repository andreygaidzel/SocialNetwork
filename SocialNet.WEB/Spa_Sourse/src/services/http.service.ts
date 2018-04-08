import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AuthService } from './auth.service';

@Injectable()
export class HttpService
{
  private authService: AuthService;
  private http: HttpClient

  public constructor(http: HttpClient, authService: AuthService)
  {
    this.authService = authService;
    this.http = http;
  }

  public httpGet<T>(url: string)
  {
    const myId = this.authService.authentication.id;
    const headers = new HttpHeaders({'myId': `${myId}`});
    return this.http.get<T>(url, {headers: headers});
  }
}
