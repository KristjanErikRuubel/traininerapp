import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {BehaviorSubject, Observable} from 'rxjs';
import {User} from '../model/user';
import {map} from 'rxjs/operators';

@Injectable({
    providedIn: 'root'
})
export class AuthService {

    private currentUserSubject: BehaviorSubject<User>;
    public currentUser: Observable<User>;

    constructor(private http: HttpClient) {
        this.currentUserSubject = new BehaviorSubject<User>(JSON.parse(localStorage.getItem('currentUser')));
        this.currentUser = this.currentUserSubject.asObservable();
    }

    public get currentUserValue(): User {
        return this.currentUserSubject.value;
    }

    login(email: string, password: string) {
        return this.http.post<any>(`https://localhost:5001/api/account/login`, { email, password })
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
    }

    async register(registerForm) {
        const httpOptions = {headers: new HttpHeaders({'Content-Type': 'application/json'})};
        this.http.post('https://localhost:5001/api/account/register', JSON.stringify({
                email: registerForm.email,
                password: registerForm.password,
                firstName: registerForm.firstName,
                lastName: registerForm.lastName,
                phoneNumber: registerForm.phoneNumber,
                teamId: registerForm.team,
                playerPosition: registerForm.role
            }),
            httpOptions).subscribe(
            data => {
                //this.login(data.username, data.password);
            }
        );
    }
    

    // async login(username: string, password: string) {
    //     console.log(username);
    //     const httpOptions = {headers: new HttpHeaders({'Content-Type': 'application/json'})};
    //     console.log(password);
    //     this.http.post('https://localhost:5001/api/account/login', JSON.stringify({
    //         email: username,
    //         password: password
    //     }), httpOptions).subscribe(
    //         data => this.addUserToLocalStorage(data)
    //     );
    //
    // }

}
