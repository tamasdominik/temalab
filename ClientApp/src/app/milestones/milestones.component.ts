import { Component, OnInit } from '@angular/core';
import { MilestoneService} from '../services/milestone.service';
import { Milestone } from '../models/Milestone/milestone';

@Component({
  selector: 'app-milestones',
  templateUrl: './milestones.component.html',
  styleUrls: ['./milestones.component.css']
})
export class MilestonesComponent implements OnInit {
  Milestones : Milestone[];
  PictureSources : string [] = ["assets/img/Pushup.jpg","assets/img/situp.jpg","assets/img/biceps.jpg","assets/img/chestfly.jpg",
  "assets/img/deadlift.jpg","assets/img/squat.jpg","assets/img/pullup.jpeg","assets/img/roadrunner.jpg","assets/img/ironlady.jpg"];
  MilestoneNames : string [] = ["Pushup King: Do 1000 pushups", "Situp King: Do 1000 situps", "Biceps pro", "Chest fly master",
  "Deadlift resurrector", "Squat terminator", "Pullup monkey", "Roadrunner", "Ironlady wannabe"];

  constructor(private MilestoneService : MilestoneService) { }


  ngOnInit() {
    this.MilestoneService.findAll().subscribe(data =>{
      this.Milestones = data
    })
  }

  Floor(x : number) : number{
    return Math.floor(x) > 100 ? 100 : Math.floor(x);
  }
}
