import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {BehaviorSubject, Observable} from 'rxjs';
import {User} from '../model/user';
import {map} from 'rxjs/operators';
import {Router} from '@angular/router';

@Injectable({
    providedIn: 'root'
})
export class AuthService {

    private currentUserSubject: BehaviorSubject<any> = new BehaviorSubject<any>(null);
    public currentUser: Observable<User>;

    constructor(private http: HttpClient, private router: Router) {
        this.currentUserSubject = new BehaviorSubject<User>(JSON.parse(localStorage.getItem('currentUser')));
        this.currentUser = this.currentUserSubject.asObservable();
    }

    public get currentUserValue(): User {
        return this.currentUserSubject.value;
    }

    login(email: string, password: string) {
        return this.http.post<any>(`https://localhost:5001/api/account/login`, {email, password})
            .pipe(map(user => {
                // store user details and jwt token in local storage to keep user logged in between page refreshes
                localStorage.setItem('currentUser', JSON.stringify(user));
                this.currentUserSubject.next(user);
                return user;
            }));
    }

    logOut() {
        // remove user from local storage to log user out
        localStorage.removeItem('currentUser');
        this.currentUserSubject.next(null);
        this.router.navigate(['/login']);
    }

    register(registerForm) {
        const httpOptions = {headers: new HttpHeaders({'Content-Type': 'application/json'})};
        return this.http.post<any>('https://localhost:5001/api/account/register', JSON.stringify({
            email: registerForm.email,
            password: registerForm.password,
            firstName: registerForm.firstName,
            lastName: registerForm.lastName,
            phoneNumber: registerForm.phoneNumber,
            teamId: registerForm.team,
            playerPositions: registerForm.positions,
            role: registerForm.role
        }), httpOptions).pipe(map(user => {
            console.log(user);
            // store user details and jwt token in local storage to keep user logged in between page refreshes
            localStorage.setItem('currentUser', JSON.stringify(user));
            this.currentUserSubject.next(user);
            return user;
        }));
    }

    getAllUsersInTeam() {
        const user = this.currentUserValue;
        return this.http.get('https://localhost:5001/api/account/getAllUsers/' + user.teamId);
    }
}
