import {Component, OnInit} from '@angular/core';
import {TeamService} from '../../services/team.service';
import {ToastrService} from 'ngx-toastr';
import {toasterConfig} from '../../model/toasterConfig';

@Component({
    selector: 'app-manage-team',
    templateUrl: './manage-team.component.html',
    styleUrls: ['./manage-team.component.scss']
})
export class ManageTeamComponent implements OnInit {
    players: any;

    constructor(private teamService: TeamService, public toastrService: ToastrService,) {
    }


    ngOnInit(): void {
        this.teamService.getPlayersInTeam().subscribe(data => this.players = data);
    }
    remove(player){
        this.players = this.players.filter(pl => pl.id !== player.id);
        this.teamService.removePlayerFromTeam(player).toPromise().then(
            r => {
                this.toastrService.success(r.toString(), 'Player removed!', toasterConfig);
            },
            error => {
                this.toastrService.error(error.toString(), 'Error', toasterConfig);
            }
        );
    }


}
