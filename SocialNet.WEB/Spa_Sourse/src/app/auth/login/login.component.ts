import { Component } from '@angular/core';
import { LoginService } from '../../../services/login.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login-root',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent
{
  public name: string;
  public pass: string;
  private loginService: LoginService;
  private isAutentification: boolean;

  public constructor(loginService: LoginService, private router: Router)
  {
    this.loginService = loginService;
  }

  public login(): void
  {
    console.log(this.name, this.pass);

    this.loginService.login(this.name, this.pass)
      .subscribe((result: boolean) =>
      {
        console.log('result', result);
        this.isAutentification = result;
        if (this.isAutentification)
        {
          this.router.navigate(['/home']);
        }
      });
  }
}
