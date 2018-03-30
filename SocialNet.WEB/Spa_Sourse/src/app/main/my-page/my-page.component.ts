import { Component, OnInit } from '@angular/core';
import { UserService } from '../../../services/user.service';
import { User } from '../../../models/dto-models';
import { AuthService } from '../../../services/auth.service';

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

  public constructor(userService: UserService, authService: AuthService)
  {
    this.userService = userService;
    this.authService = authService;
  }

  public ngOnInit(): void
  {
    // this.userService.list()
    //   .subscribe(result =>
    //   {
    //     console.log('result', result);
    //   });
    const userId = this.authService.authentication.id;

    this.userService.getUser(userId)
      .subscribe(result =>
      {
        console.log('result', result);
        this.user = result;
      });

  }
}
