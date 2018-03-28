import { Component, OnInit } from '@angular/core';
import { UserService } from '../../../services/user.service';
import { User } from '../../../models/dto-models';

@Component({
  selector: 'app-home-root',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit
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
