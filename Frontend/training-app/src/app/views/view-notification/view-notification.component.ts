import {Component, OnInit} from '@angular/core';
import {NotificationService} from '../../services/notification.service';

@Component({
    selector: 'app-view-notification',
    templateUrl: './view-notification.component.html',
    styleUrls: ['./view-notification.component.scss']
})
export class ViewNotificationComponent implements OnInit {

    notifications : any;
    constructor(private notificationService: NotificationService) {
    }

    ngOnInit(): void {
        this.notificationService.getAllUserNotifications().subscribe(data => this.notifications = data);
    }
    


}
