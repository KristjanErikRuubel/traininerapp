import {Injectable} from '@angular/core';

@Injectable({
    providedIn: 'root'
})
export class ModalDataService {
    notification: any;

    constructor() {
    }
    
    setNotification(notification){
        this.notification = notification;
    }
    getNotification(){
        return this.notification;
    }
}
