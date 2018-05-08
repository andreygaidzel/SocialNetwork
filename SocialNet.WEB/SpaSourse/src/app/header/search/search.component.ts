import { Component } from '@angular/core';
import { AuthService } from '../../../services/auth.service';
import { UserService } from '../../../services/user.service';
import { User } from '../../../models/dto-models';
import { searchDelay } from '../../../common/searchDelay';
import { UserRelation } from '../../../models/dto-enums';
import { Router } from '@angular/router';

@Component({
    selector: 'app-search-root',
    templateUrl: './search.component.html',
    styleUrls: ['./search.component.scss']
})
export class SearchComponent
{
    private authService: AuthService;
    private userService: UserService;
    private router: Router;

    public users: User[];

    public constructor(userService: UserService, authService: AuthService, router: Router)
    {
        this.userService = userService;
        this.authService = authService;
        this.router = router;
    }

    public search = '';
    public isShow: boolean;

    public onInput(): void
    {
        searchDelay(() =>
        {
            this.sendSearch();
        }, 500);
    }

    public sendSearch(): void
    {
        if (this.search)
        {
            this.userService.search(this.search)
                .subscribe(result =>
                {
                    this.users = result;
                });
        }
    }

    public onFocus(): void
    {
        this.isShow = true;

        this.userService.getFriends(UserRelation.Friend)
            .subscribe(result =>
            {
                this.users = result;
            });
    }

    public onBlur(): void
    {
        this.isShow = false;
    }

    public onClear(): void
    {
        console.log('clear');
        this.isShow = false;
        this.search = '';
    }

    public onNavigateTo(word: string): void
    {
        console.log('word', word);
        if (word !== null && word !== '' && typeof(word) !== 'undefined')
        {
            this.router.navigate([`/search/${word}`]);
        }
        else
        {
            alert('Введите данные для поиска');
        }
    }
}
