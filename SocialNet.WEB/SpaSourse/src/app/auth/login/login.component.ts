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
  public email: string;
  public password: string;
  private loginService: LoginService;
  private authService: AuthService;

  public constructor(loginService: LoginService, authService: AuthService, private router: Router)
  {
    this.loginService = loginService;
    this.authService = authService;
  }

  public loginIn(): void
  {
   // console.log(this.email, this.password);

    this.loginService.login(this.email, this.password)
      .subscribe((result: number) =>
      {
      /* console.log('result', result);
        this.authService.remove();*/
      //  console.log('data', this.authService.authentication);

        if (result !== -1)
        {
          const user = new Authentication();
          user.id = result;
          user.email = this.email;
          this.authService.add(user);
          this.router.navigate(['']);
        }
        else
        {
          alert('Неверные email или Пароль!');
        }
      });
  }
}
