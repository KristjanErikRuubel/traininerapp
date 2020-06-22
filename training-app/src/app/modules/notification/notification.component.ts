import {Component, OnInit} from '@angular/core';
import {NotificationService} from '../../services/notification.service';
import {MatDialog, MatDialogConfig} from '@angular/material/dialog';
import {NotificationAnswerComponent} from '../notification-answer/notification-answer.component';
import {ModalDataService} from '../../services/modal-data.service';

@Component({
    selector: 'app-notification',
    templateUrl: './notification.component.html',
    styleUrls: ['./notification.component.scss']
})
export class NotificationComponent implements OnInit {

    notifications: any;

    constructor(private notificationService: NotificationService,
                public matDialog: MatDialog,
                private modalDataService: ModalDataService) {
    }

    ngOnInit(): void {
        this.notifications = [];
        this.notificationService.getNotificationsForUser().subscribe(data => this.notifications = data);
    }

    openNotificationAnswerModal(notification: any) {
        this.modalDataService.setNotification(notification);
        const dialogConfig = new MatDialogConfig();
        dialogConfig.disableClose = true;
        dialogConfig.id = 'modal-component';
        dialogConfig.height = '600px';
        dialogConfig.width = '600px';
        const modalDialog = this.matDialog.open(NotificationAnswerComponent, dialogConfig);
    }
}
