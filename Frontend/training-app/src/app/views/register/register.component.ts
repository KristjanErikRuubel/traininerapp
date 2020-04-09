import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {ActivatedRoute, Router} from '@angular/router';
import {AuthService} from '../../services/auth.service';
import {TeamService} from '../../services/team.service';

@Component({
    selector: 'app-register',
    templateUrl: './register.component.html',
    styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

    public registerFormInvalid: boolean;
    private formSubmitAttempt: boolean;
    private returnUrl: string;
    // Roles: any = ['Admin', 'Author', 'Reader'];
    // selected: any;
    registerFromInValid: any;
    registerFrom: any;
    teams: any;
    positions = ["Attacker", "Defender", "Midfielder", "Goalkeeper"];

    constructor(
        private fb: FormBuilder,
        private route: ActivatedRoute,
        private router: Router,
        private authService: AuthService,
        private teamService: TeamService) {
    }

    async ngOnInit() {
        this.returnUrl = this.route.snapshot.queryParams.returnUrl || '/home';

        this.registerFrom = this.fb.group({
            email: ['', Validators.email],
            password: ['', Validators.required],
            password2: ['', Validators.required],
            firstName: ['', Validators.required],
            lastName: ['', Validators.required],
            phoneNumber: ['', Validators.required],
            team: ['', Validators.required],
            role: ['', Validators.required]
        });

        this.teamService.getTeams().subscribe(data =>
            this.teams = data
        );
    }

    onSubmit() {
        let email = this.registerFrom.get('email').value;
        let password = this.registerFrom.get('password').value;
        let firstName = this.registerFrom.get('firstName').value;
        let lastName = this.registerFrom.get('lastName').value;
        const phoneNumber = this.registerFrom.get('phoneNumber').value;
        const teamId = this.registerFrom.get('team').value;
        const role = this.registerFrom.get('role').value;
        const form = {
            email: email,
            password: password,
            firstName: firstName,
            lastName: lastName,
            phoneNumber: phoneNumber,
            team: teamId,
            role: role
        };
        console.log(form);
        this.authService.register(form).then(r =>
        this.router.navigate([this.returnUrl]));


    }
}
