import { Component, OnInit } from '@angular/core';
import { WorkoutService } from '../services/workout.service';
import { Workout } from '../models/workout/workout';
import { Router } from '@angular/router';

@Component({
  selector: 'app-workouts',
  templateUrl: './workouts.component.html',
  styleUrls: ['./workouts.component.css']
})
export class WorkoutsComponent implements OnInit {

  Workouts : Workout[];

  constructor(private workoutService : WorkoutService, private router: Router) {}

  ngOnInit() {
      this.workoutService.findAll().subscribe(data => {
        this.Workouts = data;
    });
  }

  redirect(){
    this.router.navigate(['']);
  }

  deleteWorkout(workoutId : number){
    let result = confirm("Are you sure?");
    if(result){ 
      this.workoutService.deleteWorkout(workoutId).subscribe(result => this.redirect());
      alert("Your workout has been sucessfully deleted!")
    }  
  }

  completeWorkout(workoutId : number){
    this.workoutService.completeWorkout(workoutId).subscribe();
    alert("Congratulations! Your workout is completed!");
  }

}

