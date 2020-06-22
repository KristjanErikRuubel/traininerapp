import { Injectable } from '@angular/core';
import {AuthService} from './auth.service';
import {ActivatedRouteSnapshot, Router, RouterStateSnapshot} from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import {toasterConfig} from '../model/toasterConfig';

@Injectable({
  providedIn: 'root'
})
export class AuthGuardService {

    constructor(public toastrService: ToastrService, public authService: AuthService, public router: Router) {}

    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
        const currentUser = this.authService.currentUserValue;
        if (currentUser) {
            // logged in so return true
            return true;
        }
        this.toastrService.error('Please login','You are not logged in');
        // not logged in so redirect to login page with the return url
        this.router.navigate(['/login'], { queryParams: { returnUrl: state.url } });
        return false;
    }
}
