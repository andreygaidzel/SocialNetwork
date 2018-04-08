import { Component } from '@angular/core';
import { AuthService } from '../../../services/auth.service';
import { UserService } from '../../../services/user.service';
import { User } from '../../../models/dto-models';
import { searchDelay } from '../../../common/searchDelay';
import { UserRelationType } from '../../../models/dto-enums';

@Component({
  selector: 'app-search-root',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.scss']
})
export class SearchComponent
{
  private authService: AuthService;
  private userService: UserService;

  public users: User[];

  public constructor(userService: UserService, authService: AuthService)
  {
    this.userService = userService;
    this.authService = authService;
  }

  public search: string;
  public isShow: boolean;

  public onInput(): void
  {
    searchDelay(() =>
    {
      this.sendSearch();
    }, 500);
  }

  public sendSearch(): void
  {
    if (this.search)
    {
      this.userService.search(this.search)
        .subscribe(result =>
        {
          this.users = result;
        });
    }
  }

  public onFocus(): void
  {
    this.isShow = true;

    this.userService.getFriends( UserRelationType.Friend)
      .subscribe(result =>
      {
        this.users = result;
      });
  }

  public onBlur(): void
  {
    this.isShow = false;
  }

  public onClear(): void
  {
    console.log('clear');
    this.isShow = false;
    this.search = '';
  }
}
