import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
    selector: 'confirmation',
    inputs: ['pk', 'lg', 'title', 'message', 'icon'],
    templateUrl: 'confirmation.component.html'
})
export class ConfirmationComponent {
    @Output() confirmationFunction = new EventEmitter();
    @Input() pk: any;
    @Input() title: string;
    @Input() message: string;
    @Input() icon: string = "fa-question";
    @Input() lg: boolean = false;

    constructor() { }

    executeFunction() {
        this.confirmationFunction.emit();
    }
}