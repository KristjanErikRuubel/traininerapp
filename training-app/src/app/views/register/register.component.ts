import {Component, OnInit} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {ActivatedRoute, Router} from '@angular/router';
import {AuthService} from '../../services/auth.service';
import {TeamService} from '../../services/team.service';
import {UserService} from '../../services/user.service';

@Component({
    selector: 'app-register',
    templateUrl: './register.component.html',
    styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

    public registerFormInvalid: boolean;
    private formSubmitAttempt: boolean;
    private returnUrl: string;
    roles: any = ['Admin', 'Manager', 'Basic user'];

    // selected: any;
    registerFromInValid: any;
    registerFrom: any;
    teams: any;
    positions: string[] = ['Attacker', 'Defender', 'Midfielder', 'Goalkeeper'];

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
            role: ['', Validators.required],
            position: [[]]
        });

        this.teamService.getTeams()
            .subscribe(data => this.teams = data);
    }

    async onSubmit() {
        this.formSubmitAttempt = false;
        this.registerFormInvalid = false;
        try {
            const email = this.registerFrom.get('email').value;
            const password = this.registerFrom.get('password').value;
            const firstName = this.registerFrom.get('firstName').value;
            const lastName = this.registerFrom.get('lastName').value;
            const phoneNumber = this.registerFrom.get('phoneNumber').value;
            const teamId = this.registerFrom.get('team').value;
            const role = this.registerFrom.get('role').value;
            const positions = this.registerFrom.controls.position.value;
            const form = {
                email,
                password,
                firstName,
                lastName,
                phoneNumber,
                team: teamId,
                role,
                positions
            };
            await this.authService.register(form).subscribe(data => {
                if (data.token != null) {
                    
                    this.router.navigate([this.returnUrl]);
                }
            });
        } catch (e) {
            this.registerFormInvalid = true;
        }

    }
}
