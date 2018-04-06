import { Component, OnInit, ViewChild } from '@angular/core';
import { AuthService } from '../../../services/auth.service';
import { UserService } from '../../../services/user.service';
import { User } from '../../../models/dto-models';
import { UserGridComponent } from '../../../core/user-grid/user-grid.component';
import { UserRelationType } from '../../../models/dto-enums';

@Component({
  selector: 'app-friends-root',
  templateUrl: './friends.component.html',
  styleUrls: ['./friends.component.scss']
})
export class FriendsComponent implements OnInit
{
  @ViewChild(UserGridComponent) child: UserGridComponent;

  private authService: AuthService;
  private userService: UserService;

  public friends: User[];
  public friendType = UserRelationType;

  public constructor(userService: UserService, authService: AuthService)
  {
    this.userService = userService;
    this.authService = authService;
  }

  public ngOnInit(): void
  {
    this.getFriends(this.friendType.Friend);
  }

  public onFriends(type: UserRelationType): void
  {
    this.getFriends(type);
  }

  public getFriends(type: UserRelationType): void
  {
    const userId = this.authService.authentication.id;

    this.userService.getFriends(userId, type)
      .subscribe(result =>
      {
        console.log('result', result);
        this.friends = result;
        this.child.addData(this.friends);
      });
  }

}
