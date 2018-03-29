import { Component } from '@angular/core';
import { LoginService } from '../../../services/login.service';
import { Router } from '@angular/router';
import { Authentication } from '../../../models/dto-models';
import { AuthService } from '../../../services/auth.service';

@Component({
  selector: 'app-login-root',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent
{
  public login: string;
  public password: string;
  private loginService: LoginService;
  private authService: AuthService;
  private userId: number;

  public constructor(loginService: LoginService, authService: AuthService, private router: Router)
  {
    this.loginService = loginService;
    this.authService = authService;
  }

  public loginIn(): void
  {
    console.log(this.login, this.password);

    this.loginService.login(this.login, this.password)
      .subscribe((result: number) =>
      {
        console.log('result', result);
        this.userId = result;

        const test = new Authentication();
        test.id = result;
        test.login = this.login;

        this.authService.add(test);

        console.log('data', this.authService.authentication);

        if (this.userId !== -1)
        {
          // localStorage.setItem('userId', this.userId.toString());
          // localStorage.setItem('login', 'true');
          this.router.navigate(['/my-page']);
        }
      });
  }
}
