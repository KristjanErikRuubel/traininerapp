import {Component, OnInit} from '@angular/core';
import {TeamService} from '../../services/team.service';

[{
    name: 'Tiit Sokk',
    email: 'tiit@sokk.ee',
    team: 'FC Sominum',
    phoneNr: '52712312'
},
    {
        name: 'Tiit Sokk',
        email: 'tiit@sokk.ee',
        team: 'FC Sominum',
        phoneNr: '52712312'
    },
    {
        name: 'Tiit Sokk',
        email: 'tiit@sokk.ee',
        team: 'FC Sominum',
        phoneNr: '52712312'
    },
    {
        name: 'Tiit Sokk',
        email: 'tiit@sokk.ee',
        team: 'FC Sominum',
        phoneNr: '52712312'
    }, {
    name: 'Tiit Sokk',
    email: 'tiit@sokk.ee',
    team: 'FC Sominum',
    phoneNr: '52712312'
},
    {
        name: 'Tiit Sokk',
        email: 'tiit@sokk.ee',
        team: 'FC Sominum',
        phoneNr: '52712312'
    }
];

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
    removeFromInvited(id : string){
        this.players = this.players.filter(pl => pl.id != id);
    }


}
