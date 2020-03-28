import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Workout } from '../models/workout/workout';

@Injectable({
  providedIn: 'root'
})
export class WorkoutService {

  private workoutURL : string;

  constructor(private http : HttpClient) {
    this.workoutURL = "http://localhost:4200/workouts";
   }

   public findAll(): Observable<Workout[]>{
     return this.http.get<Workout[]>(this.workoutURL);
   }
}
