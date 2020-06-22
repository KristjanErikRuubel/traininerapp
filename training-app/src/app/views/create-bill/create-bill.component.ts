import {Component, OnInit} from '@angular/core';
import {AuthService} from '../../services/auth.service';
import {FormBuilder, Validators} from '@angular/forms';
import {ActivatedRoute} from '@angular/router';
import {TeamService} from '../../services/team.service';
import {TrainingService} from '../../services/training.service';
import {BillService} from '../../services/bill.service';
import {ToastrService} from 'ngx-toastr';
import {toasterConfig} from '../../model/toasterConfig';

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
                private trainingService: TrainingService,
                private billService: BillService,
                private toastrService: ToastrService) {
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


    onSubmit() {
        const newInvoice = {
            deadline: this.billForm.get('deadline').value,
            total: this.billForm.get('total').value,
            trainings: this.billForm.get('trainings').value,
            UserBill: this.user
        };
        console.log(newInvoice);
        this.billService.createBillForUser(JSON.stringify(newInvoice)).subscribe(data =>
            this.toastrService.success('', 'New Bill created', toasterConfig)
        );
    }

    selectUser() {
        this.user = this.userForm.get('user').value;
        this.trainingService.getTrainingsForUser().subscribe(data => {
            this.trainings = data;
            console.table(this.trainings);
        });
    }
}
