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
  WorkoutsDB : Workout[];

  constructor(private workoutService : WorkoutService, private exerciseService : ExercisesService) {}

  ngOnInit() {
      this.workoutService.findAll().subscribe(data => {
        this.WorkoutsDB = data;
        this.ParseWorkouts(data);
    });
    this.exerciseService.findAll().subscribe(d => {
      this.allExercises = d;
    });

    if(!this.Workouts.find(w => w.WorkoutName==='Custom')){
      let customExercise : Exercise[] =[];
      let custom = new WorkoutWrapper('Custom',customExercise);
      this.Workouts.push(custom);
      this.SerializeWorkoutCustom(custom);
    }
  }

  searchInWorkouts(s: string) : number{
    for (let i = 0; i < this.Workouts.length; i++){
      if (this.Workouts[i].WorkoutName===s){
        return i;
      }
      return undefined;
    }
  }

  searchInWwrExercises(wwr : WorkoutWrapper, s :string) : boolean{ //ezzel lehet még gond a serialize-ben
    for(let e of wwr.Exercises){
      if(e.name === s){return true;}
      else{return false;}
    }
  }

  searchInExercises(s : string) : Exercise{
    for(let e of this.allExercises){
      if(e.name===s){return e;}
    }
  }

  addExerciseToCustom(s : string){  //most még egy gyakorlat többször is belemegy
    let iCustom = this.searchInWorkouts('Custom');
    
    this.Workouts[iCustom].Exercises.push(this.searchInExercises(s));
    this.SerializeWorkoutCustom(this.Workouts[iCustom]);

  }
  
  saveCustomButton(){
    this.SerializeWorkoutCustom(this.Workouts[this.searchInWorkouts('Custom')]);
     // service.addWorkout
    alert("Még nincs mentve az adatbázisba!");
  }

  // SerializeWorkouts(workoutwr : WorkoutWrapper[]){
  //     for(let w of workoutwr){
  //       for(let e of w.Exercises){
  //         let newWorkout = new Workout(w.WorkoutName, e);
  //          this.WorkoutsDB.push(newWorkout);
  //       }
  //     }
  // }

  SerializeWorkoutCustom(wwr: WorkoutWrapper){
    for(let e of wwr.Exercises){
       if(!this.searchInWwrExercises(wwr, e.name)){ //itt lehet gond
        let newWorkout=new Workout(wwr.WorkoutName, e);
        this.WorkoutsDB.push(newWorkout);
       }
    }
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

