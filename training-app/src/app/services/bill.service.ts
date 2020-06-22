import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {AuthService} from './auth.service';
import {environment} from '../../environments/environment';

@Injectable({
    providedIn: 'root'
})
export class BillService {
    public apiBaseUrl = `${environment.apiBaseUrl}`;
    user;

    constructor(private http: HttpClient,
                private authService: AuthService) {
    }

    getUserBills() {
        this.authService.currentUser.subscribe(data => this.user = data);
        return this.http.get(this.apiBaseUrl + 'bill/' + this.user.id);
    }

    createBillForUser(billform) {
        return this.http.post(this.apiBaseUrl + 'bill', billform);
    }

}
