import { Component, OnInit } from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {ActivatedRoute, Router} from '@angular/router';
import {AuthService} from '../../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
    form: FormGroup;
    public loginInvalid: boolean;
    private formSubmitAttempt: boolean;
    private returnUrl: string;

    constructor(
        private fb: FormBuilder,
        private route: ActivatedRoute,
        private router: Router,
        private authService: AuthService
    ) {
    }

    async ngOnInit() {
        this.returnUrl = this.route.snapshot.queryParams.returnUrl || '/home';

        this.form = this.fb.group({
            username: ['', Validators.email],
            password: ['', Validators.required]
        });
    }

    async onSubmit() {
        this.loginInvalid = false;
        this.formSubmitAttempt = false;
        if (this.form.valid) {
            try {
                const email = this.form.get('username').value;
                const password = this.form.get('password').value;
                await this.authService.login(email, password).subscribe(data =>{
                    if (data.token != null){
                        this.router.navigate([this.returnUrl]);
                    }
                    
                });
               
            } catch (err) {
                this.loginInvalid = true;
            }
        } else {
            this.formSubmitAttempt = true;
        }
    }
}


