import { Authentication } from '../models/dto-models';
import { BrowserStorage } from '../common/storage';
import { Injectable } from '@angular/core';

@Injectable()
export class AuthService
{
  private static readonly AUTHENTICATION = 'social.net.authentication';

  private browserStorage: BrowserStorage;
  private auth: Authentication;

  public constructor()
  {
    this.browserStorage = new BrowserStorage();

    this.auth = this.browserStorage.getObject<Authentication>(AuthService.AUTHENTICATION);
  }

  public get authentication()
  {
    return this.auth;
  }

  public add(auth: Authentication)
  {
    this.auth = auth;
    this.browserStorage.setObject<Authentication>(AuthService.AUTHENTICATION, auth);
  }

  public remove()
  {
      this.browserStorage.removeItem<Authentication>(AuthService.AUTHENTICATION);
  }
}
