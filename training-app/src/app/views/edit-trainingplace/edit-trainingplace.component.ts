import {Component, OnInit} from '@angular/core';
import {TrainingPlaceService} from '../../services/training-place.service';
import {ToastrService} from 'ngx-toastr';
import {FormBuilder, Validators} from '@angular/forms';
import {ActivatedRoute, Router} from '@angular/router';
import {TrainingPlace} from '../../model/training-place';

@Component({
    selector: 'app-edit-trainingplace',
    templateUrl: './edit-trainingplace.component.html',
    styleUrls: ['./edit-trainingplace.component.scss']
})
export class EditTrainingplaceComponent implements OnInit {
    trainingPlaceForm;
    trainingPlace: TrainingPlace | null = null;

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
        const id = this.route.snapshot.paramMap.get('id');
        this.trainingPlaceService.getTrainingPlace(id).subscribe(data => {
                this.trainingPlace = data;
            }
        );
        console.log(this.trainingPlace);
    }
    
    ngOnInit(){
    }
    
    onSubmit() {
        const form = {
            address: this.trainingPlaceForm.get('address').value,
            name: this.trainingPlaceForm.get('name').value,
            openingTime: this.trainingPlaceForm.get('openingTime').value,
            closingTime: this.trainingPlaceForm.get('closingTime').value
        };
        this.trainingPlaceService.editTrainingPlace(form).subscribe(data => {
                this.toastrService.success(JSON.stringify(data));
                this.router.navigate(['/home']);
            },
            error => this.toastrService.error(error));
    }
}
