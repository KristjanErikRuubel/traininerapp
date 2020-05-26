import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {User} from '../model/user';
import {AuthService} from './auth.service';

@Injectable({
    providedIn: 'root'
})
export class TrainingService {

    user: any;

    constructor(private http: HttpClient,
                private authService: AuthService) {
    }

    getTrainingsForUser() {
        this.authService.currentUser.subscribe(data => this.user = data);
        console.log(this.user);
        return this.http.get('https://localhost:5001/api/account/getusertrainings/' + this.user.id);
    }

    async createTraining(trainingFrom: any) {
        const httpOptions = {headers: new HttpHeaders({'Content-Type': 'application/json'})};
        this.http.post('https://localhost:5001/api/training', JSON.stringify(trainingFrom),
            httpOptions).subscribe(r => {
                alert(r);
            });
    }

    getTrainingData(id: string) {
        return this.http.get('https://localhost:5001/api/training/' + id);
    }

}
