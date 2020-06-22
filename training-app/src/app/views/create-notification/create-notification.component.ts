import {Component, OnInit} from '@angular/core';
import {TrainingPlaceService} from '../../services/training-place.service';
import {TrainingService} from '../../services/training.service';
import {FormBuilder, Validators} from '@angular/forms';
import {ActivatedRoute, Router} from '@angular/router';
import {TeamService} from '../../services/team.service';
import {NotificationService} from '../../services/notification.service';

@Component({
    selector: 'app-create-notification',
    templateUrl: './create-notification.component.html',
    styleUrls: ['./create-notification.component.scss']
})
export class CreateNotificationComponent implements OnInit {

    players: any;
    notificationFrom: any;

    constructor(private fb: FormBuilder,
                private route: ActivatedRoute,
                private router: Router,
                private teamService: TeamService,
                private notificationService: NotificationService) {
        this.notificationFrom = this.fb.group({
            notificationDescription: ['', Validators.required],
            title: ['', Validators.required]
        });
    }

    ngOnInit() {
        this.teamService.getPlayersInTeam().subscribe(data => this.players = data);
    }

    removeFromInvited(id: string) {
        this.players = this.players.filter(pl => pl.id !== id);
    }

    onSubmit() {
        const notification = {
            description: this.notificationFrom.get('notificationDescription').value,
            title: this.notificationFrom.get('title').value,
            players: this.players
        };
        this.notificationService.createNotification(notification).toPromise().then(data =>
            this.router.navigate(['/home'])
        );

    }
}
