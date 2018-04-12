import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AuthService } from './auth.service';

@Injectable()
export class HttpService
{
  private authService: AuthService;
  private http: HttpClient;

  public constructor(http: HttpClient, authService: AuthService)
  {
    this.authService = authService;
    this.http = http;
  }

  public get<T>(url: string)
  {
    const myId = this.authService.authentication.id;
    const headers = new HttpHeaders({'myId': `${myId}`});
    return this.http.get<T>(url, {headers: headers});
  }

  public post<T>(url: string, param: any)
  {
    const myId = this.authService.authentication.id;
    const headers = new HttpHeaders({'myId': `${myId}`});
    return this.http.post<T>(url, param, {headers: headers});
  }
}
