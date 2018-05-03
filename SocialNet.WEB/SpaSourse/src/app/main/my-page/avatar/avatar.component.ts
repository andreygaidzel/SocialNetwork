import { Component, Input, ViewChild} from '@angular/core';
import { ImageService } from '../../../../services/image.service';
import { User } from '../../../../models/dto-models';
import { ImageModalComponent } from '../../../../core/image-modal/image-modal.component';
import { BasesComponent } from '../../../base/base.component';
import { PageContext } from '../../../../services/page-context.service';
import { CroppiComponent } from './croppi/croppie.component';
import { NgxCroppieComponent } from '../../../modules/ngx-croppie/ngx-croppie.component';

@Component({
    selector: 'app-avatar-root',
    templateUrl: './avatar.component.html',
    styleUrls: ['./avatar.component.scss']
})
export class AvatarComponent extends BasesComponent
{
    @ViewChild(ImageModalComponent) child: ImageModalComponent;
    @ViewChild(CroppiComponent) childCroppi: CroppiComponent;
    @ViewChild(NgxCroppieComponent) result: NgxCroppieComponent;

    public _user = new User();

    @Input()
    public set user(user: User)
    {
        this._user = user;
        this.path = user.avatar;
        this.userId = user.id;
    }

    private imageService: ImageService;

    public userId: number;
    public myPage = false;
    public isAvatar = false;
    public isNotSend = true;
    public myId: number = this.getMyId();
    public image: string;
    public path: string;

    public constructor(imageService: ImageService, pageContext: PageContext)
    {
        super(pageContext);
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
        this.isNotSend = false;

        this.childCroppi.imageUpload(file);
        this.childCroppi.isVisible = true;
    }

    public setNewPath(path: string): void
    {
        this.path = path;
        this.isNotSend = true;
    }

    public closeModal(): void
    {
        this.isNotSend = true;
        this.closeSettings();
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
        this.imageService.getAvatars(this.userId)
            .subscribe(avatars =>
            {
                console.log(avatars);
                this.child.onAvatarModalShow(avatars);
            });
    }
}
