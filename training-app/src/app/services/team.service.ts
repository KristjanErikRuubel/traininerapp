import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {AuthService} from './auth.service';
import {environment} from '../../environments/environment';

@Injectable({
    providedIn: 'root'
})
export class TeamService {
    public apiBaseUrl = `${environment.apiBaseUrl}`;
    user: any;

    constructor(private http: HttpClient,
                private authService: AuthService) {
    }

    getTeams() {
        return this.http.get(this.apiBaseUrl + 'team');
    }

    getPlayersInTeam() {
        this.user = this.authService.currentUserValue;
        return this.http.get(this.apiBaseUrl + 'account/getusersinteam/' + this.user.teamId);
    }

    removePlayerFromTeam(player) {
        return this.http.post(this.apiBaseUrl + 'team/removePlayer', player);
    }
}
