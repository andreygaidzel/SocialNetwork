import { Component, OnInit } from '@angular/core';
import { UserService } from '../../../services/user.service';
import { User } from '../../../models/dto-models';
import { AuthService } from '../../../services/auth.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs/Subscription';
import { FriendStatus, UserRelation } from '../../../models/dto-enums';

@Component({
  selector: 'app-my-page-root',
  templateUrl: './my-page.component.html',
  styleUrls: ['./my-page.component.scss']
})
export class MyPageComponent implements OnInit
{
  private authService: AuthService;
  private userService: UserService;
  private activateRoute: ActivatedRoute;
  private router: Router;

  public user: User;
  public userId: number;
  public friendStatus = FriendStatus;

  public constructor(userService: UserService, authService: AuthService, activateRoute: ActivatedRoute, router: Router)
  {
    this.userService = userService;
    this.authService = authService;
    this.activateRoute = activateRoute;
    this.router = router;
  }

  public ngOnInit(): void
  {
    this.activateRoute.params.subscribe(params =>
    {
      this.userId = params['id'];

      if (!this.userId)
      {
        const myId = this.authService.authentication.id;
        this.userId = myId;
        this.router.navigate([`id/${myId}`]);
      }

      this.userService.getUser(this.userId)
        .subscribe(user =>
        {
          this.user = user;
          console.log(user);
        });
    });
  }

  private onSendRelation(friendStatus: FriendStatus): void
  {
    this.userService.changeRelation(this.userId, friendStatus)
      .subscribe(user =>
      {
        this.user = user;
      });
  }

  public get isMessageShow(): boolean
  {
    const isInBlocked = this.user.relationType !== UserRelation.InBlocked;
    const isOutBlocked = this.user.relationType !== UserRelation.OutBlocked;
    const isNotI = this.user.relationType !== UserRelation.I;

    return isInBlocked && isNotI && isOutBlocked;
  }

  public get isFriendAddShow(): boolean
  {
    return this.user.relationType === UserRelation.None;
  }

  public get isMySettings(): boolean
  {
    return this.user.relationType === UserRelation.I;
  }

  public get isInFriends(): boolean
  {
    return this.user.relationType === UserRelation.InFollower;
  }

  public get isOutFriends(): boolean
  {
    return this.user.relationType === UserRelation.OutFollower;
  }

  public get isFriend(): boolean
  {
    return this.user.relationType === UserRelation.Friend;
  }

  public get isBlockedShow(): boolean
  {
    const isNotFriend = this.user.relationType !== UserRelation.Friend;
    const isOutBlocked = this.user.relationType !== UserRelation.OutBlocked;

    return isNotFriend && isOutBlocked;
  }

  public get isUnBlockedShow(): boolean
  {
    return this.user.relationType === UserRelation.OutBlocked;
  }

  public get isBlockedMy(): boolean
  {
    return this.user.relationType === UserRelation.InBlocked;
  }
}
