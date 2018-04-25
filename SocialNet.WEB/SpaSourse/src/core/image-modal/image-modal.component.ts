import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { Avatar, User } from '../../models/dto-models';

@Component({
    selector: 'app-image-modal-root',
    templateUrl: './image-modal.component.html',
    styleUrls: ['./image-modal.component.scss']
})
export class ImageModalComponent
{
    public avatarModal = false;
    public imageList: Avatar[];
    public number = 0;
    public rightButtonShow = true;
    public leftButtonShow = false;
    public buttonShow = false;

    public onAvatarModalShow(images: Avatar[])
    {
        this.avatarModal = true;
        this.imageList = images;
        if (this.number + 1 === this.imageList.length)
        {
            this.rightButtonShow = false;
        }
    }

    public onAvatarModalClose(event: any)
    {
        this.avatarModal = false;
        this.number = 0;
        this.leftButtonShow = false;
        this.rightButtonShow = true;
    }

    public onNextImg()
    {
        this.number += 1;
        console.log(this.number);
        if (this.number > 0)
        {
            this.leftButtonShow = true;
        }

        if (this.number + 1 === this.imageList.length)
        {
            this.rightButtonShow = false;
        }
    }

    public onPrevImg()
    {
        this.number -= 1;
        console.log(this.number);
        if (this.number > 0)
        {
            this.leftButtonShow = true;
        }
        else
        {
            this.leftButtonShow = false;
        }

        if (this.number + 1 !== this.imageList.length)
        {
            this.rightButtonShow = true;
        }
    }

    public onButtonsShow()
    {
        this.buttonShow = true;
    }

    public onButtonsHide()
    {
        this.buttonShow = false;
    }
}
