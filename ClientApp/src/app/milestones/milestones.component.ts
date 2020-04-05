import { Component, OnInit } from '@angular/core';
import { StatisticsService} from '../services/statistics.service';
import { MilestoneService} from '../services/milestone.service';
import { Statistics } from '../models/Statistics/statistics';
import { Milestone } from '../models/Milestone/milestone';

@Component({
  selector: 'app-milestones',
  templateUrl: './milestones.component.html',
  styleUrls: ['./milestones.component.css']
})
export class MilestonesComponent implements OnInit {
  MileStones : Milestone[] = []
  Statistics : Statistics[] = []
  Percentages : number [] = []
  PictureSources : string [] = ["assets/img/Pushup.jpg","assets/img/situp.jpg","assets/img/biceps.jpg","assets/img/chestfly.jpg",
  "assets/img/deadlift.jpg","assets/img/squat.jpg","assets/img/pullup.jpeg","assets/img/roadrunner.jpg","assets/img/ironlady.jpg"]

  constructor(private StatisticsService : StatisticsService, private MilestoneService : MilestoneService) { }

  ngOnInit() {
    this.StatisticsService.findAll().subscribe(data => {
      this.Statistics = data
    })
    this.MilestoneService.findAll().subscribe(data =>{
      this.MileStones = data
    })
    this.ParseData()
  }
  ParseData(){
    console.log(this.MileStones)
    console.log(this.Statistics)
    for (let i = 0; i < this.MileStones.length; i++){
      for (let j = 0; i < this.Statistics.length, j++;){
        if (this.MileStones[i].name === this.Statistics[j].name ) {
          let percentage = 100*(this.Statistics[j].counter / this.MileStones[i].goal)
          if (percentage > 100) percentage = 100
          console.log(percentage)
          this.Percentages.push(percentage)
        }
      }
    }
  }
  GetWidth(index : number){
    let p : number = this.Percentages[index]
    return "width:${p}%"
  }
  GetPercentage(index : number){
    return this.Percentages[index]
  }
}
