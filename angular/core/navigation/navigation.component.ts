import { Component } from '@angular/core';
import { AuthenticationService } from "../../authentication/authentication.service";
import { Router } from "@angular/router";
import { IUser } from "../../authentication/IUser";

@Component({
  selector: 'navigation',
  templateUrl: './navigation.component.html'
})
export class NavigationComponent {

  constructor(private router: Router,
    private authenticationService: AuthenticationService) {

    this.userInfo = this.authenticationService.getCurrentUser();
  }

  public userInfo: IUser;

  public logout(): void {

    this.router.navigate(["welcome"]);
  }
}