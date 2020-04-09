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
        return this.http.post('https://localhost:5001/api/account/getusertrainings', JSON.stringify(this.user),
            {headers: new HttpHeaders({'Content-Type': 'application/json'})} );
    }
    
    async createTraining(trainingFrom: any) {
        console.log(JSON.stringify(trainingFrom));
        const httpOptions = {headers: new HttpHeaders({'Content-Type': 'application/json'})};
        this.http.post('https://localhost:5001/api/test', JSON.stringify(trainingFrom),
            httpOptions).subscribe(r => console.log(r));
    }
    
    getTrainingData(id: string) {
        return this.http.get('https://localhost:5001/api/training/' + id);
    }
    
}
