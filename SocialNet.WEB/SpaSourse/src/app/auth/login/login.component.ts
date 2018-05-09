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
    private router: Router;

    public constructor(loginService: LoginService, authService: AuthService, router: Router)
    {
        this.loginService = loginService;
        this.authService = authService;
        this.router = router;
    }

    public loginIn(): void
    {
        this.loginService.login(this.email, this.password)
            .subscribe((result: number) =>
            {
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
