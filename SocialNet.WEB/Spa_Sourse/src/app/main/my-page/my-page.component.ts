import { Component, OnInit } from '@angular/core';
import { UserService } from '../../../services/user.service';
import { User } from '../../../models/dto-models';

@Component({
  selector: 'app-my-page-root',
  templateUrl: './my-page.component.html',
  styleUrls: ['./my-page.component.scss']
})
export class MyPageComponent implements OnInit
{
  public user: User[];
  private userService: UserService;

  public constructor(userService: UserService)
  {
    this.userService = userService;
  }

  public ngOnInit(): void
  {
    this.userService.list()
      .subscribe(result =>
      {
        console.log('result', result);
        this.user = result;
      });

    console.log(this.user);
  }
}
