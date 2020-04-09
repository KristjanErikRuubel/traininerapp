import {Component, OnInit} from '@angular/core';
import {AuthService} from '../../services/auth.service';

@Component({
    selector: 'app-login-bar',
    templateUrl: './login-bar.component.html',
    styleUrls: ['./login-bar.component.scss']
})
export class LoginBarComponent implements OnInit {

    isAuthenticated: any;

    constructor(private authService: AuthService) {
    }

    ngOnInit(): void {
        this.isAuthenticated = () => {
            const currentUser = this.authService.currentUserValue;
            return !!currentUser;
        }
    }

    
    
    logout() {
        this.authService.logOut();
        this.isAuthenticated = false;
    }
}
