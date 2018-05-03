import { Component, OnInit, Input, ViewChild, ElementRef } from '@angular/core';

import * as Croppie from 'croppie';
import { CroppieOptions, ResultOptions } from 'croppie';

export type Type = 'canvas' | 'base64' | 'html' | 'blob' | 'rawcanvas';

export interface TempResultOptions extends ResultOptions {
    type?: Type;
}

@Component({
    selector: 'ngx-croppie',
    template: `<div #imageEdit (update)="newResult()"></div> `
})
export class NgxCroppieComponent implements OnInit {
    @ViewChild('imageEdit') imageEdit: ElementRef;
    @Input() croppieOptions: CroppieOptions;
    @Input() imageUrl: string;
    @Input() bind: (img: string) => void;
    @Input() outputFormatOptions: TempResultOptions = { type: 'base64', size: 'viewport' };

    private _croppie: Croppie;
    private result: HTMLCanvasElement;

    ngOnInit(): void {
        this._croppie = new Croppie['Croppie'](this.imageEdit.nativeElement, this.croppieOptions);

        this._croppie.bind({
            url: this.imageUrl
        });
        this.bind = (img: string) => {
            this._croppie.bind({ url: this.imageUrl });
        };
    }

    newResult(): HTMLCanvasElement {
        this._croppie.result(this.outputFormatOptions).then((res) =>
        {
            this.result = res;
        });
        return this.result;
    }
}
