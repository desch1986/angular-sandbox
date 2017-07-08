import { Component } from '@angular/core';
import { Router, NavigationStart } from "@angular/router";

@Component({
  selector: 'app',
  templateUrl: './app.component.html'
})
export class AppComponent {

  constructor(private router: Router) {

    this.router.events.subscribe(
      event => this.resetStylePropertiesOnRouteChange(event));
  }
  public isNavigationVisible: boolean = true;

  resetStylePropertiesOnRouteChange(event: any) {
    if (event instanceof NavigationStart) {
      this.isNavigationVisible = true;
    }
  }
}
