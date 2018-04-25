import { AuthService } from '../../services/auth.service';
import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { PageContext } from '../../services/page-context.service';

@Component({
    selector: 'app-base-component',
    template: ''
})
export class BasesComponent
{
    private authService: AuthService;
    private activateRoute: ActivatedRoute;
    private router: Router;

    public constructor(pageContext: PageContext)
    {
        this.authService = pageContext.authService;
        this.activateRoute = pageContext.activateRoute;
        this.router = pageContext.router;
    }

    public getMyId(): number
    {
        return this.authService.authentication.id;
    }

    public navigate(src: string[]): void
    {
        this.router.navigate(src);
    }
}
