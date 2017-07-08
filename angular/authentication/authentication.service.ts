import { Injectable } from '@angular/core';
import {IUser} from './IUser';

@Injectable()
export class AuthenticationService {

  constructor() {
    this.user = {
      loggedIn: true
    }
  }

  private user: IUser;

  public isUserLoggedIn(): boolean {

    return this.user.loggedIn;
  }

  public getCurrentUser(): IUser{
    return this.user
  }
}
