import { Component, OnInit, ViewChild } from '@angular/core';
import { UserService } from '../../../services/user.service';
import { User } from '../../../models/dto-models';
import { UserGridComponent } from '../../../core/user-grid/user-grid.component';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-search-page-root',
  templateUrl: './search-page.component.html',
  styleUrls: ['./search-page.component.scss']
})
export class SearchPageComponent implements OnInit
{
  @ViewChild(UserGridComponent) child: UserGridComponent;
  private userService: UserService;
  public users: User[];
  public search: string;

  public constructor(userService: UserService, private activateRoute: ActivatedRoute)
  {
    this.userService = userService;
  }

  public ngOnInit(): void
  {
    this.activateRoute.params.subscribe(params =>
    {
      this.search = params['word'];
      this.onEnter();
    });
  }

  public onEnter()
  {
    this.userService.search(this.search)
      .subscribe(result =>
      {
        console.log('result', result);
        this.users = result;
        this.child.addData(this.users);
      });
  }

  public onClear(): void
  {
    this.search = '';
    this.child.addData(null);
  }
}
