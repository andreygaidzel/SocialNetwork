import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { UserService } from '../services/user.service';

import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { HomeComponent } from './main/home/home.component';
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


@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    HomeComponent,
    MenuComponent,
    NotFoundComponent,
    MessagesComponent,
    FriendsComponent,
    RegistrationComponent,
    MainComponent,
    AuthComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    ROUTING
  ],
  providers: [UserService, LoginService, AuthGuard],
  bootstrap: [AppComponent]
})
export class AppModule
{
}
