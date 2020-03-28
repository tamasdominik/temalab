import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { WorkoutService } from '../services/workout.service';
import { Workout } from '../models/workout/workout';
import { Exercise } from '../models/Exercise/exercise';

@Component({
  selector: 'app-workouts',
  templateUrl: './workouts.component.html',
  styleUrls: ['./workouts.component.css']
})
export class WorkoutsComponent implements OnInit {

  proba : string[];
  constructor(private workoutService : WorkoutService) {}

  ngOnInit() {
    this.proba.push("fhuzdf");
    this.proba.push("fhudhfush");
  }
}
