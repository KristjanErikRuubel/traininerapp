import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import {LoginComponent} from './views/login/login.component';
import {HomeComponent} from './views/home/home.component';
import {RegisterComponent} from './views/register/register.component';
import {CreateTrainingComponent} from './views/create-training/create-training.component';
import {ManageTeamComponent} from './views/manage-team/manage-team.component';
import {TrainingComponent} from './views/training/training.component';
import {CreateNotificationComponent} from './views/create-notification/create-notification.component';
import {NotificationComponent} from './modules/notification/notification.component';


const appRoutes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'home',  component: HomeComponent },
  { path: 'register',  component: RegisterComponent },
  { path: 'manage',  component: ManageTeamComponent },
  { path: 'training/create',  component: CreateTrainingComponent },
  { path: 'training/:id',  component: TrainingComponent },
  { path: 'notification/create',  component: CreateNotificationComponent },
  { path: 'notifications',  component: NotificationComponent },
];
@NgModule({
  imports: [
    RouterModule.forRoot(
      appRoutes
      // { enableTracing: true }
    )
    // other imports here
  ],
})
export class AppRoutingModule { }
