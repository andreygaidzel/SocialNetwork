import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../../services/auth.service';
import { UserService } from '../../../services/user.service';
import { User } from '../../../models/dto-models';

@Component({
  selector: 'app-friends-root',
  templateUrl: './friends.component.html',
  styleUrls: ['./friends.component.scss']
})
export class FriendsComponent implements OnInit
{
  private authService: AuthService;
  private userService: UserService;

  public friends: User[];

  public constructor(userService: UserService, authService: AuthService)
  {
    this.userService = userService;
    this.authService = authService;
  }

  public ngOnInit(): void
  {

    const userId = this.authService.authentication.id;

    this.userService.getFriends(userId)
      .subscribe(result =>
      {
        console.log('result', result);
         this.friends = result;
      });
  }
}
