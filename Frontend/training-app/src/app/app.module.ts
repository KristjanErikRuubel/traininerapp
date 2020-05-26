import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LoginComponent } from './views/login/login.component';
import { RegisterComponent } from './views/register/register.component';
import { HomeComponent } from './views/home/home.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { LoginBarComponent } from './components/login-bar/login-bar.component';
import { CalendarComponent } from './modules/calendar/calendar.component';
import { NotificationComponent } from './modules/notification/notification.component';
import {MatToolbarModule} from '@angular/material/toolbar';
import {RouterModule} from '@angular/router';
import {MatButtonModule} from '@angular/material/button';
import { CreateTrainingComponent } from './views/create-training/create-training.component';
import {MatIconModule} from '@angular/material/icon';
import {MatCardModule} from '@angular/material/card';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {MatSelectModule} from '@angular/material/select';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatNativeDateModule} from '@angular/material/core';
import { ManageTeamComponent } from './views/manage-team/manage-team.component';
import {NgxMaterialTimepickerModule} from 'ngx-material-timepicker';
import { TrainingComponent } from './views/training/training.component';
import { CreateNotificationComponent } from './views/create-notification/create-notification.component';
import { ViewNotificationComponent } from './views/view-notification/view-notification.component';
import { NotificationAnswerComponent } from './modules/notification-answer/notification-answer.component';
import { FooterComponent } from './components/footer/footer.component';
import {MatRadioModule} from '@angular/material/radio';
import {MatSidenavModule} from '@angular/material/sidenav';
import {MatMenuModule} from '@angular/material/menu';
import { BillComponent } from './views/bill/bill.component';
import { CreateBillComponent } from './views/create-bill/create-bill.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegisterComponent,
    HomeComponent,
    NavbarComponent,
    LoginBarComponent,
    CalendarComponent,
    NotificationComponent,
    CreateTrainingComponent,
    ManageTeamComponent,
    TrainingComponent,
    CreateNotificationComponent,
    ViewNotificationComponent,
    NotificationAnswerComponent,
    FooterComponent,
    BillComponent,
    CreateBillComponent
  ],
    imports: [
        NgxMaterialTimepickerModule,
        MatNativeDateModule,
        BrowserModule,
        HttpClientModule,
        AppRoutingModule,
        BrowserAnimationsModule,
        MatToolbarModule,
        RouterModule,
        MatButtonModule,
        MatIconModule,
        MatCardModule,
        ReactiveFormsModule,
        MatFormFieldModule,
        MatInputModule,
        MatSelectModule,
        MatDatepickerModule,
        FormsModule,
        MatRadioModule,
        MatSidenavModule,
        MatMenuModule,
    ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
