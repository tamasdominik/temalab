import { Component, OnInit } from '@angular/core';
import { WorkoutService } from '../services/workout.service';
import { Workout } from '../models/workout/workout';

@Component({
  selector: 'app-workouts',
  templateUrl: './workouts.component.html',
  styleUrls: ['./workouts.component.css']
})
export class WorkoutsComponent implements OnInit {

  Workouts : Workout[];

  constructor(private workoutService : WorkoutService) {}

  ngOnInit() {
      this.workoutService.findAll().subscribe(data => {
        this.Workouts = data;
    });
  }

}

