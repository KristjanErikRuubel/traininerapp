import {Component, OnInit} from '@angular/core';
import {TrainingPlaceService} from '../../services/training-place.service';
import {ToastrService} from 'ngx-toastr';
import {FormBuilder, Validators} from '@angular/forms';
import {ActivatedRoute, Router} from '@angular/router';
import {toasterConfig} from '../../model/toasterConfig';

@Component({
    selector: 'app-manage-trainingplaces',
    templateUrl: './manage-trainingplaces.component.html',
    styleUrls: ['./manage-trainingplaces.component.scss']
})
export class ManageTrainingplacesComponent implements OnInit {
    trainingPlaceForm;
    trainingPlaces;

    constructor(private trainingPlaceService: TrainingPlaceService,
                private toastrService: ToastrService,
                private fb: FormBuilder,
                private route: ActivatedRoute,
                private router: Router,
    ) {
        this.trainingPlaceForm = this.fb.group({
            address: ['', Validators.required],
            name: ['', Validators.required],
            openingTime: ['', Validators.required],
            closingTime: ['', Validators.required]
        });
    }

    ngOnInit(): void {
        this.trainingPlaceService.getTrainingPlaces().subscribe(data => {
                this.trainingPlaces = data;
            }, error => this.toastrService.error(error)
        );
    }

    onSubmit() {
        const form = {
            address: this.trainingPlaceForm.get('address').value,
            name: this.trainingPlaceForm.get('name').value,
            openingTime: this.trainingPlaceForm.get('openingTime').value,
            closingTime: this.trainingPlaceForm.get('closingTime').value
        };
        this.trainingPlaceService.addTrainingPlace(form).subscribe( data => {
                this.toastrService.success(JSON.stringify(data));
                location.reload();
            },
                error => this.toastrService.error(error));
    }

    delete(id: any) {
        this.trainingPlaceService.delete(id).toPromise().then(
            response => {
                this.toastrService.success(response.toString(), 'Succsess', toasterConfig);
                location.reload();
            }
        ).catch(error => this.toastrService.error(error, 'Error', toasterConfig ));
    }
}
