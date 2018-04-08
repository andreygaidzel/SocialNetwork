import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { UserService } from '../services/user.service';

import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { MyPageComponent } from './main/my-page/my-page.component';
import { MenuComponent } from './menu/menu.component';
import { NotFoundComponent } from './main/not-found/not-found.component';
import { MessagesComponent } from './main/messages/messages.component';
import { FriendsComponent } from './main/friends/friends.component';
import { RegistrationComponent } from './auth/registration/registration.component';
import { ROUTING } from './app.routing';
import { MainComponent } from './main/main.component';
import { AuthComponent } from './auth/auth.component';
import { LoginComponent } from './auth/login/login.component';
import { AuthGuard } from './auth.guard';
import { LoginService } from '../services/login.service';
import { AuthService } from '../services/auth.service';
import { SearchComponent } from './header/search/search.component';
import { SearchPageComponent } from './main/search-page/search-page.component';
import { UserGridComponent } from '../core/user-grid/user-grid.component';
import { HttpService } from '../services/http.service';


@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    MyPageComponent,
    MenuComponent,
    NotFoundComponent,
    MessagesComponent,
    FriendsComponent,
    RegistrationComponent,
    MainComponent,
    AuthComponent,
    LoginComponent,
    SearchComponent,
    SearchPageComponent,
    UserGridComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    ROUTING
  ],
  providers: [UserService, LoginService, AuthService, AuthGuard, HttpService],
  bootstrap: [AppComponent]
})
export class AppModule
{
}
