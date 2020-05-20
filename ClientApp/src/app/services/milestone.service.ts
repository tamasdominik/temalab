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
    this.MilestoneURL = "/api/Milestones";
   }

   public findAll(): Observable<Milestone[]>{
     return this.http.get<Milestone[]>(this.MilestoneURL);
   }
}
