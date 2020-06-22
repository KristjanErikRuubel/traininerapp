import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {AuthService} from './auth.service';
import {environment} from '../../environments/environment';

@Injectable({
    providedIn: 'root'
})
export class NotificationService {
    user: any;
    public apiBaseUrl = `${environment.apiBaseUrl}`;

    constructor(private http: HttpClient,
                private authService: AuthService) {
    }

    getNotificationsForUser() {
        this.authService.currentUser.subscribe(data => this.user = data);
        return this.http.get(this.apiBaseUrl + 'account/getusernotifications/' + this.user.id);
    }

    createNotification(notification: { players: any; description: any; title: any }) {
        return this.http.post(this.apiBaseUrl + 'notification', notification,
            {headers: new HttpHeaders({'Content-Type': 'application/json'})});
    }

    async answer(answerForm: any) {
        await this.authService.currentUser.subscribe(data => this.user = data);
        console.log(this.user);
        if (answerForm.answer === '1') {
            const form = {
                coming: true,
                notificationId: answerForm.notificationId,
                content: answerForm.content,
                trainingId: answerForm.trainingId,
                appUserId: this.user.id
            };
            console.log(form);
            return this.http.post(this.apiBaseUrl + 'notificationanswer', form,
                {headers: new HttpHeaders({'Content-Type': 'application/json'})}).subscribe();
        }
        if (answerForm.answer === '2') {
            const form = {
                coming: false,
                notificationId: answerForm.notificationId,
                content: answerForm.content,
                trainingId: answerForm.trainingId,
                appUserId: this.user.id
            };
            console.log(form);
            return this.http.post(this.apiBaseUrl + 'notificationanswer', form,
                {headers: new HttpHeaders({'Content-Type': 'application/json'})}).subscribe();
        }

    }

    getAllUserNotifications() {
        this.authService.currentUser.subscribe(data => this.user = data);
        return this.http.get(this.apiBaseUrl + 'getallusernotifications/' + this.user.id);
    }
}
