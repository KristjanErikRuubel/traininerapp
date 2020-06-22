import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {TrainingPlace} from '../model/training-place';
import {environment} from '../../environments/environment';

@Injectable({
    providedIn: 'root'
})
export class TrainingPlaceService {
    public apiBaseUrl = `${environment.apiBaseUrl}`;

    constructor(private http: HttpClient) {
    }

    addTrainingPlace(place) {
        return this.http.post(this.apiBaseUrl + 'trainingplace', place);
    }

    getTrainingPlaces() {
        return this.http.get<TrainingPlace[]>(this.apiBaseUrl + 'trainingplace');
    }

    delete(id: any) {
        return this.http.delete(this.apiBaseUrl + 'trainingplace/' + id);
    }

    getTrainingPlace(id: string) {
        return this.http.get<TrainingPlace>(this.apiBaseUrl + 'trainingplace/'+id);
    }

    editTrainingPlace(form: { address: any; closingTime: any; openingTime: any; name: any }) {
        return this.http.put('trainingplace', form);
    }
}
