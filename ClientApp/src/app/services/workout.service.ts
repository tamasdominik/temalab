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
    this.workoutURL = "https://localhost:44319/api/Workout_Connection/1";
   }

   public findAll(): Observable<Workout[]>{
     return this.http.get<Workout[]>(this.workoutURL);
   }

   updateWorkout(w : Workout) : Observable<any>{
    return this.http.put(this.workoutURL, w);
  }

  addWorkout(w: Workout) : Observable<Workout>{
    return this.http.post<Workout>(this.workoutURL, w);
  }
}
