import { Component, OnInit } from '@angular/core';
import { UserService } from '../../../services/user.service';
import { User } from '../../../models/dto-models';
import { AuthService } from '../../../services/auth.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ImageService } from '../../../services/image.service';
import { BasesComponent } from '../../base/base.component';
import { PageContext } from '../../../services/page-context.service';

@Component({
    selector: 'app-my-page-root',
    templateUrl: './my-page.component.html',
    styleUrls: ['./my-page.component.scss']
})
export class MyPageComponent extends BasesComponent implements OnInit
{
   // private authService: AuthService;
    private userService: UserService;
    private activateRouter: ActivatedRoute;
    private pageContext: PageContext;

    public user = new User();
    public userId: number;
    public myId: number = this.getMyId()
    public image: string;
    public path: string;

    public constructor(userService: UserService, pageContext: PageContext)
    {
        super(pageContext);
        this.userService = userService;
       // this.authService = authService;
        this.activateRouter = pageContext.activateRoute;
        this.pageContext = pageContext;
    }

    public ngOnInit(): void
    {
        this.activateRouter.params.subscribe(params =>
        {
            this.userId = Number(params['id']);
            console.log(this.userId);
           // this.myId = this.authService.authentication.id;

            if (!this.userId)
            {
                this.userId = this.myId;
                this.navigate([`id/${this.myId}`]);
            }

            this.userService.getUser(this.userId)
                .subscribe(user =>
                {
                    this.user = user;
                   // console.log(user);
                   // this.path = user.avatar;
                });
        });
    }


}
