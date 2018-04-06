import { Component, OnInit } from '@angular/core';
import { UserService } from '../../../services/user.service';
import { User } from '../../../models/dto-models';
import { AuthService } from '../../../services/auth.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs/Subscription';
import { FriendStatus } from '../../../models/dto-enums';

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
      const myId = this.authService.authentication.id;

      if (!this.userId)
      {
        this.userId = myId;
        this.router.navigate([`id/${myId}`]);
      }

      this.userService.getUser(myId, this.userId)
        .subscribe(result =>
        {
          this.user = result;
          console.log(result);
        });
      /************************************************/
    });
  }

  public addFriend(): void
  {
    const myId = this.authService.authentication.id;
    this.userService.changeRelation(this.userId, myId, FriendStatus.Pending)
      .subscribe(result =>
      {
        this.user = result;
      });
  }
}
