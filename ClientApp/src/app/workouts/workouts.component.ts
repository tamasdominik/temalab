import { Component, OnInit } from '@angular/core';
import { WorkoutService } from '../services/workout.service';
import { Workout } from '../models/workout/workout';
import { Exercise } from '../models/Exercise/exercise';
import { ExercisesService } from '../services/exercises.service';

@Component({
  selector: 'app-workouts',
  templateUrl: './workouts.component.html',
  styleUrls: ['./workouts.component.css']
})
export class WorkoutsComponent implements OnInit {

  Workouts : WorkoutWrapper[] = []
  Exercises : Exercise [] = []
  allExercises : Exercise[]; 

  constructor(private workoutService : WorkoutService, private exerciseService : ExercisesService) {}

  ngOnInit() {
      this.workoutService.findAll().subscribe(data => {
      this.ParseWorkouts(data);
    })
    this.exerciseService.findAll().subscribe(d => {
      this.allExercises = d;
    })
    let custom = this.Workouts.find(c => c.WorkoutName=="Custom");
    if(!custom){
      let customExercise : Exercise[];
      let customWorkout : WorkoutWrapper = new WorkoutWrapper("Custom", customExercise);
      this.Workouts.push(customWorkout);
      //workoutService.addWorkout
    }
    
  }

  addExerciseToCustom(){ 
    //add a new custom workout if CustomWorkout does not exist
    let found = this.Workouts.find(c => c.WorkoutName=="Custom");
    // let foundExercise=found.Exercises.find(e => e.name==eName);
    // if(foundExercise){
    //   found.Exercises.push(foundExercise);
    alert("Siker");
    
    // }
  
    //add current exercise to custom
    //service.update.subscribe
  
  }
  
  saveCustomButton(){
    //service.update.subscribe
    alert("Mentve");
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

