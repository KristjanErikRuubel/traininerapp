import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {AuthService} from './auth.service';

@Injectable({
    providedIn: 'root'
})
export class NotificationService {
    user: any;
    constructor(private http: HttpClient,
                private authService: AuthService) {}
    getNotificationsForUser() {
        this.authService.currentUser.subscribe(data => this.user = data);
        return this.http.post('https://localhost:5001/api/account/getusernotifications', JSON.stringify(this.user),
            {headers: new HttpHeaders({'Content-Type': 'application/json'})});
    }

    createNotification(notification: { players: any; description: any; title: any }) {
        return this.http.post('https://localhost:5001/api/notification', notification,
            {headers: new HttpHeaders({'Content-Type': 'application/json'})});
    }

    async answer(answerForm: any) {
        await this.authService.currentUser.subscribe(data => this.user = data);
        console.log(this.user);
        if (answerForm.answer == "1") {
            let form = {
                coming: true,
                notificationId: answerForm.notificationId,
                content: answerForm.content,
                trainingId: answerForm.trainingId,
                appUserId: this.user.id
            };
            console.log(form);
            return this.http.post('https://localhost:5001/api/notificationanswer', form,
                {headers: new HttpHeaders({'Content-Type': 'application/json'})}).subscribe();
        }
        if (answerForm.answer == "2") {
            let form = {
                coming: false,
                notificationId: answerForm.notificationId,
                content: answerForm.content,
                trainingId: answerForm.trainingId,
                appUserId: this.user.id
            };
            console.log(form);
            return this.http.post('https://localhost:5001/api/notificationanswer', form,
                {headers: new HttpHeaders({'Content-Type': 'application/json'})}).subscribe();
        }

    }

    getAllUserNotifications() {
        this.authService.currentUser.subscribe(data => this.user = data);
        return this.http.post('https://localhost:5001/api/account/getallusernotifications', JSON.stringify(this.user),
            {headers: new HttpHeaders({'Content-Type': 'application/json'})});
        
    }
}