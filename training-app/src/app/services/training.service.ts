import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {User} from '../model/user';
import {AuthService} from './auth.service';
import {environment} from '../../environments/environment';
import {ToastrService} from 'ngx-toastr';
import {toasterConfig} from '../model/toasterConfig';

@Injectable({
    providedIn: 'root'
})
export class TrainingService {
    public apiBaseUrl = `${environment.apiBaseUrl}`;
    user: any;

    constructor(private http: HttpClient,
                private authService: AuthService,
                private toastrService: ToastrService) {
    }

    getTrainingsForUser() {
        this.authService.currentUser.subscribe(data => this.user = data);
        return this.http.get(this.apiBaseUrl + 'account/getusertrainings/' + this.user.id);
    }

    async createTraining(trainingFrom: any) {
        const httpOptions = {headers: new HttpHeaders({'Content-Type': 'application/json'})};
        this.http.post(this.apiBaseUrl + 'training', JSON.stringify(trainingFrom),
            httpOptions).subscribe(r => {
                this.toastrService.success(r.toString(), 'Success', toasterConfig);
            });
    }

    getTrainingData(id: string) {
        return this.http.get(this.apiBaseUrl + 'training/' + id);
    }

    deleteTraining(id: any) {
        return this.http.delete(this.apiBaseUrl + 'training/' + id);
    }
}
