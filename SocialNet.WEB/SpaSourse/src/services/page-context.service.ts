import { Injectable } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from './auth.service';

@Injectable()
export class PageContext
{
    public authService: AuthService;
    public activateRoute: ActivatedRoute;
    public router: Router;

    public constructor(authService: AuthService, activateRoute: ActivatedRoute, router: Router)
    {
        this.authService = authService;
        this.activateRoute = activateRoute;
        this.router = router;
    }
}
