import {NgModule} from '@angular/core';
import {Routes, RouterModule} from '@angular/router';
import {LoginComponent} from './views/login/login.component';
import {HomeComponent} from './views/home/home.component';
import {RegisterComponent} from './views/register/register.component';
import {CreateTrainingComponent} from './views/create-training/create-training.component';
import {ManageTeamComponent} from './views/manage-team/manage-team.component';
import {TrainingComponent} from './views/training/training.component';
import {CreateNotificationComponent} from './views/create-notification/create-notification.component';
import {NotificationComponent} from './modules/notification/notification.component';
import {BillComponent} from './views/bill/bill.component';
import {CreateBillComponent} from './views/create-bill/create-bill.component';
import {FeedbackComponent} from './views/feedback/feedback.component';
import {AuthGuardService} from './services/auth-guard.service';
import {ManageTrainingplacesComponent} from './views/manage-trainingplaces/manage-trainingplaces.component';
import {EditTrainingplaceComponent} from './views/edit-trainingplace/edit-trainingplace.component';


const appRoutes: Routes = [
    {path: 'login', component: LoginComponent},
    {path: 'register', component: RegisterComponent},
    {path: 'home', component: HomeComponent,  canActivate: [AuthGuardService] },
    {path: 'manage', component: ManageTeamComponent, canActivate: [AuthGuardService] },
    {path: 'training/create', component: CreateTrainingComponent, canActivate: [AuthGuardService] },
    {path: 'training/:id', component: TrainingComponent, canActivate: [AuthGuardService] },
    {path: 'notification/create', component: CreateNotificationComponent, canActivate: [AuthGuardService] },
    {path: 'notifications', component: NotificationComponent, canActivate: [AuthGuardService] },
    {path: 'bill', component: BillComponent, canActivate: [AuthGuardService] },
    {path: 'bill/create', component: CreateBillComponent, canActivate: [AuthGuardService] },
    {path: 'feedback/create', component: FeedbackComponent, canActivate: [AuthGuardService] },
    {path: 'trainingplaces', component: ManageTrainingplacesComponent, canActivate: [AuthGuardService] },
    {path: 'trainingplace/edit/:id', component: EditTrainingplaceComponent, canActivate: [AuthGuardService] }
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
export class AppRoutingModule {
}
