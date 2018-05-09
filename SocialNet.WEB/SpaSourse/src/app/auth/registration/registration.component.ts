import { Component } from '@angular/core';
import { User } from '../../../models/dto-models';
import { LoginService } from '../../../services/login.service';
import { Router } from '@angular/router';
import { isNullOrUndefined } from 'util';

@Component({
    selector: 'app-registration-root',
    templateUrl: './registration.component.html',
    styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent
{
    public user = new User();
    public password2: string;
    private loginService: LoginService;
    private router: Router;

    public constructor(loginService: LoginService, router: Router)
    {
        this.loginService = loginService;
        this.router = router;
    }

    public onRegistration(): void
    {
        if (isNullOrUndefined(this.user.firstName) || isNullOrUndefined(this.user.lastName)
            || isNullOrUndefined(this.user.city) || isNullOrUndefined(this.user.email) || isNullOrUndefined(this.user.password))
        {
            alert('Заполните все поля');
        }
        else
        {
            if (this.user.firstName.length < 2 || this.user.lastName.length < 2 || this.user.city.length < 2
                || this.user.email.length < 3 || this.user.password.length < 3)
            {
                alert('Введите корректные значения');
            }
            else if (isNullOrUndefined(this.user.dateOfBirth))
            {
                alert('Выберите дату');
            }
            else
            {
                if (this.user.password !== this.password2)
                {
                    alert('Пароли не совпадают');
                }
                else
                {
                    console.log(this.user);

                    this.loginService.registration(this.user)
                        .subscribe((result: boolean) =>
                        {
                            if (!result)
                            {
                                alert('Некорректные данные');
                            }
                            else
                            {
                                this.router.navigate(['login']);
                            }
                        });
                }
            }
        }
    }
}
