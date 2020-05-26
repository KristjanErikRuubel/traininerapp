import {Component, OnInit} from '@angular/core';
import {AuthService} from '../../services/auth.service';

@Component({
    selector: 'app-login-bar',
    templateUrl: './login-bar.component.html',
    styleUrls: ['./login-bar.component.scss']
})
export class LoginBarComponent implements OnInit {

    isAuthenticated: any;
    user;
    constructor(private authService: AuthService) {
    }

    ngOnInit(): void {
        this.authService.currentUser.subscribe(data => this.user = data);
        this.isAuthenticated = () => {
            return !!this.user;
        };
    }

    logout() {
        this.authService.logOut();
        this.isAuthenticated = false;
    }
}
