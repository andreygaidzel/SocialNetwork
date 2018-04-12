import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-header-root',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent
{
  private authService: AuthService;

  constructor(private router: Router, authService: AuthService)
  {
    this.authService = authService;
  }

  public logout(): void
  {
    this.router.navigate(['login']);
    this.authService.remove();
  }
}
