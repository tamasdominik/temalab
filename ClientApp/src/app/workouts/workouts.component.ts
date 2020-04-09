import { Component, OnInit } from '@angular/core';
import { WorkoutService } from '../services/workout.service';
import { Workout } from '../models/workout/workout';
import { Exercise } from '../models/Exercise/exercise';

@Component({
  selector: 'app-workouts',
  templateUrl: './workouts.component.html',
  styleUrls: ['./workouts.component.css']
})
export class WorkoutsComponent implements OnInit {

  Workouts : WorkoutWrapper[] = []
  Exercises : Exercise [] = []
  constructor(private workoutService : WorkoutService) {}

  ngOnInit() {
      this.workoutService.findAll().subscribe(data => {
      this.ParseWorkouts(data);
    })
  }
  ParseWorkouts(W : Workout[]){
    let WorkoutName : string = ""
    let Exercises : Exercise[] = []

    for (let i = 0; i < W.length; i++) {
      if (WorkoutName.includes(W[i].workoutName)){
        Exercises.push(W[i].exercise)
      }
      else {
        if (WorkoutName.length != 0){
          this.Workouts.push(new WorkoutWrapper(WorkoutName, Exercises))
          WorkoutName = W[i].workoutName
          Exercises = []
          Exercises.push(W[i].exercise)
        }
        else {
          WorkoutName = W[i].workoutName
          Exercises.push(W[i].exercise)
        }
      }
    }
    this.Workouts.push(new WorkoutWrapper(WorkoutName,Exercises))
  }
}
class WorkoutWrapper{
  WorkoutName : string
  Exercises : Exercise[] = []
  constructor (w : string, e : Exercise[]){
    this.WorkoutName = w
    this.Exercises = e
  }
}

