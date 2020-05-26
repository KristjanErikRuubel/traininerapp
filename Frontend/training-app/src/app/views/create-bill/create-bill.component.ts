import {Component, OnInit} from '@angular/core';
import {AuthService} from '../../services/auth.service';
import {FormBuilder, Validators} from '@angular/forms';
import {ActivatedRoute} from '@angular/router';
import {TeamService} from '../../services/team.service';
import {TrainingService} from '../../services/training.service';

@Component({
    selector: 'app-create-bill',
    templateUrl: './create-bill.component.html',
    styleUrls: ['./create-bill.component.scss']
})
export class CreateBillComponent implements OnInit {
    users;
    user;
    trainings;
    total;

    constructor(private authService: AuthService,
                private teamService: TeamService,
                private fb: FormBuilder,
                private route: ActivatedRoute,
                private trainingService: TrainingService) {
        this.userForm = this.fb.group(
            {
                user: []
            }
        );
        this.billForm = this.fb.group({
            deadline: ['', Validators.required],
            total: ['', Validators.required],
            trainings: [[], Validators.required]
        });
    }

    userForm: any;
    billForm: any;

    ngOnInit(): void {
        this.teamService.getPlayersInTeam().subscribe(data => {
            this.users = data;
        });
    }


    selectUser() {
        this.user = this.userForm.get('user').value;
        this.trainingService.getTrainingsForUser().subscribe(data =>{
            this.trainings = data;
            console.table(this.trainings);
        });
    }
}
