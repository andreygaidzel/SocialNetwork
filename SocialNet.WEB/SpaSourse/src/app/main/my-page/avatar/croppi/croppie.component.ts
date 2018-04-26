import { Component, OnInit, ViewChild, OnChanges  } from '@angular/core';
import { CroppieOptions } from 'croppie';
import { NgxCroppieComponent } from '../../../../modules/ngx-croppie/ngx-croppie.component';
import { BasesComponent } from '../../../../base/base.component';

@Component({
    selector: 'app-croppie-root',
    templateUrl: './croppie.component.html',
    styleUrls: ['./croppie.component.scss']
})
export class CroppiComponent extends BasesComponent implements OnInit, OnChanges
{
    @ViewChild('ngxCroppie') ngxCroppie: NgxCroppieComponent;

    widthPx = '200';
    heightPx = '400';
    imageUrl = '';
    currentImage: string;
    croppieImage: string;


    ngOnInit() {
        this.currentImage = this.imageUrl;
        this.croppieImage = this.imageUrl;
    }

    ngOnChanges(changes: any) {
        if (this.croppieImage) { return; }
        if (!changes.imageUrl) { return; }
        if (!changes.imageUrl.previousValue && changes.imageUrl.currentValue) {
            this.croppieImage = changes.imageUrl.currentValue;
        }
    }

    public get imageToDisplay() {
        if (this.currentImage) { return this.currentImage; }
        if (this.imageUrl) { return this.imageUrl; }
        return `http://placehold.it/${this.widthPx}x${this.heightPx}`;
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

    // modalOpened() {
    //   if (this.croppieImage) {
    //     console.log('binding image to croppie');
    //     this.ngxCroppie.bind();
    //   }
    // }
    newImageResultFromCroppie(img: string) {
        this.croppieImage = img;
    }

    saveImageFromCroppie() {
        this.currentImage = this.croppieImage;
    }

    cancelCroppieEdit() {
        this.croppieImage = this.currentImage;
    }

    imageUploadEvent(evt: any) {
        if (!evt.target) { return; }
        if (!evt.target.files) { return; }
        if (evt.target.files.length !== 1) { return; }
        const file = evt.target.files[0];
        if (file.type !== 'image/jpeg' && file.type !== 'image/png' && file.type !== 'image/gif' && file.type !== 'image/jpg') { return; }
        const fr = new FileReader();
        fr.onloadend = (loadEvent) => {
            this.croppieImage = fr.result;
        };
        fr.readAsDataURL(file);
    }
}
