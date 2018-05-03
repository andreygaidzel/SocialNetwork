import { Component, EventEmitter, ViewChild, Output } from '@angular/core';
import { NgxCroppieComponent } from '../../../../modules/ngx-croppie/ngx-croppie.component';
import { CroppieOptions } from 'croppie';
import { ImageService } from '../../../../../services/image.service';

@Component({
    selector: 'app-croppie-root',
    templateUrl: './croppie.component.html',
    styleUrls: ['./croppie.component.scss']
})
export class CroppiComponent
{
    @ViewChild('ngxCroppie') ngxCroppie: NgxCroppieComponent;
    @Output() emitter = new EventEmitter<string>();
    @Output() close = new EventEmitter<void>();

    public widthPx = '400';
    public heightPx = '500';
    public currentImage: string;
    public croppieImage: string;
    public isVisible = false;
    public imageService: ImageService;

    public constructor(imageService: ImageService)
    {
        this.imageService = imageService;
    }

    public get croppieOptions(): CroppieOptions {
        const opts: CroppieOptions = {};
        opts.viewport = {
            width: parseInt(this.widthPx, 10),
            height: parseInt(this.heightPx, 10)
        };
        opts.boundary = {
            width: parseInt(this.widthPx, 10),
            height: parseInt(this.heightPx, 10)
        };
        opts.enforceBoundary = true;
        return opts;
    }

    newImageResultFromCroppie(img: string) {
        this.croppieImage = img;
    }

    saveImageFromCroppie() {
        this.currentImage = this.croppieImage;

        this.imageService.addAvatar(this.ngxCroppie.newResult())
            .subscribe(avatar =>
            {
                console.log(avatar);
                this.emitter.emit(avatar.fullPath);
                this.isVisible = false;
            });
    }

    cancelCroppieEdit() {
        this.isVisible = false;
        this.croppieImage = this.currentImage;
        this.close.emit();
    }

    imageUpload(file: any) {
        console.log(1);

        if (file.type !== 'image/jpeg' && file.type !== 'image/png' && file.type !== 'image/gif' && file.type !== 'image/jpg') { return; }
        const fr = new FileReader();
        fr.onloadend = (loadEvent) => {
            this.croppieImage = fr.result;
        };
        fr.readAsDataURL(file);
    }
}
