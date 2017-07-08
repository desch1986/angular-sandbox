import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { AuthenticationService } from "./authentication.service";

@Injectable()
export class AuthenticationGuard implements CanActivate {
  
  constructor(private authenticationServive: AuthenticationService) {
  }

  canActivate(next: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    
    return this.authenticationServive.isUserLoggedIn();
  }
}
