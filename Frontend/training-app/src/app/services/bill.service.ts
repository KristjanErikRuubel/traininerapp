import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {AuthService} from './auth.service';

@Injectable({
    providedIn: 'root'
})
export class BillService {

    user;

    constructor(private http: HttpClient,
                private authService: AuthService) {
    }

    getUserBills() {
        this.authService.currentUser.subscribe(data => this.user = data);
        return this.http.get('https://localhost:5001/api/account/getbills/' + this.user.id);
    }
    
    createBillForUser(){
    }
    
}
