import { Component, OnInit } from '@angular/core';
import { UserService } from '../../../services/user.service';
import { User } from '../../../models/dto-models';
import { AuthService } from '../../../services/auth.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs/Subscription';
import { FriendStatus, UserRelationType } from '../../../models/dto-enums';

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

      if (!this.userId)
      {
        const myId = this.authService.authentication.id;
        this.userId = myId;
        this.router.navigate([`id/${myId}`]);
      }

      this.userService.getUser(this.userId)
        .subscribe(result =>
        {
          this.user = result;
          console.log(result);
        });

    });
  }
  /***********************************button events*******************************************/

  public inFriend(): void
  {
    this.sendRelation(FriendStatus.FollowerPendingInFriend);
  }

  public addFriend(): void
  {
    this.sendRelation(FriendStatus.Friend);
  }

  public deleteMyFollower(): void
  {
    this.sendRelation(null); /////////////////////////////////////////////////////////////
  }

  public deleteFriend(): void
  {
    this.sendRelation(FriendStatus.Follower);
  }

  private sendRelation(status: FriendStatus): void
  {
    this.userService.changeRelation(this.userId, status)
      .subscribe(result =>
      {
        this.user = result;
      });
  }
/***************************************show elements****************************************/

  public get onMessageShow(): boolean
  {
    const isNotBlocked = this.user.relationType !== UserRelationType.Blocked;
    const isNotI = this.user.relationType !== UserRelationType.I;

    return isNotBlocked && isNotI;
  }

  public get onFriendAddShow(): boolean
  {
    const isNone = this.user.relationType === UserRelationType.None;

    return isNone;
  }

  public get onMySettings(): boolean
  {
    return this.user.relationType === UserRelationType.I;
  }

  public get onInFriends(): boolean
  {
    return this.user.relationType === UserRelationType.InFollower;
  }

  public get onOutFriends(): boolean
  {
    return this.user.relationType === UserRelationType.OutFollower;
  }

  public get onIsFriend(): boolean
  {
    return this.user.relationType === UserRelationType.Friend;
  }

  public get onIsBlocked(): boolean
  {
    return this.user.relationType === UserRelationType.Blocked;
  }
}
