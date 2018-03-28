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
  public login: string;
  public password: string;
  private loginService: LoginService;
  private userId: number;

  public constructor(loginService: LoginService, private router: Router)
  {
    this.loginService = loginService;
  }

  public loginIn(): void
  {
    console.log(this.login, this.password);

    this.loginService.login(this.login, this.password)
      .subscribe((result: number) =>
      {
        console.log('result', result);
        this.userId = result;

        if (this.userId !== -1)
        {
          localStorage.setItem('userId', this.userId.toString());
          localStorage.setItem('login', 'true');
          this.router.navigate(['/home']);
        }
      });
  }
}
