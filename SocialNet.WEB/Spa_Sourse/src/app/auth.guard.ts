import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs/Rx';
import { Injectable } from '@angular/core';

@Injectable()
export class AuthGuard implements CanActivate
{
  constructor(private router: Router)
  {
  }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> | boolean
  {
    const isAutentificated = confirm('Вы залогинились?');
    if (!isAutentificated)
    {
      this.router.navigate(['/login']);
      return false;
    }
    else
    {
      return true;
    }
  }
}
