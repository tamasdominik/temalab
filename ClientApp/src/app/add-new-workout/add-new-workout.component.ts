import { Component, OnInit, Input } from '@angular/core';
import { WorkoutService } from '../services/workout.service';
import { ExercisesService } from '../services/exercises.service';
import { Exercise } from '../models/Exercise/exercise';
import { Workout } from '../models/workout/workout';
import { WorkoutsComponent } from '../workouts/workouts.component';

@Component({
  selector: 'app-add-new-workout',
  templateUrl: './add-new-workout.component.html',
  styleUrls: ['./add-new-workout.component.css']
})
export class AddNewWorkoutComponent implements OnInit {

  allExercises : Exercise[];
  @Input() workout : Workout;

  constructor(private workoutService : WorkoutService, 
    private exerciseService : ExercisesService) { }

  ngOnInit() {
  this.exerciseService.findAll().subscribe(d => {
    this.allExercises = d;
  });
  this.workout= new Workout("");
  }

  searchInExercises(s : string) : Exercise{
    for(let e of this.allExercises){
      if(e.name===s){return e;}
    }
  }

  addExerciseToCustom(s : string){ 
  this.workout.exercise.push(this.searchInExercises(s));
  }
  
  saveCustomButton(){
    this.workoutService.addWorkout(this.workout).subscribe(data => {
      //this.workoutsComponent.Workouts.push(data);
    });
  }

}
