import {Component, OnInit} from '@angular/core';
import {TrainingService} from '../../services/training.service';
import {AuthService} from '../../services/auth.service';
import {Router} from '@angular/router';
import * as moment from 'moment';

@Component({
    selector: 'app-calendar',
    templateUrl: './calendar.component.html',
    styleUrls: ['./calendar.component.scss']
})
export class CalendarComponent implements OnInit {

    trainings : any;
    constructor(
        private authService: AuthService,
        private trainingService : TrainingService,
        private router: Router
    ) {}

    ngOnInit(): void {
        this.trainingService.getTrainingsForUser().subscribe(data => 
            this.trainings = data
        );
        if(this.trainings === undefined ){
            this.trainings = [];
        }
    }

    viewTraining(id: any) {
        this.router.navigate(['/training/'+ id]);
    }
}
