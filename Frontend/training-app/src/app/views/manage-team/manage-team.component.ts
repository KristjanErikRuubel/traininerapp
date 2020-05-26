import {Component, OnInit} from '@angular/core';
import {TeamService} from '../../services/team.service';

@Component({
    selector: 'app-manage-team',
    templateUrl: './manage-team.component.html',
    styleUrls: ['./manage-team.component.scss']
})
export class ManageTeamComponent implements OnInit {
    players: any;

    constructor(private teamService: TeamService) {
    }


    ngOnInit(): void {
        this.teamService.getPlayersInTeam().subscribe(data => this.players = data);
    }
    remove(player){
        this.players = this.players.filter(pl => pl.id !== player.id);
        this.teamService.removePlayerFromTeam(player).subscribe(
            data => console.log(data)
        );
    }


}
