import { Injectable } from "@angular/core";
import { Observable } from "rxjs/Observable";
import { IToDo } from "../models/IToDo";
import { Http } from "@angular/http";

import 'rxjs/add/operator/map';

@Injectable()
export class ToDosService {

    constructor(private http: Http) {
        
    }

    public getToDos(): Observable<IToDo[]> {  
        
        return this.http.get("http://localhost:5000/api/todos")
                        .map(result => result.json() as IToDo[])
    }
}