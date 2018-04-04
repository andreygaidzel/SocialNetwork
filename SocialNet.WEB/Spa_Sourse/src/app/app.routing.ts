import { RouterModule, Routes } from '@angular/router';
import { FriendsComponent } from './main/friends/friends.component';
import { MessagesComponent } from './main/messages/messages.component';
import { NotFoundComponent } from './main/not-found/not-found.component';
import { MyPageComponent } from './main/my-page/my-page.component';
import { ModuleWithProviders } from '@angular/core';
import { MainComponent } from './main/main.component';
import { AuthComponent } from './auth/auth.component';
import { LoginComponent } from './auth/login/login.component';
import { AuthGuard } from './auth.guard';
import { RegistrationComponent } from './auth/registration/registration.component';
import { SearchPageComponent } from './main/search-page/search-page.component';

const ROUTES: Routes = [
  {
    path: '',
    redirectTo: 'id',
    pathMatch: 'full'
  },
  {
    path: '',
    component: AuthComponent,
    children: [
      {
        path: 'login',
        component: LoginComponent
      },
      {
        path: 'registration',
        component: RegistrationComponent
      }
    ]
  },
  {
    path: '',
    component: MainComponent,
    canActivate: [AuthGuard],
    children: [
      {
        path: 'id',
        component: MyPageComponent
      },
      {
        path: 'id/:id',
        component: MyPageComponent
      },
      {
        path: 'messages',
        component: MessagesComponent
      },
      {
        path: 'friends',
        component: FriendsComponent
      },
      {
        path: 'search/:word',
        component: SearchPageComponent
      }
    ]
  },
  {
    path: '**',
    component: NotFoundComponent
  }
];

export const ROUTING: ModuleWithProviders = RouterModule.forRoot(ROUTES);
