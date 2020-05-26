import { Component, OnInit } from '@angular/core';
import {TestService} from '../../services/test.service';
import { Subscription} from 'rxjs';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

    constructor() {
    }

    ngOnInit(): void {
    }
}
