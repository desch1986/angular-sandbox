import { Component, OnInit } from '@angular/core';
import { IToDo } from "../models/IToDo";
import { ToDosService } from "../services/todos.service";

@Component({
  selector: 'todos',
  templateUrl: './todos.component.html',
  providers: [ ToDosService ]
})
export class ToDosComponent implements OnInit {

    public toDos: IToDo[];
    public description:string;

    constructor(private toDosService: ToDosService) {

        this.description = "";
    }

    public ngOnInit() {

        this.loadToDos();
    }

    private loadToDos() {

        this.toDosService.getToDos()
                                .subscribe(t => this.toDos = t);
    }

    deleteElement(id: number){
        // TODO.
        alert("Deleting entry: " + id);
    }
}