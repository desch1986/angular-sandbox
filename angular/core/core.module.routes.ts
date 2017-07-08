
import { ModuleWithProviders }  from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ToDosComponent } from './todos/todos.component';
import { ManagementComponent } from "./management/management.component";
import { LandingPageComponent } from "./landing-page/landing-page.component";
import { AuthenticationGuard } from "../authentication/authentication.guard";

// Route Configuration
export const routes: Routes = [
  {
    path: '',
    redirectTo: 'welcome',
    pathMatch: 'full'
  },
  {
    path: 'welcome',
    component: LandingPageComponent
  },
  {
    path: 'todos',
    component: ToDosComponent,
    canActivate: [AuthenticationGuard]
  },
  {
    path: 'management',
    component: ManagementComponent,
    canActivate: [AuthenticationGuard]
  },
];

export const routing: ModuleWithProviders = RouterModule.forRoot(routes);