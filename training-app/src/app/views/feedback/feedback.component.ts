import {Component, OnInit} from '@angular/core';
import {FormBuilder, Validators} from '@angular/forms';
import {ActivatedRoute, Router} from '@angular/router';
import {TeamService} from '../../services/team.service';
import {NotificationService} from '../../services/notification.service';
import {AuthService} from '../../services/auth.service';
import {UserService} from '../../services/user.service';
import {Toast, ToastrService} from 'ngx-toastr';
import {toasterConfig} from '../../model/toasterConfig';

@Component({
    selector: 'app-feedback',
    templateUrl: './feedback.component.html',
    styleUrls: ['./feedback.component.scss']
})
export class FeedbackComponent implements OnInit {

    feedBackForm: any;

    constructor(private fb: FormBuilder,
                private route: ActivatedRoute,
                private router: Router,
                private authService: AuthService,
                private userService: UserService,
                private toastrService : ToastrService) {
        this.feedBackForm = this.fb.group({
            feedback: ['', Validators.required],
            rating: [null, Validators.required]
        });
    }

    ngOnInit(): void {
    }

    onSubmit() {
        const feedback = {
            description: this.feedBackForm.get('feedback').value,
            rating: this.feedBackForm.get('rating').value,
            user: this.authService.currentUserValue,
        };
        this.userService.postFeedback(feedback).subscribe(
            r => this.toastrService.success(r.toString(), 'success', toasterConfig)
        );
        this.router.navigate(['/home']);
    }

}
