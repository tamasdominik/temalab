import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Milestone } from '../models/Milestone/milestone'

@Injectable({
  providedIn: 'root'
})
export class MilestoneService {

  private MilestoneURL : string;

  constructor(private http : HttpClient) {
    this.MilestoneURL = "https://localhost:44319/api/Milestones/1";
   }

   public findAll(): Observable<Milestone[]>{
     return this.http.get<Milestone[]>(this.MilestoneURL);
   }
}
