import {Component, OnInit} from '@angular/core';
import {BillService} from '../../services/bill.service';
import {ToastrService} from 'ngx-toastr';
import {toasterConfig} from '../../model/toasterConfig';

@Component({
    selector: 'app-bill',
    templateUrl: './bill.component.html',
    styleUrls: ['./bill.component.scss']
})
export class BillComponent implements OnInit {

    bills;
    user;
    constructor(private billService: BillService, private toastrService: ToastrService) {
    }

    ngOnInit(): void {
        this.user = JSON.parse(localStorage.getItem('currentUser'));
        this.billService.getUserBills().subscribe(data => {
                this.bills = data;
                console.log(data);
            },
            error => this.toastrService.error(error, 'error', toasterConfig)
        );
    }
}
