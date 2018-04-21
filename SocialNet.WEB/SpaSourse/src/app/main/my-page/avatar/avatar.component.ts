import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { ImageService } from '../../../../services/image.service';
import { User } from '../../../../models/dto-models';
import { UserGridComponent } from '../../../../core/user-grid/user-grid.component';
import { ImageModalComponent } from '../../../../core/image-modal/image-modal.component';

@Component({
    selector: 'app-avatar-root',
    templateUrl: './avatar.component.html',
    styleUrls: ['./avatar.component.scss']
})
export class AvatarComponent
{
    @ViewChild(ImageModalComponent) child: ImageModalComponent;

    public _user = new User();

    @Input()
    public set user(user: User)
    {
        this._user = user;
        this.path = user.avatar;
    }

    private imageService: ImageService;

    public userId: number;
    public myPage = false;
    public isAvatar = false;
    public isNotSend = true;
    public myId: number;
    public image: string;
    public path: string;

    public constructor(imageService: ImageService)
    {
        this.imageService = imageService;
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
                if (avatar !== null)
                {
                    this.path = avatar.fullPath;
                }
                else
                {
                    this.path = null;
                    this.isAvatar = false;
                }

                this.isNotSend = true;
            });
    }

    public onAvatarModalShow(event: any)
    {
        this.imageService.getAvatars()
            .subscribe(avatars =>
            {
                console.log(avatars);
                this.child.onAvatarModalShow(avatars);
            });
    }
}
