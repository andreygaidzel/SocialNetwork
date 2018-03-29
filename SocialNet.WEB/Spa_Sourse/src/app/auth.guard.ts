import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs/Rx';
import { Injectable } from '@angular/core';
import { AuthService } from '../services/auth.service';

@Injectable()
export class AuthGuard implements CanActivate
{
  private authService: AuthService;

  constructor(private router: Router, authService: AuthService)
  {
    this.authService = authService;
  }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> | boolean
  {
    const isAuth = this.authService.isAuth();
    if (!isAuth)
    {
      this.router.navigate(['login']);
    }
    return isAuth;
  }
}
