import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { User } from '../../models/dto-models';

@Component({
  selector: 'app-user-grid-root',
  templateUrl: './user-grid.component.html',
  styleUrls: ['./user-grid.component.scss']
})
export class UserGridComponent
{
  public userList: User[];

  public addData(users: User[])
  {
    this.userList = users;
  }
}
