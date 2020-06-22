import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {TrainingPlaceService} from '../../services/training-place.service';
import {TrainingService} from '../../services/training.service';
import {FormBuilder, FormControl, FormGroup, Validators} from '@angular/forms';
import {ActivatedRoute, Router} from '@angular/router';
import {TeamService} from '../../services/team.service';
import {NgxMaterialTimepickerTheme} from 'ngx-material-timepicker';
import {AuthService} from '../../services/auth.service';


@Component({
    selector: 'app-create-training',
    templateUrl: './create-training.component.html',
    styleUrls: ['./create-training.component.scss']
})
export class CreateTrainingComponent implements OnInit {

    constructor(private trainingPlaceService: TrainingPlaceService,
                private trainingService: TrainingService,
                private fb: FormBuilder,
                private route: ActivatedRoute,
                private router: Router,
                private teamService: TeamService,
                private authService: AuthService) {
        this.trainingFrom = this.fb.group({
            duration: ['', Validators.required],
            start: ['', Validators.required],
            description: ['', Validators.required],
            notificationDescription: ['', Validators.required],
            place: ['', Validators.required],
            startTime: ['', Validators.required],
            createdBy: []
        });
    }
    places: any;
    trainingFrom: any;
    players: any;
    user;

    darkTheme: NgxMaterialTimepickerTheme = {
        container: {
            bodyBackgroundColor: '#424242',
            buttonColor: '#fff'
        },
        dial: {
            dialBackgroundColor: '#555',
        },
        clockFace: {
            clockFaceBackgroundColor: '#555',
            clockHandColor: '#790e8b',
            clockFaceTimeInactiveColor: '#fff'
        }
    };

    ngOnInit() {
        this.trainingPlaceService.getTrainingPlaces().subscribe(data => this.places = data);
        this.teamService.getPlayersInTeam().subscribe(data => this.players = data);
        this.authService.currentUser.subscribe(data => this.user = data);
    }

    onSubmit() {
        const form = {
            duration: this.trainingFrom.get('duration').value,
            start: this.trainingFrom.get('start').value,
            startTime: this.trainingFrom.get('startTime').value,
            description: this.trainingFrom.get('description').value,
            trainingPlaceId: this.trainingFrom.get('place').value,
            notificationContent: this.trainingFrom.get('notificationDescription').value,
            peopleInvited: this.players,
            createdBy: this.user
        };
        this.trainingService.createTraining(form).then(r =>
            this.router.navigate(['/home'])
        );
    }

    removeFromInvited(id: string) {
        this.players = this.players.filter(pl => pl.id !== id);
    }
}
