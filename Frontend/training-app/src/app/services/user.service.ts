import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {User} from '../model/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {
    
  constructor(private http: HttpClient) { }
  
    
  getAllMembersInTeam(team)
  {
      return this.http.get<User>("https://localhost:5001/api/team/members");
  }
  
  removeMemberFromTeam(user: User){
      return this.http.post("", user);
      
  }
  
  addMemberToTeam(user: User)
  {
      return this.http.post("", user);
  }
  
  getPositions(){
      return this.http.get("https://localhost:5001/api/playerposition");
      
  }
}
