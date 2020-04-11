import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Exercise } from '../models/Exercise/exercise';

@Injectable({
  providedIn: 'root'
})
export class ExercisesService {

  private exercisesURL : string;

  constructor(private http : HttpClient) {
    this.exercisesURL = "https://localhost:44319/api/Exercises";
   }

   public findAll(): Observable<Exercise[]>{
    return this.http.get<Exercise[]>(this.exercisesURL);
   }
}
