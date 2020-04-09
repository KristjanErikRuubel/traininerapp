import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TestService {

    constructor(private http: HttpClient) { }

    getTrainingsForUser(){
        return this.http.get<[]>('https://localhost:5001/api/bill/');
    }


}
