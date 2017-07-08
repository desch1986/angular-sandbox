import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { ConfirmationComponent } from './modals/confirmation.component';

@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        HttpModule,
        RouterModule
    ],
    declarations: [
        ConfirmationComponent
    ],
    exports: [
        ConfirmationComponent,
        ],
    providers: []
})
export class SharedModule {
}