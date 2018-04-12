import {Component, OnInit} from '@angular/core';
import { UserService } from '../../../services/user.service';
import { User } from '../../../models/dto-models';
import { AuthService } from '../../../services/auth.service';
import { ActivatedRoute, Router } from '@angular/router';
import {ImageService} from "../../../services/image.service";

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
  public myId: number;
  public image: string;

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
        });
    });
  }

  public showSettings(): void
  {
    if (this.userId === this.myId)
    {
      this.myPage = true;
    }
    else
    {
      this.myPage = false;
    }
  }

  public closeSettings(): void
  {
    if (this.userId === this.myId) {
      this.myPage = false;
    }
  }

  public onUpload(file: File)
  {
    console.log('file', file);
    const formData = new FormData();
    formData.append('file', file, file.name);

    this.imageService.addAvatar(formData)
      .subscribe(path =>
      {
        console.log(path);
      });
  }
}
