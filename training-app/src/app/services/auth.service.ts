import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {BehaviorSubject, Observable} from 'rxjs';
import {User} from '../model/user';
import {map} from 'rxjs/operators';
import {Router} from '@angular/router';
import {environment} from '../../environments/environment';
import {ToastrService} from 'ngx-toastr';
import {toasterConfig} from '../model/toasterConfig';

@Injectable({
    providedIn: 'root'
})
export class AuthService {

    private currentUserSubject: BehaviorSubject<any> = new BehaviorSubject<any>(null);
    public currentUser: Observable<User>;
    public apiBaseUrl = `${environment.apiBaseUrl}`;
    constructor(private http: HttpClient, private router: Router, private toastrService: ToastrService) {
        this.currentUserSubject = new BehaviorSubject<User>(JSON.parse(localStorage.getItem('currentUser')));
        this.currentUser = this.currentUserSubject.asObservable();
    }

    public get currentUserValue(): User {
        return this.currentUserSubject.value;
    }

    login(email: string, password: string) {
        return this.http.post<any>(this.apiBaseUrl + `account/login`, {email, password})
            .pipe(map(user => {
                // store user details and jwt token in local storage to keep user logged in between page refreshes
                localStorage.setItem('currentUser', JSON.stringify(user));
                this.toastrService.success('You have been logged in as ' + user.userName, 'Success', toasterConfig);
                this.currentUserSubject.next(user);
                return user;
            }));
    }

    logOut() {
        // remove user from local storage to log user out
        localStorage.removeItem('currentUser');
        this.currentUserSubject.next(null);
        this.router.navigate(['/login']);
        this.toastrService.success('You have been logged out', 'Success', toasterConfig);
    }

    register(registerForm) {
        const httpOptions = {headers: new HttpHeaders({'Content-Type': 'application/json'})};
        return this.http.post<any>(this.apiBaseUrl + 'account/register', JSON.stringify({
            email: registerForm.email,
            password: registerForm.password,
            firstName: registerForm.firstName,
            lastName: registerForm.lastName,
            phoneNumber: registerForm.phoneNumber,
            teamId: registerForm.team,
            playerPositions: registerForm.positions,
            role: registerForm.role
        }), httpOptions).pipe(map(user => {
            this.toastrService.success('You have been logged in as ' + user.userName, 'Success', toasterConfig);
            // store user details and jwt token in local storage to keep user logged in between page refreshes
            localStorage.setItem('currentUser', JSON.stringify(user));
            this.currentUserSubject.next(user);
            return user;
        }));
    }

    getAllUsersInTeam() {
        const user = this.currentUserValue;
        return this.http.get(this.apiBaseUrl + 'account/getAllUsers/' + user.teamId);
    }
}
