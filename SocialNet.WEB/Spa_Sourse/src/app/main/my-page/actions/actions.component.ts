import {Component, Input} from '@angular/core';
import { FriendStatus, UserRelation } from '../../../../models/dto-enums';
import { User } from '../../../../models/dto-models';
import { UserService } from '../../../../services/user.service';
import { AuthService } from '../../../../services/auth.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-actions-root',
  templateUrl: './actions.component.html',
  styleUrls: ['./actions.component.scss']
})
export class ActionsComponent
{
  private _user = new User();

  @Input()
  public set user(user: User)
  {
    this._user = user;
  }

  public get user(): User
  {
    return this._user;
  }

  private authService: AuthService;
  private userService: UserService;
  private activateRoute: ActivatedRoute;

  private router: Router;
  public isDropDownShow = false;
  public userId: number;
  public friendStatus = FriendStatus;

  public constructor(userService: UserService, authService: AuthService, activateRoute: ActivatedRoute, router: Router)
  {
    this.userService = userService;
    this.authService = authService;
    this.activateRoute = activateRoute;
    this.router = router;
  }

  private onSendRelation(friendStatus: FriendStatus): void
  {
    this.userService.changeRelation(this.user.id, friendStatus)
      .subscribe(user =>
      {
        this.user = user;
       // console.log('userCom', user);
      });
  }

  public onDropDownShow(): void
  {
    this.isDropDownShow = true;
  }

  public onCloseDropDown(): void
  {
    setTimeout(() => { this.isDropDownShow = false; }, 700);
  }

  public onCloseDropDownNow(): void
  {
    this.isDropDownShow = false;
  }

  public get isMessageShow(): boolean
  {
    const isInBlocked = this.user.relationType !== UserRelation.InBlocked;
    const isOutBlocked = this.user.relationType !== UserRelation.OutBlocked;
    const isNotI = this.user.relationType !== UserRelation.I;
    const isDoubleBlocked = this.user.relationType !== UserRelation.DoubleBlocked;

    return isInBlocked && isNotI && isOutBlocked && isDoubleBlocked;
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
    const isDoubleBlocked = this.user.relationType !== UserRelation.DoubleBlocked;

    return isNotFriend && isOutBlocked && isDoubleBlocked;
  }

  public get isUnBlockedShow(): boolean
  {
    return this.user.relationType === UserRelation.OutBlocked || this.user.relationType === UserRelation.DoubleBlocked;
  }

  public get isBlockedMy(): boolean
  {
    return this.user.relationType === UserRelation.InBlocked || this.user.relationType === UserRelation.DoubleBlocked;
  }

  public get isActions(): boolean
  {
    return this.user.relationType === UserRelation.OutBlocked || this.user.relationType === UserRelation.None;
  }
}
