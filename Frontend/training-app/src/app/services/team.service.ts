import {Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {AuthService} from './auth.service';

@Injectable({
    providedIn: 'root'
})
export class TeamService {

    user: any;

    constructor(private http: HttpClient,
                private authService: AuthService) {
    }

    getTeams() {
        return this.http.get('https://localhost:5001/api/team');
    }

    getPlayersInTeam() {
        this.user = this.authService.currentUserValue;
        return this.http.get('https://localhost:5001/api/account/getusersinteam/' + this.user.teamId);
    }

    removePlayerFromTeam(player) {
        return this.http.post('https://localhost:5001/api/team/removePlayer', player,
            {headers: new HttpHeaders({'Content-Type': 'application/json'})});
    }
}
