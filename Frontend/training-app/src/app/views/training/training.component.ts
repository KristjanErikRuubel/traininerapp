import { Component, OnInit } from '@angular/core';
import {ActivatedRoute, ParamMap, Route, Router} from '@angular/router';
import {switchMap} from 'rxjs/operators';
import {TrainingService} from '../../services/training.service';

@Component({
  selector: 'app-training',
  templateUrl: './training.component.html',
  styleUrls: ['./training.component.scss']
})
export class TrainingComponent implements OnInit {
  training: any;
  constructor(private route: ActivatedRoute,
              private trainingService : TrainingService) { }
  async ngOnInit(){
      let id = this.route.snapshot.paramMap.get('id');
      await this.trainingService.getTrainingData(id).subscribe(
          data => this.training = data
      );
  }
}
