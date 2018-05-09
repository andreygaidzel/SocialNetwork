import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AuthService } from './auth.service';
import { isNullOrUndefined } from 'util';

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
        return this.http.get<T>(url, {headers: this.header});
    }

    public post<T>(url: string, param: any)
    {
        return this.http.post<T>(url, param, {headers: this.header});
    }

    public get header(): HttpHeaders
    {
        let myId: number;

        const authentication = this.authService.authentication;

        myId = !isNullOrUndefined(authentication) ? authentication.id : 0;

        return new HttpHeaders({'myId': `${myId}`});
    }
}
