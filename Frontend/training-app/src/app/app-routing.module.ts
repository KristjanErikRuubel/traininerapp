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


const appRoutes: Routes = [
    {path: 'login', component: LoginComponent},
    {path: 'home', component: HomeComponent},
    {path: 'register', component: RegisterComponent},
    {path: 'manage', component: ManageTeamComponent},
    {path: 'training/create', component: CreateTrainingComponent},
    {path: 'training/:id', component: TrainingComponent},
    {path: 'notification/create', component: CreateNotificationComponent},
    {path: 'notifications', component: NotificationComponent},
    {path: 'bill', component: BillComponent},
    {path: 'bill/create', component: CreateBillComponent},
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
