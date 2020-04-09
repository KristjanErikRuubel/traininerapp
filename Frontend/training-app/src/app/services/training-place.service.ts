import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {TrainingPlace} from '../model/training-place';

@Injectable({
  providedIn: 'root'
})
export class TrainingPlaceService {

    constructor(private http: HttpClient) { }

    addTrainingPlace(place: TrainingPlace){
        return this.http.post('https://localhost:5001/api/trainingplace', place);
    }
    
    getTrainingPlaces(){
        return this.http.get<TrainingPlace>("https://localhost:5001/api/trainingplace");
    }
    
}
