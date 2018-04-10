import { Component, OnInit, ViewChild } from '@angular/core';
import { UserService } from '../../../services/user.service';
import { User } from '../../../models/dto-models';
import { AuthService } from '../../../services/auth.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ActionsComponent } from './actions/actions.component';

@Component({
  selector: 'app-my-page-root',
  templateUrl: './my-page.component.html',
  styleUrls: ['./my-page.component.scss']
})
export class MyPageComponent implements OnInit
{
  @ViewChild(ActionsComponent) child: ActionsComponent;
  private authService: AuthService;
  private userService: UserService;
  private activateRoute: ActivatedRoute;
  private router: Router;

  public user = new User();
  public userId: number;

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
          this.child.getUser(this.user);
        });
    });
  }

}
