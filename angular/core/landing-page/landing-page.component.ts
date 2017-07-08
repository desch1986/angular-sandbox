import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from "../../authentication/authentication.service";
import { AppComponent } from "../app/app.component";
import { Router } from "@angular/router";

@Component({
  selector: 'landing-page',
  templateUrl: './landing-page.component.html'
})
export class LandingPageComponent implements OnInit {

  constructor(
    private appComponent: AppComponent,
    private authenticationService: AuthenticationService,
    private router: Router) {
  }

  public ngOnInit() {

    this.appComponent.isNavigationVisible = false;
  }

  public login(): void {

    this.redirectToDashboard();
  }

  private redirectToDashboard() {
    this.router.navigate(["/todos"]);
  }
}