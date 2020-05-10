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
    this.workoutURL = "https://localhost:44319/api/Workout_Connection";
   }

   public findAll(): Observable<Workout[]>{
     return this.http.get<Workout[]>(this.workoutURL);
   }

  addWorkout(w: Workout) : Observable<Workout>{
    return this.http.post<Workout>(this.workoutURL, w);
  }

   deleteWorkout(id : number) : Observable<Workout>{
     const url = `${this.workoutURL}/${id}`;
     return this.http.delete<Workout>(url);
   }

   completeWorkout(w: Workout){
     const id = w.id;
     const url = `${this.workoutURL}/${id}`;
     return this.http.put<Workout>(url, w);
   }

}
