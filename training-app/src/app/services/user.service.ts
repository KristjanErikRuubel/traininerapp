import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {User} from '../model/user';
import {environment} from '../../environments/environment';

@Injectable({
    providedIn: 'root'
})
export class UserService {

    public apiBaseUrl = `${environment.apiBaseUrl}`;

    constructor(private http: HttpClient) {
    }


    getAllMembersInTeam(team) {
        return this.http.get<User>(this.apiBaseUrl + 'team/members');
    }

    removeMemberFromTeam(user: User) {
        return this.http.post('', user);

    }

    addMemberToTeam(user: User) {
        return this.http.post('', user);
    }

    getPositions() {
        return this.http.get(this.apiBaseUrl + 'playerposition');

    }
    postFeedback(feedbackForm){
        return this.http.post(this.apiBaseUrl + 'feedback', feedbackForm);
    }
}
