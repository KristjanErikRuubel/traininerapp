import {Component, OnInit} from '@angular/core';
import {AuthService} from '../../services/auth.service';

@Component({
    selector: 'app-login-bar',
    templateUrl: './login-bar.component.html',
    styleUrls: ['./login-bar.component.scss']
})
export class LoginBarComponent implements OnInit {
    user;
    constructor(private authService: AuthService) {
    }

    ngOnInit(): void {
        this.authService.currentUser.subscribe(data => this.user = data);
    }


    logout() {
        this.authService.logOut();
    }
}
