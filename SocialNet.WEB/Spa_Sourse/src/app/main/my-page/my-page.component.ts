import { Component, OnInit } from '@angular/core';
import { UserService } from '../../../services/user.service';
import { User } from '../../../models/dto-models';
import { AuthService } from '../../../services/auth.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs/Subscription';

@Component({
  selector: 'app-my-page-root',
  templateUrl: './my-page.component.html',
  styleUrls: ['./my-page.component.scss']
})
export class MyPageComponent implements OnInit
{
  private authService: AuthService;
  private userService: UserService;

  public user: User;
  public userId: number;

  public constructor(userService: UserService, authService: AuthService, private activateRoute: ActivatedRoute, private router: Router)
  {
    this.userService = userService;
    this.authService = authService;
  }

  public ngOnInit(): void
  {
    this.activateRoute.params.subscribe(params =>
    {
      this.userId = params['id'];
    });

    const userId = this.authService.authentication.id;

    if (!this.userId)
    {
      this.userId = userId;
      this.router.navigate([`id/${userId}`]);
    }

    this.userService.getUser(this.userId)
      .subscribe(result =>
      {
        console.log('result', result);
        this.user = result;
      });
  }
}
