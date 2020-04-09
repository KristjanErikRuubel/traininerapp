import {Component, OnInit} from '@angular/core';
import {MatDialogRef} from '@angular/material/dialog';
import {ModalDataService} from '../../services/modal-data.service';
import {TrainingService} from '../../services/training.service';
import {FormBuilder, Validators} from '@angular/forms';
import {Router} from '@angular/router';
import {NotificationService} from '../../services/notification.service';

@Component({
    selector: 'app-notification-answer',
    templateUrl: './notification-answer.component.html',
    styleUrls: ['./notification-answer.component.scss']
})
export class NotificationAnswerComponent implements OnInit {

    notificationToAnswer: any;
    trainingData: any;
    notificationAnswerForm: any;
    constructor(
        public dialogRef: MatDialogRef<NotificationAnswerComponent>,
        private modalDataService : ModalDataService,
        private trainingService: TrainingService,
        private fb: FormBuilder,
        private router: Router,
        private notificationService : NotificationService
    ) {
        this.notificationAnswerForm = this.fb.group({
            answer: ['', Validators.required],
            content: ['', Validators.required],
        });
        
    }

    ngOnInit(): void {
        this.notificationToAnswer = this.modalDataService.getNotification();
    }
    
    onSubmit(){
        let notificationId = this.notificationToAnswer.id;
        let answer = this.notificationAnswerForm.get("answer").value;
        let content = this.notificationAnswerForm.get("content").value;
        let answerForm = {
            answer: answer,
            content: content,
            notificationId: notificationId,
            trainingId : this.notificationToAnswer.trainingDto.id
        };
        this.notificationService.answer(answerForm);
        this.dialogRef.close();
    }
    
    closeModal() {
        this.dialogRef.close();
    }

}
