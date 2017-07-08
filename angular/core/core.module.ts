import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { SharedModule } from "../shared/shared.module";

import { AppComponent } from './app/app.component';
import { NavigationComponent } from './navigation/navigation.component';
import { ToDosComponent } from './todos/todos.component'

import { routes } from "./core.module.routes";
import { ManagementComponent } from "./management/management.component";
import { LandingPageComponent } from "./landing-page/landing-page.component";
import { AuthenticationModule } from "../authentication/authentication.module";

@NgModule({
  declarations: [
    AppComponent,
    LandingPageComponent,
    NavigationComponent,
    ToDosComponent,
    ManagementComponent    
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    RouterModule.forRoot(routes),
    AuthenticationModule,
    SharedModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class CoreModule { }
