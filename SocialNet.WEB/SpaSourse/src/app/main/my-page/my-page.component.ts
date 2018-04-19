import { Component, OnInit } from '@angular/core';
import { UserService } from '../../../services/user.service';
import { User } from '../../../models/dto-models';
import { AuthService } from '../../../services/auth.service';
import { ActivatedRoute, Router } from '@angular/router';
import { ImageService } from '../../../services/image.service';

@Component({
    selector: 'app-my-page-root',
    templateUrl: './my-page.component.html',
    styleUrls: ['./my-page.component.scss']
})
export class MyPageComponent implements OnInit
{
    private authService: AuthService;
    private userService: UserService;
    private imageService: ImageService;
    private activateRoute: ActivatedRoute;
    private router: Router;

    public user = new User();
    public userId: number;
    public myPage = false;
    public isAvatar = false;
    public isNotSend = true;
    public myId: number;
    public image: string;
    public path: string;

    public constructor(userService: UserService, authService: AuthService,
                       activateRoute: ActivatedRoute, router: Router, imageService: ImageService)
    {
        this.userService = userService;
        this.authService = authService;
        this.imageService = imageService;
        this.activateRoute = activateRoute;
        this.router = router;
    }

    public ngOnInit(): void
    {
        this.activateRoute.params.subscribe(params =>
        {
            this.userId = Number(params['id']);
            this.myId = this.authService.authentication.id;

            if (!this.userId)
            {
                this.userId = this.myId;
                this.router.navigate([`id/${this.myId}`]);
            }

            this.userService.getUser(this.userId)
                .subscribe(user =>
                {
                    this.user = user;
                    console.log(user);
                    this.path = user.avatar;
                });
        });
    }

    public showSettings(): void
    {
        if (this.userId === this.myId)
        {
            this.myPage = true;

            if (this.path !== '' && this.path !== null)
            {
                this.isAvatar = true;
            }
        }
        else
        {
            this.myPage = false;
        }
    }

    public closeSettings(): void
    {
        if (this.userId === this.myId)
        {
            this.myPage = false;
            this.isAvatar = false;
        }
    }

    public onUpload(event: any)
    {
        const file = event.srcElement.files[0];
        event.srcElement.value = '';
        const formData = new FormData();
        formData.append('file', file, file.name);
        this.isNotSend = false;

        this.imageService.addAvatar(formData)
            .subscribe(avatar =>
            {
                console.log(avatar);
                this.path = avatar.fullPath;
                this.isNotSend = true;
            });
    }

    public onRemoveAvatar(event: any)
    {
        this.isNotSend = false;
        this.imageService.removeAvatar()
            .subscribe(avatar =>
            {
                console.log(avatar);
                this.path = avatar.fullPath;
                this.isNotSend = true;
            });
    }
}
